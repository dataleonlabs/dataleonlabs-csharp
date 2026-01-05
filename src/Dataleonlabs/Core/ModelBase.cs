using System.Text.Json;
using Dataleonlabs.Exceptions;
using Dataleonlabs.Models.Companies;
using Dataleonlabs.Models.Companies.Documents;
using Documents = Dataleonlabs.Models.Individuals.Documents;
using Individuals = Dataleonlabs.Models.Individuals;

namespace Dataleonlabs.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums and unions do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, AmlSuspicionStatus>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, Source>(),
            new ApiEnumConverter<string, MemberType>(),
            new ApiEnumConverter<string, CompanyTechnicalDataPortalStep>(),
            new ApiEnumConverter<string, PortalStep>(),
            new ApiEnumConverter<string, CompanyUpdateParamsTechnicalDataPortalStep>(),
            new ApiEnumConverter<string, State>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, DocumentType>(),
            new ApiEnumConverter<string, Individuals::Gender>(),
            new ApiEnumConverter<string, Individuals::PortalStep>(),
            new ApiEnumConverter<string, Individuals::IndividualUpdateParamsPersonGender>(),
            new ApiEnumConverter<
                string,
                Individuals::IndividualUpdateParamsTechnicalDataPortalStep
            >(),
            new ApiEnumConverter<string, Individuals::State>(),
            new ApiEnumConverter<string, Individuals::Status>(),
            new ApiEnumConverter<string, Documents::DocumentType>(),
        },
    };

    private protected static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="DataleonlabsInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
