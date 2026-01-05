using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Core;

namespace Dataleonlabs.Models.Companies;

/// <summary>
/// Represents a generic property key-value pair with a specified type.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Property, PropertyFromRaw>))]
public sealed record class Property : JsonModel
{
    /// <summary>
    /// Name/key of the property.
    /// </summary>
    public string? Name
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "name", value);
        }
    }

    /// <summary>
    /// Data type of the property value.
    /// </summary>
    public string? Type
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "type"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "type", value);
        }
    }

    /// <summary>
    /// Value associated with the property name.
    /// </summary>
    public string? Value
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "value"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Type;
        _ = this.Value;
    }

    public Property() { }

    public Property(Property property)
        : base(property) { }

    public Property(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Property(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PropertyFromRaw.FromRawUnchecked"/>
    public static Property FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PropertyFromRaw : IFromRawJson<Property>
{
    /// <inheritdoc/>
    public Property FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Property.FromRawUnchecked(rawData);
}
