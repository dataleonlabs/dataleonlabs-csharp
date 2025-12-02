using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;

namespace Dataleonlabs.Models.Individuals;

/// <summary>
/// Update an individual by ID
/// </summary>
public sealed record class IndividualUpdateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? IndividualID { get; init; }

    /// <summary>
    /// Unique identifier of the workspace where the individual is being registered.
    /// </summary>
    public required string WorkspaceID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "workspace_id"); }
        init { ModelBase.Set(this._rawBodyData, "workspace_id", value); }
    }

    /// <summary>
    /// Personal information about the individual.
    /// </summary>
    public PersonModel? Person
    {
        get { return ModelBase.GetNullableClass<PersonModel>(this.RawBodyData, "person"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "person", value);
        }
    }

    /// <summary>
    /// Optional identifier for tracking the source system or integration from your system.
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
    /// Technical metadata related to the request or processing.
    /// </summary>
    public TechnicalDataModel? TechnicalData
    {
        get
        {
            return ModelBase.GetNullableClass<TechnicalDataModel>(
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

    public IndividualUpdateParams() { }

    public IndividualUpdateParams(
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
    IndividualUpdateParams(
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

    public static IndividualUpdateParams FromRawUnchecked(
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

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/individuals/{0}", this.IndividualID)
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
/// Personal information about the individual.
/// </summary>
[JsonConverter(typeof(ModelConverter<PersonModel, PersonModelFromRaw>))]
public sealed record class PersonModel : ModelBase
{
    /// <summary>
    /// Date of birth in DD/MM/YYYY format.
    /// </summary>
    public string? Birthday
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "birthday"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "birthday", value);
        }
    }

    /// <summary>
    /// Email address of the individual.
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
    /// First name of the individual.
    /// </summary>
    public string? FirstName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "first_name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "first_name", value);
        }
    }

    /// <summary>
    /// Gender of the individual (M for male, F for female).
    /// </summary>
    public ApiEnum<string, PersonModelGender>? Gender
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, PersonModelGender>>(
                this.RawData,
                "gender"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "gender", value);
        }
    }

    /// <summary>
    /// Last name (family name) of the individual.
    /// </summary>
    public string? LastName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "last_name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "last_name", value);
        }
    }

    /// <summary>
    /// Maiden name, if applicable.
    /// </summary>
    public string? MaidenName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "maiden_name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "maiden_name", value);
        }
    }

    /// <summary>
    /// Nationality of the individual (ISO 3166-1 alpha-3 country code).
    /// </summary>
    public string? Nationality
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "nationality"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "nationality", value);
        }
    }

    /// <summary>
    /// Phone number of the individual.
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

    public override void Validate()
    {
        _ = this.Birthday;
        _ = this.Email;
        _ = this.FirstName;
        this.Gender?.Validate();
        _ = this.LastName;
        _ = this.MaidenName;
        _ = this.Nationality;
        _ = this.PhoneNumber;
    }

    public PersonModel() { }

    public PersonModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PersonModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PersonModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PersonModelFromRaw : IFromRaw<PersonModel>
{
    public PersonModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PersonModel.FromRawUnchecked(rawData);
}

/// <summary>
/// Gender of the individual (M for male, F for female).
/// </summary>
[JsonConverter(typeof(PersonModelGenderConverter))]
public enum PersonModelGender
{
    M,
    F,
}

sealed class PersonModelGenderConverter : JsonConverter<PersonModelGender>
{
    public override PersonModelGender Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "M" => PersonModelGender.M,
            "F" => PersonModelGender.F,
            _ => (PersonModelGender)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PersonModelGender value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PersonModelGender.M => "M",
                PersonModelGender.F => "F",
                _ => throw new DataleonlabsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Technical metadata related to the request or processing.
/// </summary>
[JsonConverter(typeof(ModelConverter<TechnicalDataModel, TechnicalDataModelFromRaw>))]
public sealed record class TechnicalDataModel : ModelBase
{
    /// <summary>
    /// Flag indicating whether there are active research AML (Anti-Money Laundering)
    /// suspicions for the individual when you apply for a new entry or get an existing one.
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
    /// URL to call back upon completion of processing.
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
    /// URL for receive notifications about the processing state or status.
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
    /// Preferred language for communication (e.g., "eng", "fra").
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
    public IReadOnlyList<ApiEnum<string, PortalStepModel>>? PortalSteps
    {
        get
        {
            return ModelBase.GetNullableClass<List<ApiEnum<string, PortalStepModel>>>(
                this.RawData,
                "portal_steps"
            );
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
    public bool? RawData1
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
        _ = this.RawData1;
    }

    public TechnicalDataModel() { }

    public TechnicalDataModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TechnicalDataModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static TechnicalDataModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TechnicalDataModelFromRaw : IFromRaw<TechnicalDataModel>
{
    public TechnicalDataModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TechnicalDataModel.FromRawUnchecked(rawData);
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
        Type typeToConvert,
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
