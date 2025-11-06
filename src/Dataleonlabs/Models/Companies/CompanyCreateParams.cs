using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;
using System = System;

namespace Dataleonlabs.Models.Companies;

/// <summary>
/// Create a new company
/// </summary>
public sealed record class CompanyCreateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// Main information about the company being registered.
    /// </summary>
    public required Company Company
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("company", out JsonElement element))
                throw new DataleonlabsInvalidDataException(
                    "'company' cannot be null",
                    new System::ArgumentOutOfRangeException("company", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Company>(element, ModelBase.SerializerOptions)
                ?? throw new DataleonlabsInvalidDataException(
                    "'company' cannot be null",
                    new System::ArgumentNullException("company")
                );
        }
        set
        {
            this.BodyProperties["company"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Unique identifier of the workspace in which the company is being created.
    /// </summary>
    public required string WorkspaceID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("workspace_id", out JsonElement element))
                throw new DataleonlabsInvalidDataException(
                    "'workspace_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "workspace_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DataleonlabsInvalidDataException(
                    "'workspace_id' cannot be null",
                    new System::ArgumentNullException("workspace_id")
                );
        }
        set
        {
            this.BodyProperties["workspace_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional identifier to track the origin of the request or integration from
    /// your system.
    /// </summary>
    public string? SourceID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("source_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["source_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Technical metadata and callback configuration.
    /// </summary>
    public TechnicalData? TechnicalData
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("technical_data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<TechnicalData?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["technical_data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override System::Uri Url(IDataleonlabsClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/companies")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request,
        IDataleonlabsClient client
    )
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// Main information about the company being registered.
/// </summary>
[JsonConverter(typeof(ModelConverter<Company>))]
public sealed record class Company : ModelBase, IFromRaw<Company>
{
    /// <summary>
    /// Legal name of the company.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new DataleonlabsInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new DataleonlabsInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Registered address of the company.
    /// </summary>
    public string? Address
    {
        get
        {
            if (!this.Properties.TryGetValue("address", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["address"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Commercial or trade name of the company, if different from the legal name.
    /// </summary>
    public string? CommercialName
    {
        get
        {
            if (!this.Properties.TryGetValue("commercial_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["commercial_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// ISO 3166-1 alpha-2 country code of company registration (e.g., "FR" for France).
    /// </summary>
    public string? Country
    {
        get
        {
            if (!this.Properties.TryGetValue("country", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["country"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Contact email address for the company.
    /// </summary>
    public string? Email
    {
        get
        {
            if (!this.Properties.TryGetValue("email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["email"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Employer Identification Number (EIN) or equivalent.
    /// </summary>
    public string? EmployerIdentificationNumber
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "employer_identification_number",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["employer_identification_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Legal structure of the company (e.g., SARL, SAS).
    /// </summary>
    public string? LegalForm
    {
        get
        {
            if (!this.Properties.TryGetValue("legal_form", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["legal_form"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Contact phone number for the company.
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            if (!this.Properties.TryGetValue("phone_number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["phone_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Date of official company registration in YYYY-MM-DD format.
    /// </summary>
    public string? RegistrationDate
    {
        get
        {
            if (!this.Properties.TryGetValue("registration_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["registration_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Official company registration identifier.
    /// </summary>
    public string? RegistrationID
    {
        get
        {
            if (!this.Properties.TryGetValue("registration_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["registration_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Declared share capital of the company, usually in euros.
    /// </summary>
    public string? ShareCapital
    {
        get
        {
            if (!this.Properties.TryGetValue("share_capital", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["share_capital"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Current status of the company (e.g., active, inactive).
    /// </summary>
    public string? Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// National tax identifier (e.g., VAT or TIN).
    /// </summary>
    public string? TaxIdentificationNumber
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_identification_number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["tax_identification_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Type of company, such as "main" or "affiliated".
    /// </summary>
    public string? Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Company’s official website URL.
    /// </summary>
    public string? WebsiteURL
    {
        get
        {
            if (!this.Properties.TryGetValue("website_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["website_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Name;
        _ = this.Address;
        _ = this.CommercialName;
        _ = this.Country;
        _ = this.Email;
        _ = this.EmployerIdentificationNumber;
        _ = this.LegalForm;
        _ = this.PhoneNumber;
        _ = this.RegistrationDate;
        _ = this.RegistrationID;
        _ = this.ShareCapital;
        _ = this.Status;
        _ = this.TaxIdentificationNumber;
        _ = this.Type;
        _ = this.WebsiteURL;
    }

    public Company() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Company(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Company FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Company(string name)
        : this()
    {
        this.Name = name;
    }
}

/// <summary>
/// Technical metadata and callback configuration.
/// </summary>
[JsonConverter(typeof(ModelConverter<TechnicalData>))]
public sealed record class TechnicalData : ModelBase, IFromRaw<TechnicalData>
{
    /// <summary>
    /// Flag indicating whether there are active research AML (Anti-Money Laundering)
    /// suspicions for the company when you apply for a new entry or get an existing one.
    /// </summary>
    public bool? ActiveAmlSuspicions
    {
        get
        {
            if (!this.Properties.TryGetValue("active_aml_suspicions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["active_aml_suspicions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// URL to receive a callback once the company is processed.
    /// </summary>
    public string? CallbackURL
    {
        get
        {
            if (!this.Properties.TryGetValue("callback_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["callback_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// URL to receive notifications about the processing state and status.
    /// </summary>
    public string? CallbackURLNotification
    {
        get
        {
            if (!this.Properties.TryGetValue("callback_url_notification", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["callback_url_notification"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Minimum filtering score (between 0 and 1) for AML suspicions to be considered.
    /// </summary>
    public float? FilteringScoreAmlSuspicions
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "filtering_score_aml_suspicions",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<float?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["filtering_score_aml_suspicions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Preferred language for responses or notifications (e.g., "eng", "fra").
    /// </summary>
    public string? Language
    {
        get
        {
            if (!this.Properties.TryGetValue("language", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["language"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of steps to include in the portal workflow.
    /// </summary>
    public List<ApiEnum<string, PortalStep>>? PortalSteps
    {
        get
        {
            if (!this.Properties.TryGetValue("portal_steps", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ApiEnum<string, PortalStep>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["portal_steps"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Flag indicating whether to include raw data in the response.
    /// </summary>
    public bool? RawData
    {
        get
        {
            if (!this.Properties.TryGetValue("raw_data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["raw_data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ActiveAmlSuspicions;
        _ = this.CallbackURL;
        _ = this.CallbackURLNotification;
        _ = this.FilteringScoreAmlSuspicions;
        _ = this.Language;
        foreach (var item in this.PortalSteps ?? [])
        {
            item.Validate();
        }
        _ = this.RawData;
    }

    public TechnicalData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TechnicalData(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TechnicalData FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(PortalStepConverter))]
public enum PortalStep
{
    IdentityVerification,
    DocumentSigning,
    ProofOfAddress,
    Selfie,
    FaceMatch,
}

sealed class PortalStepConverter : JsonConverter<PortalStep>
{
    public override PortalStep Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "identity_verification" => PortalStep.IdentityVerification,
            "document_signing" => PortalStep.DocumentSigning,
            "proof_of_address" => PortalStep.ProofOfAddress,
            "selfie" => PortalStep.Selfie,
            "face_match" => PortalStep.FaceMatch,
            _ => (PortalStep)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortalStep value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PortalStep.IdentityVerification => "identity_verification",
                PortalStep.DocumentSigning => "document_signing",
                PortalStep.ProofOfAddress => "proof_of_address",
                PortalStep.Selfie => "selfie",
                PortalStep.FaceMatch => "face_match",
                _ => throw new DataleonlabsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
