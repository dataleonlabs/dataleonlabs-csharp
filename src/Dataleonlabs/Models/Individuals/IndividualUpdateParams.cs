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
    public IndividualUpdateParamsPerson? Person
    {
        get
        {
            return ModelBase.GetNullableClass<IndividualUpdateParamsPerson>(
                this.RawBodyData,
                "person"
            );
        }
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
    public IndividualUpdateParamsTechnicalData? TechnicalData
    {
        get
        {
            return ModelBase.GetNullableClass<IndividualUpdateParamsTechnicalData>(
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
[JsonConverter(
    typeof(ModelConverter<IndividualUpdateParamsPerson, IndividualUpdateParamsPersonFromRaw>)
)]
public sealed record class IndividualUpdateParamsPerson : ModelBase
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
    public ApiEnum<string, IndividualUpdateParamsPersonGender>? Gender
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, IndividualUpdateParamsPersonGender>>(
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

    public IndividualUpdateParamsPerson() { }

    public IndividualUpdateParamsPerson(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IndividualUpdateParamsPerson(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static IndividualUpdateParamsPerson FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IndividualUpdateParamsPersonFromRaw : IFromRaw<IndividualUpdateParamsPerson>
{
    public IndividualUpdateParamsPerson FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IndividualUpdateParamsPerson.FromRawUnchecked(rawData);
}

/// <summary>
/// Gender of the individual (M for male, F for female).
/// </summary>
[JsonConverter(typeof(IndividualUpdateParamsPersonGenderConverter))]
public enum IndividualUpdateParamsPersonGender
{
    M,
    F,
}

sealed class IndividualUpdateParamsPersonGenderConverter
    : JsonConverter<IndividualUpdateParamsPersonGender>
{
    public override IndividualUpdateParamsPersonGender Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "M" => IndividualUpdateParamsPersonGender.M,
            "F" => IndividualUpdateParamsPersonGender.F,
            _ => (IndividualUpdateParamsPersonGender)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IndividualUpdateParamsPersonGender value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IndividualUpdateParamsPersonGender.M => "M",
                IndividualUpdateParamsPersonGender.F => "F",
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
[JsonConverter(
    typeof(ModelConverter<
        IndividualUpdateParamsTechnicalData,
        IndividualUpdateParamsTechnicalDataFromRaw
    >)
)]
public sealed record class IndividualUpdateParamsTechnicalData : ModelBase
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
    public IReadOnlyList<
        ApiEnum<string, IndividualUpdateParamsTechnicalDataPortalStep>
    >? PortalSteps
    {
        get
        {
            return ModelBase.GetNullableClass<
                List<ApiEnum<string, IndividualUpdateParamsTechnicalDataPortalStep>>
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

    public IndividualUpdateParamsTechnicalData() { }

    public IndividualUpdateParamsTechnicalData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IndividualUpdateParamsTechnicalData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static IndividualUpdateParamsTechnicalData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IndividualUpdateParamsTechnicalDataFromRaw : IFromRaw<IndividualUpdateParamsTechnicalData>
{
    public IndividualUpdateParamsTechnicalData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IndividualUpdateParamsTechnicalData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(IndividualUpdateParamsTechnicalDataPortalStepConverter))]
public enum IndividualUpdateParamsTechnicalDataPortalStep
{
    IdentityVerification,
    DocumentSigning,
    ProofOfAddress,
    Selfie,
    FaceMatch,
}

sealed class IndividualUpdateParamsTechnicalDataPortalStepConverter
    : JsonConverter<IndividualUpdateParamsTechnicalDataPortalStep>
{
    public override IndividualUpdateParamsTechnicalDataPortalStep Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "identity_verification" =>
                IndividualUpdateParamsTechnicalDataPortalStep.IdentityVerification,
            "document_signing" => IndividualUpdateParamsTechnicalDataPortalStep.DocumentSigning,
            "proof_of_address" => IndividualUpdateParamsTechnicalDataPortalStep.ProofOfAddress,
            "selfie" => IndividualUpdateParamsTechnicalDataPortalStep.Selfie,
            "face_match" => IndividualUpdateParamsTechnicalDataPortalStep.FaceMatch,
            _ => (IndividualUpdateParamsTechnicalDataPortalStep)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IndividualUpdateParamsTechnicalDataPortalStep value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IndividualUpdateParamsTechnicalDataPortalStep.IdentityVerification =>
                    "identity_verification",
                IndividualUpdateParamsTechnicalDataPortalStep.DocumentSigning => "document_signing",
                IndividualUpdateParamsTechnicalDataPortalStep.ProofOfAddress => "proof_of_address",
                IndividualUpdateParamsTechnicalDataPortalStep.Selfie => "selfie",
                IndividualUpdateParamsTechnicalDataPortalStep.FaceMatch => "face_match",
                _ => throw new DataleonlabsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
