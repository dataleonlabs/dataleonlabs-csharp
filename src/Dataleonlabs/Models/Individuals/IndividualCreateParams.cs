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

namespace Dataleonlabs.Models.Individuals;

/// <summary>
/// Create a new individual
/// </summary>
public sealed record class IndividualCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    /// <summary>
    /// Unique identifier of the workspace where the individual is being registered.
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
    /// Personal information about the individual.
    /// </summary>
    public Person? Person
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("person", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Person?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["person"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional identifier for tracking the source system or integration from your system.
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
            this._bodyProperties["source_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Technical metadata related to the request or processing.
    /// </summary>
    public TechnicalData? TechnicalData
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("technical_data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<TechnicalData?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["technical_data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public IndividualCreateParams() { }

    public IndividualCreateParams(
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
    IndividualCreateParams(
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

    public static IndividualCreateParams FromRawUnchecked(
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

    public override System::Uri Url(IDataleonlabsClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/individuals")
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
/// Personal information about the individual.
/// </summary>
[JsonConverter(typeof(ModelConverter<Person>))]
public sealed record class Person : ModelBase, IFromRaw<Person>
{
    /// <summary>
    /// Date of birth in DD/MM/YYYY format.
    /// </summary>
    public string? Birthday
    {
        get
        {
            if (!this._properties.TryGetValue("birthday", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["birthday"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Email address of the individual.
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
            this._properties["email"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// First name of the individual.
    /// </summary>
    public string? FirstName
    {
        get
        {
            if (!this._properties.TryGetValue("first_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["first_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Gender of the individual (M for male, F for female).
    /// </summary>
    public ApiEnum<string, Gender>? Gender
    {
        get
        {
            if (!this._properties.TryGetValue("gender", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Gender>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["gender"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Last name (family name) of the individual.
    /// </summary>
    public string? LastName
    {
        get
        {
            if (!this._properties.TryGetValue("last_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["last_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Maiden name, if applicable.
    /// </summary>
    public string? MaidenName
    {
        get
        {
            if (!this._properties.TryGetValue("maiden_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["maiden_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Nationality of the individual (ISO 3166-1 alpha-3 country code).
    /// </summary>
    public string? Nationality
    {
        get
        {
            if (!this._properties.TryGetValue("nationality", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["nationality"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Phone number of the individual.
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
            this._properties["phone_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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

    public Person() { }

    public Person(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Person(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Person FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Gender of the individual (M for male, F for female).
/// </summary>
[JsonConverter(typeof(GenderConverter))]
public enum Gender
{
    M,
    F,
}

sealed class GenderConverter : JsonConverter<Gender>
{
    public override Gender Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "M" => Gender.M,
            "F" => Gender.F,
            _ => (Gender)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Gender value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Gender.M => "M",
                Gender.F => "F",
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
[JsonConverter(typeof(ModelConverter<TechnicalData>))]
public sealed record class TechnicalData : ModelBase, IFromRaw<TechnicalData>
{
    /// <summary>
    /// Flag indicating whether there are active research AML (Anti-Money Laundering)
    /// suspicions for the individual when you apply for a new entry or get an existing one.
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
            this._properties["active_aml_suspicions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// URL to call back upon completion of processing.
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
            this._properties["callback_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// URL for receive notifications about the processing state or status.
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
            this._properties["filtering_score_aml_suspicions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Preferred language for communication (e.g., "eng", "fra").
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
            this._properties["language"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("portal_steps", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ApiEnum<string, PortalStep>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
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

    public TechnicalData() { }

    public TechnicalData(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TechnicalData(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static TechnicalData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
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
