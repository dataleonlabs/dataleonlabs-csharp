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
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "masked"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "masked", value);
        }
    }

    /// <summary>
    /// Additional message or explanation about the check result.
    /// </summary>
    public string? Message
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "message"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "message", value);
        }
    }

    /// <summary>
    /// Name or type of the check performed.
    /// </summary>
    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "name", value);
        }
    }

    /// <summary>
    /// Result of the check, true if passed.
    /// </summary>
    public bool? ValidateValue
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "validate"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "validate", value);
        }
    }

    /// <summary>
    /// Importance or weight of the check, often used in scoring.
    /// </summary>
    public long? Weight
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "weight"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "weight", value);
        }
    }

    public override void Validate()
    {
        _ = this.Masked;
        _ = this.Message;
        _ = this.Name;
        _ = this.ValidateValue;
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
