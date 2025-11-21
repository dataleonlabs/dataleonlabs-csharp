using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Core;

namespace Dataleonlabs.Models.Companies;

/// <summary>
/// Represents a risk assessment result, including a risk code, explanation, and a
/// confidence score.
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
            if (!this._rawData.TryGetValue("code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["code"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["reason"] = JsonSerializer.SerializeToElement(
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

    public override void Validate()
    {
        _ = this.Code;
        _ = this.Reason;
        _ = this.Score;
    }

    public Risk() { }

    public Risk(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Risk(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Risk FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}
