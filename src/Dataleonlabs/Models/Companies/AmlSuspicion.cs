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
[JsonConverter(typeof(ModelConverter<AmlSuspicion, AmlSuspicionFromRaw>))]
public sealed record class AmlSuspicion : ModelBase
{
    /// <summary>
    /// Human-readable description or title for the suspicious finding.
    /// </summary>
    public string? Caption
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "caption"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "caption", value);
        }
    }

    /// <summary>
    /// Country associated with the suspicion (ISO 3166-1 alpha-2 code).
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
    /// Gender associated with the suspicion, if applicable.
    /// </summary>
    public string? Gender
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "gender"); }
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
    /// Nature of the relationship between the entity and the suspicious activity
    /// (e.g., "linked", "associated").
    /// </summary>
    public string? Relation
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "relation"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "relation", value);
        }
    }

    /// <summary>
    /// Version of the evaluation schema or rule engine used.
    /// </summary>
    public string? Schema
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "schema"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "schema", value);
        }
    }

    /// <summary>
    /// Risk score between 0.0 and 1 indicating the severity of the suspicion.
    /// </summary>
    public float? Score
    {
        get { return ModelBase.GetNullableStruct<float>(this.RawData, "score"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "score", value);
        }
    }

    /// <summary>
    /// Source system or service providing this suspicion.
    /// </summary>
    public string? Source
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "source"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "source", value);
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
            return ModelBase.GetNullableClass<ApiEnum<string, AmlSuspicionStatus>>(
                this.RawData,
                "status"
            );
        }
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
    /// Category of the suspicion. Possible values: "crime", "sanction", "pep", "adverse_news",
    /// "other".
    /// </summary>
    public ApiEnum<string, global::Dataleonlabs.Models.Companies.Type>? Type
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, global::Dataleonlabs.Models.Companies.Type>
            >(this.RawData, "type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "type", value);
        }
    }

    /// <inheritdoc/>
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

    public AmlSuspicion(AmlSuspicion amlSuspicion)
        : base(amlSuspicion) { }

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

    /// <inheritdoc cref="AmlSuspicionFromRaw.FromRawUnchecked"/>
    public static AmlSuspicion FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AmlSuspicionFromRaw : IFromRaw<AmlSuspicion>
{
    /// <inheritdoc/>
    public AmlSuspicion FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AmlSuspicion.FromRawUnchecked(rawData);
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
