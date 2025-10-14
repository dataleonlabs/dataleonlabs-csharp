using System.Collections.Generic;
using System.Text.Json;
using Dataleonlabs.Models.Companies.AmlSuspicionProperties;
using Dataleonlabs.Models.Companies.Documents.DocumentUploadParamsProperties;
using Dataleonlabs.Models.Companies.TechnicalDataProperties;
using Dataleonlabs.Models.Individuals.IndividualCreateParamsProperties.PersonProperties;
using CompanyListParamsProperties = Dataleonlabs.Models.Companies.CompanyListParamsProperties;
using DocumentUploadParamsProperties = Dataleonlabs.Models.Individuals.Documents.DocumentUploadParamsProperties;
using IndividualListParamsProperties = Dataleonlabs.Models.Individuals.IndividualListParamsProperties;
using MemberProperties = Dataleonlabs.Models.Companies.CompanyProperties.MemberProperties;
using PersonProperties = Dataleonlabs.Models.Individuals.IndividualUpdateParamsProperties.PersonProperties;
using TechnicalDataProperties = Dataleonlabs.Models.Companies.CompanyCreateParamsProperties.TechnicalDataProperties;

namespace Dataleonlabs.Core;

public abstract record class ModelBase
{
    public Dictionary<string, JsonElement> Properties { get; set; } = [];

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, MemberProperties::Source>(),
            new ApiEnumConverter<string, MemberProperties::Type>(),
            new ApiEnumConverter<string, PortalStep>(),
            new ApiEnumConverter<string, TechnicalDataProperties::PortalStep>(),
            new ApiEnumConverter<
                string,
                global::Dataleonlabs.Models.Companies.CompanyUpdateParamsProperties.TechnicalDataProperties.PortalStep
            >(),
            new ApiEnumConverter<string, CompanyListParamsProperties::State>(),
            new ApiEnumConverter<string, CompanyListParamsProperties::Status>(),
            new ApiEnumConverter<string, DocumentType>(),
            new ApiEnumConverter<string, Gender>(),
            new ApiEnumConverter<
                string,
                global::Dataleonlabs.Models.Individuals.IndividualCreateParamsProperties.TechnicalDataProperties.PortalStep
            >(),
            new ApiEnumConverter<string, PersonProperties::Gender>(),
            new ApiEnumConverter<
                string,
                global::Dataleonlabs.Models.Individuals.IndividualUpdateParamsProperties.TechnicalDataProperties.PortalStep
            >(),
            new ApiEnumConverter<string, IndividualListParamsProperties::State>(),
            new ApiEnumConverter<string, IndividualListParamsProperties::Status>(),
            new ApiEnumConverter<string, DocumentUploadParamsProperties::DocumentType>(),
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
    static abstract T FromRawUnchecked(Dictionary<string, JsonElement> properties);
}
