using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dataleonlabs.Models.Companies;

/// <summary>
/// Represents a verification check result.
/// </summary>
[JsonConverter(typeof(ModelConverter<Check>))]
public sealed record class Check : ModelBase, IFromRaw<Check>
{
    /// <summary>
    /// Indicates whether the result or data is masked/hidden.
    /// </summary>
    public bool? Masked
    {
        get
        {
            if (!this.Properties.TryGetValue("masked", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["masked"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("message", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["message"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("validate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["validate"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("weight", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["weight"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Check(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Check FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
