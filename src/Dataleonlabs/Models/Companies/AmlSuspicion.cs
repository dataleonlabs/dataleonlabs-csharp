using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Models.Companies.AmlSuspicionProperties;

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
            if (!this.Properties.TryGetValue("caption", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["caption"] = JsonSerializer.SerializeToElement(
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
    /// Gender associated with the suspicion, if applicable.
    /// </summary>
    public string? Gender
    {
        get
        {
            if (!this.Properties.TryGetValue("gender", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["gender"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("relation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["relation"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("schema", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["schema"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("score", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<float?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["score"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("source", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Status of the suspicion review process. Possible values: "true_positive",
    /// "false_positive", "pending".
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Status>?>(
                element,
                ModelBase.SerializerOptions
            );
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
    /// Category of the suspicion. Possible values: "crime", "sanction", "pep", "adverse_news",
    /// "other".
    /// </summary>
    public ApiEnum<string, Type>? Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Type>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AmlSuspicion(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AmlSuspicion FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
