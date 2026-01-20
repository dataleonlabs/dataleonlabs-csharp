using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CompanyUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<CompanyUpdateParamsCompany>("company");
        }
        init { this._rawBodyData.Set("company", value); }
    }

    /// <summary>
    /// Unique identifier of the workspace in which the company is being created.
    /// </summary>
    public required string WorkspaceID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("workspace_id");
        }
        init { this._rawBodyData.Set("workspace_id", value); }
    }

    /// <summary>
    /// Optional identifier to track the origin of the request or integration from
    /// your system.
    /// </summary>
    public string? SourceID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("source_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("source_id", value);
        }
    }

    /// <summary>
    /// Technical metadata and callback configuration.
    /// </summary>
    public CompanyUpdateParamsTechnicalData? TechnicalData
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CompanyUpdateParamsTechnicalData>(
                "technical_data"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("technical_data", value);
        }
    }

    public CompanyUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CompanyUpdateParams(CompanyUpdateParams companyUpdateParams)
        : base(companyUpdateParams)
    {
        this.CompanyID = companyUpdateParams.CompanyID;

        this._rawBodyData = new(companyUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CompanyUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompanyUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
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

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["CompanyID"] = this.CompanyID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CompanyUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CompanyID?.Equals(other.CompanyID) ?? other.CompanyID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
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

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Main information about the company being registered.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CompanyUpdateParamsCompany, CompanyUpdateParamsCompanyFromRaw>)
)]
public sealed record class CompanyUpdateParamsCompany : JsonModel
{
    /// <summary>
    /// Legal name of the company.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Registered address of the company.
    /// </summary>
    public string? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address", value);
        }
    }

    /// <summary>
    /// Commercial or trade name of the company, if different from the legal name.
    /// </summary>
    public string? CommercialName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("commercial_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("commercial_name", value);
        }
    }

    /// <summary>
    /// ISO 3166-1 alpha-2 country code of company registration (e.g., "FR" for France).
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("country", value);
        }
    }

    /// <summary>
    /// Contact email address for the company.
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <summary>
    /// Employer Identification Number (EIN) or equivalent.
    /// </summary>
    public string? EmployerIdentificationNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("employer_identification_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("employer_identification_number", value);
        }
    }

    /// <summary>
    /// Legal structure of the company (e.g., SARL, SAS).
    /// </summary>
    public string? LegalForm
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("legal_form");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("legal_form", value);
        }
    }

    /// <summary>
    /// Contact phone number for the company.
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <summary>
    /// Date of official company registration in YYYY-MM-DD format.
    /// </summary>
    public string? RegistrationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("registration_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("registration_date", value);
        }
    }

    /// <summary>
    /// Official company registration identifier.
    /// </summary>
    public string? RegistrationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("registration_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("registration_id", value);
        }
    }

    /// <summary>
    /// Declared share capital of the company, usually in euros.
    /// </summary>
    public string? ShareCapital
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("share_capital");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("share_capital", value);
        }
    }

    /// <summary>
    /// Current status of the company (e.g., active, inactive).
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// National tax identifier (e.g., VAT or TIN).
    /// </summary>
    public string? TaxIdentificationNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tax_identification_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tax_identification_number", value);
        }
    }

    /// <summary>
    /// Type of company, such as "main" or "affiliated".
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// Company’s official website URL.
    /// </summary>
    public string? WebsiteUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("website_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("website_url", value);
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
        _ = this.WebsiteUrl;
    }

    public CompanyUpdateParamsCompany() { }

    public CompanyUpdateParamsCompany(CompanyUpdateParamsCompany companyUpdateParamsCompany)
        : base(companyUpdateParamsCompany) { }

    public CompanyUpdateParamsCompany(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompanyUpdateParamsCompany(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class CompanyUpdateParamsCompanyFromRaw : IFromRawJson<CompanyUpdateParamsCompany>
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
    typeof(JsonModelConverter<
        CompanyUpdateParamsTechnicalData,
        CompanyUpdateParamsTechnicalDataFromRaw
    >)
)]
public sealed record class CompanyUpdateParamsTechnicalData : JsonModel
{
    /// <summary>
    /// Flag indicating whether there are active research AML (Anti-Money Laundering)
    /// suspicions for the company when you apply for a new entry or get an existing one.
    /// </summary>
    public bool? ActiveAmlSuspicions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("active_aml_suspicions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("active_aml_suspicions", value);
        }
    }

    /// <summary>
    /// URL to receive a callback once the company is processed.
    /// </summary>
    public string? CallbackUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("callback_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("callback_url", value);
        }
    }

    /// <summary>
    /// URL to receive notifications about the processing state and status.
    /// </summary>
    public string? CallbackUrlNotification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("callback_url_notification");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("callback_url_notification", value);
        }
    }

    /// <summary>
    /// Minimum filtering score (between 0 and 1) for AML suspicions to be considered.
    /// </summary>
    public float? FilteringScoreAmlSuspicions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("filtering_score_aml_suspicions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("filtering_score_aml_suspicions", value);
        }
    }

    /// <summary>
    /// Preferred language for responses or notifications (e.g., "eng", "fra").
    /// </summary>
    public string? Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("language");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("language", value);
        }
    }

    /// <summary>
    /// List of steps to include in the portal workflow.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, CompanyUpdateParamsTechnicalDataPortalStep>>? PortalSteps
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, CompanyUpdateParamsTechnicalDataPortalStep>>
            >("portal_steps");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<
                ApiEnum<string, CompanyUpdateParamsTechnicalDataPortalStep>
            >?>("portal_steps", value == null ? null : ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Flag indicating whether to include raw data in the response.
    /// </summary>
    public bool? RawDataValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("raw_data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("raw_data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActiveAmlSuspicions;
        _ = this.CallbackUrl;
        _ = this.CallbackUrlNotification;
        _ = this.FilteringScoreAmlSuspicions;
        _ = this.Language;
        foreach (var item in this.PortalSteps ?? [])
        {
            item.Validate();
        }
        _ = this.RawDataValue;
    }

    public CompanyUpdateParamsTechnicalData() { }

    public CompanyUpdateParamsTechnicalData(
        CompanyUpdateParamsTechnicalData companyUpdateParamsTechnicalData
    )
        : base(companyUpdateParamsTechnicalData) { }

    public CompanyUpdateParamsTechnicalData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompanyUpdateParamsTechnicalData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class CompanyUpdateParamsTechnicalDataFromRaw : IFromRawJson<CompanyUpdateParamsTechnicalData>
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
