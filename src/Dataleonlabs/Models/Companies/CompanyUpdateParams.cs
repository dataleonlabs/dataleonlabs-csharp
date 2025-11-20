using System.Collections.Frozen;
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
/// Update a company by ID
/// </summary>
public sealed record class CompanyUpdateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    public string? CompanyID { get; init; }

    /// <summary>
    /// Main information about the company being registered.
    /// </summary>
    public required CompanyModel Company
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("company", out JsonElement element))
                throw new DataleonlabsInvalidDataException(
                    "'company' cannot be null",
                    new System::ArgumentOutOfRangeException("company", "Missing required argument")
                );

            return JsonSerializer.Deserialize<CompanyModel>(element, ModelBase.SerializerOptions)
                ?? throw new DataleonlabsInvalidDataException(
                    "'company' cannot be null",
                    new System::ArgumentNullException("company")
                );
        }
        init
        {
            this._bodyProperties["company"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("workspace_id", out JsonElement element))
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
        init
        {
            this._bodyProperties["workspace_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("source_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._bodyProperties["source_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Technical metadata and callback configuration.
    /// </summary>
    public TechnicalDataModel? TechnicalData
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("technical_data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<TechnicalDataModel?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._bodyProperties["technical_data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public CompanyUpdateParams() { }

    public CompanyUpdateParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompanyUpdateParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static CompanyUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/companies/{0}", this.CompanyID)
        )
        {
            Query = this.QueryString(options),
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

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// Main information about the company being registered.
/// </summary>
[JsonConverter(typeof(ModelConverter<CompanyModel>))]
public sealed record class CompanyModel : ModelBase, IFromRaw<CompanyModel>
{
    /// <summary>
    /// Legal name of the company.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
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
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("address", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["address"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("commercial_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["commercial_name"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("country", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["country"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["email"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
                    "employer_identification_number",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["employer_identification_number"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("legal_form", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["legal_form"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("phone_number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["phone_number"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("registration_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["registration_date"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("registration_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["registration_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("share_capital", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["share_capital"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["status"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("tax_identification_number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["tax_identification_number"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["type"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("website_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["website_url"] = JsonSerializer.SerializeToElement(
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

    public CompanyModel() { }

    public CompanyModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompanyModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static CompanyModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public CompanyModel(string name)
        : this()
    {
        this.Name = name;
    }
}

/// <summary>
/// Technical metadata and callback configuration.
/// </summary>
[JsonConverter(typeof(ModelConverter<TechnicalDataModel>))]
public sealed record class TechnicalDataModel : ModelBase, IFromRaw<TechnicalDataModel>
{
    /// <summary>
    /// Flag indicating whether there are active research AML (Anti-Money Laundering)
    /// suspicions for the company when you apply for a new entry or get an existing one.
    /// </summary>
    public bool? ActiveAmlSuspicions
    {
        get
        {
            if (!this._properties.TryGetValue("active_aml_suspicions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["active_aml_suspicions"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("callback_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["callback_url"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("callback_url_notification", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["callback_url_notification"] = JsonSerializer.SerializeToElement(
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
                !this._properties.TryGetValue(
                    "filtering_score_aml_suspicions",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<float?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["filtering_score_aml_suspicions"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("language", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["language"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of steps to include in the portal workflow.
    /// </summary>
    public List<ApiEnum<string, PortalStepModel>>? PortalSteps
    {
        get
        {
            if (!this._properties.TryGetValue("portal_steps", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ApiEnum<string, PortalStepModel>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["portal_steps"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("raw_data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["raw_data"] = JsonSerializer.SerializeToElement(
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

    public TechnicalDataModel() { }

    public TechnicalDataModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TechnicalDataModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static TechnicalDataModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(PortalStepModelConverter))]
public enum PortalStepModel
{
    IdentityVerification,
    DocumentSigning,
    ProofOfAddress,
    Selfie,
    FaceMatch,
}

sealed class PortalStepModelConverter : JsonConverter<PortalStepModel>
{
    public override PortalStepModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "identity_verification" => PortalStepModel.IdentityVerification,
            "document_signing" => PortalStepModel.DocumentSigning,
            "proof_of_address" => PortalStepModel.ProofOfAddress,
            "selfie" => PortalStepModel.Selfie,
            "face_match" => PortalStepModel.FaceMatch,
            _ => (PortalStepModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortalStepModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PortalStepModel.IdentityVerification => "identity_verification",
                PortalStepModel.DocumentSigning => "document_signing",
                PortalStepModel.ProofOfAddress => "proof_of_address",
                PortalStepModel.Selfie => "selfie",
                PortalStepModel.FaceMatch => "face_match",
                _ => throw new DataleonlabsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
