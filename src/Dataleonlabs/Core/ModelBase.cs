using System.Collections.Generic;
using System.Text.Json;
using Dataleonlabs.Models.Companies;
using Dataleonlabs.Models.Companies.Documents;
using Documents = Dataleonlabs.Models.Individuals.Documents;
using Individuals = Dataleonlabs.Models.Individuals;

namespace Dataleonlabs.Core;

public abstract record class ModelBase
{
    private protected FreezableDictionary<string, JsonElement> _properties = [];

    public IReadOnlyDictionary<string, JsonElement> Properties
    {
        get { return this._properties.Freeze(); }
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
        return JsonSerializer.Serialize(this.Properties, _toStringSerializerOptions);
    }

    public abstract void Validate();
}

interface IFromRaw<T>
{
    static abstract T FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties);
}
