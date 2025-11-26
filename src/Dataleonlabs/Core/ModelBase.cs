using System.Collections.Generic;
using System.Text.Json;
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

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.RawData, _toStringSerializerOptions);
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
