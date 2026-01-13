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
[JsonConverter(typeof(JsonModelConverter<Risk, RiskFromRaw>))]
public sealed record class Risk : JsonModel
{
    /// <summary>
    /// Risk category or code identifier.
    /// </summary>
    public string? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    /// <summary>
    /// Explanation or justification for the assigned risk.
    /// </summary>
    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reason", value);
        }
    }

    /// <summary>
    /// Numeric risk score between 0.0 and 1.0 indicating severity or confidence.
    /// </summary>
    public float? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("score", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Reason;
        _ = this.Score;
    }

    public Risk() { }

    public Risk(Risk risk)
        : base(risk) { }

    public Risk(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Risk(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RiskFromRaw.FromRawUnchecked"/>
    public static Risk FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RiskFromRaw : IFromRawJson<Risk>
{
    /// <inheritdoc/>
    public Risk FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Risk.FromRawUnchecked(rawData);
}
