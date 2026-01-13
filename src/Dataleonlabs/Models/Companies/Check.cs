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
[JsonConverter(typeof(JsonModelConverter<Check, CheckFromRaw>))]
public sealed record class Check : JsonModel
{
    /// <summary>
    /// Indicates whether the result or data is masked/hidden.
    /// </summary>
    public bool? Masked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("masked");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("masked", value);
        }
    }

    /// <summary>
    /// Additional message or explanation about the check result.
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <summary>
    /// Name or type of the check performed.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Result of the check, true if passed.
    /// </summary>
    public bool? ValidateValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("validate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("validate", value);
        }
    }

    /// <summary>
    /// Importance or weight of the check, often used in scoring.
    /// </summary>
    public long? Weight
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("weight");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("weight", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Masked;
        _ = this.Message;
        _ = this.Name;
        _ = this.ValidateValue;
        _ = this.Weight;
    }

    public Check() { }

    public Check(Check check)
        : base(check) { }

    public Check(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Check(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckFromRaw.FromRawUnchecked"/>
    public static Check FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckFromRaw : IFromRawJson<Check>
{
    /// <inheritdoc/>
    public Check FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Check.FromRawUnchecked(rawData);
}
