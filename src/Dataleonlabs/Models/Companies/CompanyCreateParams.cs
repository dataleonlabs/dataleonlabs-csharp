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
/// Create a new company
/// </summary>
public sealed record class CompanyCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Main information about the company being registered.
    /// </summary>
    public required Company Company
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Company>("company");
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
    public TechnicalData? TechnicalData
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<TechnicalData>("technical_data");
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

    public CompanyCreateParams() { }

    public CompanyCreateParams(CompanyCreateParams companyCreateParams)
        : base(companyCreateParams)
    {
        this._rawBodyData = new(companyCreateParams._rawBodyData);
    }

    public CompanyCreateParams(
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
    CompanyCreateParams(
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
    public static CompanyCreateParams FromRawUnchecked(
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
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/companies")
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
}

/// <summary>
/// Main information about the company being registered.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Company, CompanyFromRaw>))]
public sealed record class Company : JsonModel
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

    public Company() { }

    public Company(Company company)
        : base(company) { }

    public Company(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Company(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CompanyFromRaw.FromRawUnchecked"/>
    public static Company FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Company(string name)
        : this()
    {
        this.Name = name;
    }
}

class CompanyFromRaw : IFromRawJson<Company>
{
    /// <inheritdoc/>
    public Company FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Company.FromRawUnchecked(rawData);
}

/// <summary>
/// Technical metadata and callback configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TechnicalData, TechnicalDataFromRaw>))]
public sealed record class TechnicalData : JsonModel
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
    public IReadOnlyList<ApiEnum<string, PortalStep>>? PortalSteps
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, PortalStep>>>(
                "portal_steps"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, PortalStep>>?>(
                "portal_steps",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

    public TechnicalData() { }

    public TechnicalData(TechnicalData technicalData)
        : base(technicalData) { }

    public TechnicalData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TechnicalData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TechnicalDataFromRaw.FromRawUnchecked"/>
    public static TechnicalData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TechnicalDataFromRaw : IFromRawJson<TechnicalData>
{
    /// <inheritdoc/>
    public TechnicalData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TechnicalData.FromRawUnchecked(rawData);
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
