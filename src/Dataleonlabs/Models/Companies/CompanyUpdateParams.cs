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
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CompanyID { get; init; }

    /// <summary>
    /// Main information about the company being registered.
    /// </summary>
    public required CompanyUpdateParamsCompany Company
    {
        get
        {
            return ModelBase.GetNotNullClass<CompanyUpdateParamsCompany>(
                this.RawBodyData,
                "company"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "company", value); }
    }

    /// <summary>
    /// Unique identifier of the workspace in which the company is being created.
    /// </summary>
    public required string WorkspaceID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "workspace_id"); }
        init { ModelBase.Set(this._rawBodyData, "workspace_id", value); }
    }

    /// <summary>
    /// Optional identifier to track the origin of the request or integration from
    /// your system.
    /// </summary>
    public string? SourceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "source_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "source_id", value);
        }
    }

    /// <summary>
    /// Technical metadata and callback configuration.
    /// </summary>
    public CompanyUpdateParamsTechnicalData? TechnicalData
    {
        get
        {
            return ModelBase.GetNullableClass<CompanyUpdateParamsTechnicalData>(
                this.RawBodyData,
                "technical_data"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "technical_data", value);
        }
    }

    public CompanyUpdateParams() { }

    public CompanyUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompanyUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static CompanyUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
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
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// Main information about the company being registered.
/// </summary>
[JsonConverter(
    typeof(ModelConverter<CompanyUpdateParamsCompany, CompanyUpdateParamsCompanyFromRaw>)
)]
public sealed record class CompanyUpdateParamsCompany : ModelBase
{
    /// <summary>
    /// Legal name of the company.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// Registered address of the company.
    /// </summary>
    public string? Address
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "address"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "address", value);
        }
    }

    /// <summary>
    /// Commercial or trade name of the company, if different from the legal name.
    /// </summary>
    public string? CommercialName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "commercial_name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "commercial_name", value);
        }
    }

    /// <summary>
    /// ISO 3166-1 alpha-2 country code of company registration (e.g., "FR" for France).
    /// </summary>
    public string? Country
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "country"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "country", value);
        }
    }

    /// <summary>
    /// Contact email address for the company.
    /// </summary>
    public string? Email
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "email"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "email", value);
        }
    }

    /// <summary>
    /// Employer Identification Number (EIN) or equivalent.
    /// </summary>
    public string? EmployerIdentificationNumber
    {
        get
        {
            return ModelBase.GetNullableClass<string>(
                this.RawData,
                "employer_identification_number"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "employer_identification_number", value);
        }
    }

    /// <summary>
    /// Legal structure of the company (e.g., SARL, SAS).
    /// </summary>
    public string? LegalForm
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "legal_form"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "legal_form", value);
        }
    }

    /// <summary>
    /// Contact phone number for the company.
    /// </summary>
    public string? PhoneNumber
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "phone_number"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "phone_number", value);
        }
    }

    /// <summary>
    /// Date of official company registration in YYYY-MM-DD format.
    /// </summary>
    public string? RegistrationDate
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "registration_date"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "registration_date", value);
        }
    }

    /// <summary>
    /// Official company registration identifier.
    /// </summary>
    public string? RegistrationID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "registration_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "registration_id", value);
        }
    }

    /// <summary>
    /// Declared share capital of the company, usually in euros.
    /// </summary>
    public string? ShareCapital
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "share_capital"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "share_capital", value);
        }
    }

    /// <summary>
    /// Current status of the company (e.g., active, inactive).
    /// </summary>
    public string? Status
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "status"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "status", value);
        }
    }

    /// <summary>
    /// National tax identifier (e.g., VAT or TIN).
    /// </summary>
    public string? TaxIdentificationNumber
    {
        get
        {
            return ModelBase.GetNullableClass<string>(this.RawData, "tax_identification_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "tax_identification_number", value);
        }
    }

    /// <summary>
    /// Type of company, such as "main" or "affiliated".
    /// </summary>
    public string? Type
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "type"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "type", value);
        }
    }

    /// <summary>
    /// Company’s official website URL.
    /// </summary>
    public string? WebsiteURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "website_url"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "website_url", value);
        }
    }

    /// <inheritdoc/>
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

    public CompanyUpdateParamsCompany() { }

    public CompanyUpdateParamsCompany(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompanyUpdateParamsCompany(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CompanyUpdateParamsCompanyFromRaw.FromRawUnchecked"/>
    public static CompanyUpdateParamsCompany FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CompanyUpdateParamsCompany(string name)
        : this()
    {
        this.Name = name;
    }
}

class CompanyUpdateParamsCompanyFromRaw : IFromRaw<CompanyUpdateParamsCompany>
{
    /// <inheritdoc/>
    public CompanyUpdateParamsCompany FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CompanyUpdateParamsCompany.FromRawUnchecked(rawData);
}

/// <summary>
/// Technical metadata and callback configuration.
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        CompanyUpdateParamsTechnicalData,
        CompanyUpdateParamsTechnicalDataFromRaw
    >)
)]
public sealed record class CompanyUpdateParamsTechnicalData : ModelBase
{
    /// <summary>
    /// Flag indicating whether there are active research AML (Anti-Money Laundering)
    /// suspicions for the company when you apply for a new entry or get an existing one.
    /// </summary>
    public bool? ActiveAmlSuspicions
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "active_aml_suspicions"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "active_aml_suspicions", value);
        }
    }

    /// <summary>
    /// URL to receive a callback once the company is processed.
    /// </summary>
    public string? CallbackURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "callback_url"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "callback_url", value);
        }
    }

    /// <summary>
    /// URL to receive notifications about the processing state and status.
    /// </summary>
    public string? CallbackURLNotification
    {
        get
        {
            return ModelBase.GetNullableClass<string>(this.RawData, "callback_url_notification");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "callback_url_notification", value);
        }
    }

    /// <summary>
    /// Minimum filtering score (between 0 and 1) for AML suspicions to be considered.
    /// </summary>
    public float? FilteringScoreAmlSuspicions
    {
        get
        {
            return ModelBase.GetNullableStruct<float>(
                this.RawData,
                "filtering_score_aml_suspicions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "filtering_score_aml_suspicions", value);
        }
    }

    /// <summary>
    /// Preferred language for responses or notifications (e.g., "eng", "fra").
    /// </summary>
    public string? Language
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "language"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "language", value);
        }
    }

    /// <summary>
    /// List of steps to include in the portal workflow.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, CompanyUpdateParamsTechnicalDataPortalStep>>? PortalSteps
    {
        get
        {
            return ModelBase.GetNullableClass<
                List<ApiEnum<string, CompanyUpdateParamsTechnicalDataPortalStep>>
            >(this.RawData, "portal_steps");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "portal_steps", value);
        }
    }

    /// <summary>
    /// Flag indicating whether to include raw data in the response.
    /// </summary>
    public bool? RawDataValue
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "raw_data"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "raw_data", value);
        }
    }

    /// <inheritdoc/>
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
        _ = this.RawDataValue;
    }

    public CompanyUpdateParamsTechnicalData() { }

    public CompanyUpdateParamsTechnicalData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompanyUpdateParamsTechnicalData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CompanyUpdateParamsTechnicalDataFromRaw.FromRawUnchecked"/>
    public static CompanyUpdateParamsTechnicalData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CompanyUpdateParamsTechnicalDataFromRaw : IFromRaw<CompanyUpdateParamsTechnicalData>
{
    /// <inheritdoc/>
    public CompanyUpdateParamsTechnicalData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CompanyUpdateParamsTechnicalData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CompanyUpdateParamsTechnicalDataPortalStepConverter))]
public enum CompanyUpdateParamsTechnicalDataPortalStep
{
    IdentityVerification,
    DocumentSigning,
    ProofOfAddress,
    Selfie,
    FaceMatch,
}

sealed class CompanyUpdateParamsTechnicalDataPortalStepConverter
    : JsonConverter<CompanyUpdateParamsTechnicalDataPortalStep>
{
    public override CompanyUpdateParamsTechnicalDataPortalStep Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "identity_verification" =>
                CompanyUpdateParamsTechnicalDataPortalStep.IdentityVerification,
            "document_signing" => CompanyUpdateParamsTechnicalDataPortalStep.DocumentSigning,
            "proof_of_address" => CompanyUpdateParamsTechnicalDataPortalStep.ProofOfAddress,
            "selfie" => CompanyUpdateParamsTechnicalDataPortalStep.Selfie,
            "face_match" => CompanyUpdateParamsTechnicalDataPortalStep.FaceMatch,
            _ => (CompanyUpdateParamsTechnicalDataPortalStep)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CompanyUpdateParamsTechnicalDataPortalStep value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CompanyUpdateParamsTechnicalDataPortalStep.IdentityVerification =>
                    "identity_verification",
                CompanyUpdateParamsTechnicalDataPortalStep.DocumentSigning => "document_signing",
                CompanyUpdateParamsTechnicalDataPortalStep.ProofOfAddress => "proof_of_address",
                CompanyUpdateParamsTechnicalDataPortalStep.Selfie => "selfie",
                CompanyUpdateParamsTechnicalDataPortalStep.FaceMatch => "face_match",
                _ => throw new DataleonlabsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
