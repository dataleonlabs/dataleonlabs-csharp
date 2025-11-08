using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Core;

namespace Dataleonlabs.Models.Companies.Documents;

/// <summary>
/// Represents a general document with metadata, verification checks, and extracted data.
/// </summary>
[JsonConverter(typeof(ModelConverter<GenericDocument>))]
public sealed record class GenericDocument : ModelBase, IFromRaw<GenericDocument>
{
    /// <summary>
    /// Unique identifier of the document.
    /// </summary>
    public string? ID
    {
        get
        {
            if (!this._properties.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of verification checks performed on the document.
    /// </summary>
    public List<Check>? Checks
    {
        get
        {
            if (!this._properties.TryGetValue("checks", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Check>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["checks"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the document was created or uploaded.
    /// </summary>
    public DateTime? CreatedAt
    {
        get
        {
            if (!this._properties.TryGetValue("created_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Type/category of the document.
    /// </summary>
    public string? DocumentType
    {
        get
        {
            if (!this._properties.TryGetValue("document_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["document_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Name or label for the document.
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Signed URL for accessing the document file.
    /// </summary>
    public string? SignedURL
    {
        get
        {
            if (!this._properties.TryGetValue("signed_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["signed_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Current processing state of the document (e.g., WAITING, PROCESSED).
    /// </summary>
    public string? State
    {
        get
        {
            if (!this._properties.TryGetValue("state", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["state"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Status of the document reception or approval.
    /// </summary>
    public string? Status
    {
        get
        {
            if (!this._properties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of tables extracted from the document, each containing operations.
    /// </summary>
    public List<Table>? Tables
    {
        get
        {
            if (!this._properties.TryGetValue("tables", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Table>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["tables"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Extracted key-value pairs from the document, including confidence scores.
    /// </summary>
    public List<Value>? Values
    {
        get
        {
            if (!this._properties.TryGetValue("values", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Value>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["values"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Checks ?? [])
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        _ = this.DocumentType;
        _ = this.Name;
        _ = this.SignedURL;
        _ = this.State;
        _ = this.Status;
        foreach (var item in this.Tables ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Values ?? [])
        {
            item.Validate();
        }
    }

    public GenericDocument() { }

    public GenericDocument(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GenericDocument(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static GenericDocument FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<Table>))]
public sealed record class Table : ModelBase, IFromRaw<Table>
{
    /// <summary>
    /// List of operations or actions associated with the table.
    /// </summary>
    public List<JsonElement>? Operation
    {
        get
        {
            if (!this._properties.TryGetValue("operation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["operation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Operation;
    }

    public Table() { }

    public Table(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Table(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Table FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<Value>))]
public sealed record class Value : ModelBase, IFromRaw<Value>
{
    /// <summary>
    /// Confidence score (between 0 and 1) for the extracted value.
    /// </summary>
    public double? Confidence
    {
        get
        {
            if (!this._properties.TryGetValue("confidence", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["confidence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Name or label of the extracted field.
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of integer values related to the field (e.g., bounding box coordinates).
    /// </summary>
    public List<long>? Value1
    {
        get
        {
            if (!this._properties.TryGetValue("value", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<long>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Confidence;
        _ = this.Name;
        _ = this.Value1;
    }

    public Value() { }

    public Value(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Value(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Value FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
