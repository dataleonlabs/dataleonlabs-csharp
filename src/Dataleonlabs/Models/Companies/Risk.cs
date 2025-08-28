using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dataleonlabs.Models.Companies;

/// <summary>
/// Represents a risk assessment result, including a risk code, explanation, and
/// a confidence score.
/// </summary>
[JsonConverter(typeof(ModelConverter<Risk>))]
public sealed record class Risk : ModelBase, IFromRaw<Risk>
{
    /// <summary>
    /// Risk category or code identifier.
    /// </summary>
    public string? Code
    {
        get
        {
            if (!this.Properties.TryGetValue("code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Explanation or justification for the assigned risk.
    /// </summary>
    public string? Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Numeric risk score between 0.0 and 1.0 indicating severity or confidence.
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

    public override void Validate()
    {
        _ = this.Code;
        _ = this.Reason;
        _ = this.Score;
    }

    public Risk() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Risk(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Risk FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
