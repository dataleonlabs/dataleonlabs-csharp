using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dataleonlabs.Models.Companies;

/// <summary>
/// Represents a certificate file associated with an individual or company.
/// </summary>
[JsonConverter(typeof(ModelConverter<Certificat>))]
public sealed record class Certificat : ModelBase, IFromRaw<Certificat>
{
    /// <summary>
    /// Unique identifier for the certificate.
    /// </summary>
    public string? ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the certificate was created.
    /// </summary>
    public DateTime? CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Name of the certificate file.
    /// </summary>
    public string? Filename
    {
        get
        {
            if (!this.Properties.TryGetValue("filename", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["filename"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Filename;
    }

    public Certificat() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Certificat(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Certificat FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
