using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;
using System = System;

namespace Dataleonlabs.Models.Companies;

/// <summary>
/// Represents a record of suspicion raised during Anti-Money Laundering (AML) screening.
/// Includes metadata such as risk score, origin, and linked watchlist types.
/// </summary>
[JsonConverter(typeof(ModelConverter<AmlSuspicion>))]
public sealed record class AmlSuspicion : ModelBase, IFromRaw<AmlSuspicion>
{
    /// <summary>
    /// Human-readable description or title for the suspicious finding.
    /// </summary>
    public string? Caption
    {
        get
        {
            if (!this._rawData.TryGetValue("caption", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["caption"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Country associated with the suspicion (ISO 3166-1 alpha-2 code).
    /// </summary>
    public string? Country
    {
        get
        {
            if (!this._rawData.TryGetValue("country", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["country"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Gender associated with the suspicion, if applicable.
    /// </summary>
    public string? Gender
    {
        get
        {
            if (!this._rawData.TryGetValue("gender", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["gender"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Nature of the relationship between the entity and the suspicious activity
    /// (e.g., "linked", "associated").
    /// </summary>
    public string? Relation
    {
        get
        {
            if (!this._rawData.TryGetValue("relation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["relation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Version of the evaluation schema or rule engine used.
    /// </summary>
    public string? Schema
    {
        get
        {
            if (!this._rawData.TryGetValue("schema", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["schema"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Risk score between 0.0 and 1 indicating the severity of the suspicion.
    /// </summary>
    public float? Score
    {
        get
        {
            if (!this._rawData.TryGetValue("score", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<float?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["score"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Source system or service providing this suspicion.
    /// </summary>
    public string? Source
    {
        get
        {
            if (!this._rawData.TryGetValue("source", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Status of the suspicion review process. Possible values: "true_positive",
    /// "false_positive", "pending".
    /// </summary>
    public ApiEnum<string, AmlSuspicionStatus>? Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, AmlSuspicionStatus>?>(
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

            this._rawData["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Category of the suspicion. Possible values: "crime", "sanction", "pep", "adverse_news",
    /// "other".
    /// </summary>
    public ApiEnum<string, global::Dataleonlabs.Models.Companies.Type>? Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                global::Dataleonlabs.Models.Companies.Type
            >?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Caption;
        _ = this.Country;
        _ = this.Gender;
        _ = this.Relation;
        _ = this.Schema;
        _ = this.Score;
        _ = this.Source;
        this.Status?.Validate();
        this.Type?.Validate();
    }

    public AmlSuspicion() { }

    public AmlSuspicion(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AmlSuspicion(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AmlSuspicion FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

/// <summary>
/// Status of the suspicion review process. Possible values: "true_positive", "false_positive",
/// "pending".
/// </summary>
[JsonConverter(typeof(AmlSuspicionStatusConverter))]
public enum AmlSuspicionStatus
{
    TruePositive,
    FalsePositive,
    Pending,
}

sealed class AmlSuspicionStatusConverter : JsonConverter<AmlSuspicionStatus>
{
    public override AmlSuspicionStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true_positive" => AmlSuspicionStatus.TruePositive,
            "false_positive" => AmlSuspicionStatus.FalsePositive,
            "pending" => AmlSuspicionStatus.Pending,
            _ => (AmlSuspicionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AmlSuspicionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AmlSuspicionStatus.TruePositive => "true_positive",
                AmlSuspicionStatus.FalsePositive => "false_positive",
                AmlSuspicionStatus.Pending => "pending",
                _ => throw new DataleonlabsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Category of the suspicion. Possible values: "crime", "sanction", "pep", "adverse_news",
/// "other".
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Crime,
    Sanction,
    Pep,
    AdverseNews,
    Other,
}

sealed class TypeConverter : JsonConverter<global::Dataleonlabs.Models.Companies.Type>
{
    public override global::Dataleonlabs.Models.Companies.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "crime" => global::Dataleonlabs.Models.Companies.Type.Crime,
            "sanction" => global::Dataleonlabs.Models.Companies.Type.Sanction,
            "pep" => global::Dataleonlabs.Models.Companies.Type.Pep,
            "adverse_news" => global::Dataleonlabs.Models.Companies.Type.AdverseNews,
            "other" => global::Dataleonlabs.Models.Companies.Type.Other,
            _ => (global::Dataleonlabs.Models.Companies.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Dataleonlabs.Models.Companies.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Dataleonlabs.Models.Companies.Type.Crime => "crime",
                global::Dataleonlabs.Models.Companies.Type.Sanction => "sanction",
                global::Dataleonlabs.Models.Companies.Type.Pep => "pep",
                global::Dataleonlabs.Models.Companies.Type.AdverseNews => "adverse_news",
                global::Dataleonlabs.Models.Companies.Type.Other => "other",
                _ => throw new DataleonlabsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
