using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dataleonlabs.Models.Individuals.IndividualProperties;

/// <summary>
/// Represents a key-value metadata tag that can be associated with entities such
/// as individuals or companies.
/// </summary>
[JsonConverter(typeof(ModelConverter<Tag>))]
public sealed record class Tag : ModelBase, IFromRaw<Tag>
{
    /// <summary>
    /// Name of the tag used to identify the metadata field.
    /// </summary>
    public string? Key
    {
        get
        {
            if (!this.Properties.TryGetValue("key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Indicates whether the tag is private (not visible to external users).
    /// </summary>
    public bool? Private
    {
        get
        {
            if (!this.Properties.TryGetValue("private", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["private"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Data type of the tag value (e.g., "string", "number", "boolean").
    /// </summary>
    public string? Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Value assigned to the tag.
    /// </summary>
    public string? Value
    {
        get
        {
            if (!this.Properties.TryGetValue("value", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Key;
        _ = this.Private;
        _ = this.Type;
        _ = this.Value;
    }

    public Tag() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tag(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Tag FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
