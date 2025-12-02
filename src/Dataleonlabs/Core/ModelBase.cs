using System.Collections.Generic;
using System.Text.Json;
using Dataleonlabs.Exceptions;
using Dataleonlabs.Models.Companies;
using Dataleonlabs.Models.Companies.Documents;
using Documents = Dataleonlabs.Models.Individuals.Documents;
using Individuals = Dataleonlabs.Models.Individuals;

namespace Dataleonlabs.Core;

public abstract record class ModelBase
{
    private protected FreezableDictionary<string, JsonElement> _rawData = [];

    public IReadOnlyDictionary<string, JsonElement> RawData
    {
        get { return this._rawData.Freeze(); }
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, AmlSuspicionStatus>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, Source>(),
            new ApiEnumConverter<string, MemberType>(),
            new ApiEnumConverter<string, PortalStep1>(),
            new ApiEnumConverter<string, PortalStep>(),
            new ApiEnumConverter<string, PortalStepModel>(),
            new ApiEnumConverter<string, State>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, DocumentType>(),
            new ApiEnumConverter<string, Individuals::Gender>(),
            new ApiEnumConverter<string, Individuals::PortalStep>(),
            new ApiEnumConverter<string, Individuals::PersonModelGender>(),
            new ApiEnumConverter<string, Individuals::PortalStepModel>(),
            new ApiEnumConverter<string, Individuals::State>(),
            new ApiEnumConverter<string, Individuals::Status>(),
            new ApiEnumConverter<string, Documents::DocumentType>(),
        },
    };

    static readonly JsonSerializerOptions _toStringSerializerOptions = new(SerializerOptions)
    {
        WriteIndented = true,
    };

    internal static void Set<T>(IDictionary<string, JsonElement> dictionary, string key, T value)
    {
        dictionary[key] = JsonSerializer.SerializeToElement(value, SerializerOptions);
    }

    internal static T GetNotNullClass<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : class
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            throw new DataleonlabsInvalidDataException($"'{key}' cannot be absent");
        }

        try
        {
            return JsonSerializer.Deserialize<T>(element, SerializerOptions)
                ?? throw new DataleonlabsInvalidDataException($"'{key}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new DataleonlabsInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    internal static T GetNotNullStruct<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : struct
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            throw new DataleonlabsInvalidDataException($"'{key}' cannot be absent");
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions)
                ?? throw new DataleonlabsInvalidDataException($"'{key}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new DataleonlabsInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    internal static T? GetNullableClass<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : class
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new DataleonlabsInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    internal static T? GetNullableStruct<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : struct
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new DataleonlabsInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.RawData, _toStringSerializerOptions);
    }

    public virtual bool Equals(ModelBase? other)
    {
        if (other == null || this.RawData.Count != other.RawData.Count)
        {
            return false;
        }

        foreach (var item in this.RawData)
        {
            if (!other.RawData.TryGetValue(item.Key, out var otherValue))
            {
                return false;
            }

            if (!JsonElement.DeepEquals(item.Value, otherValue))
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public abstract void Validate();
}

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
interface IFromRaw<T>
{
    /// <summary>
    /// NOTE: This interface is in the style of a factory instance instead of using
    /// abstract static methods because .NET Standard 2.0 doesn't support abstract
    /// static methods.
    /// </summary>
    T FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData);
}
