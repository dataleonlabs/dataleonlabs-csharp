using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Core;

namespace Dataleonlabs.Models.Companies;

/// <summary>
/// Represents a verification check result.
/// </summary>
[JsonConverter(typeof(ModelConverter<Check, CheckFromRaw>))]
public sealed record class Check : ModelBase
{
    /// <summary>
    /// Indicates whether the result or data is masked/hidden.
    /// </summary>
    public bool? Masked
    {
        get
        {
            if (!this._rawData.TryGetValue("masked", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["masked"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional message or explanation about the check result.
    /// </summary>
    public string? Message
    {
        get
        {
            if (!this._rawData.TryGetValue("message", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["message"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Name or type of the check performed.
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Result of the check, true if passed.
    /// </summary>
    public bool? Validate1
    {
        get
        {
            if (!this._rawData.TryGetValue("validate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["validate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Importance or weight of the check, often used in scoring.
    /// </summary>
    public long? Weight
    {
        get
        {
            if (!this._rawData.TryGetValue("weight", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["weight"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Masked;
        _ = this.Message;
        _ = this.Name;
        _ = this.Validate1;
        _ = this.Weight;
    }

    public Check() { }

    public Check(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Check(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Check FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckFromRaw : IFromRaw<Check>
{
    public Check FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Check.FromRawUnchecked(rawData);
}
