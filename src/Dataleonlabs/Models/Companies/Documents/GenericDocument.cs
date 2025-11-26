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
[JsonConverter(typeof(ModelConverter<GenericDocument, GenericDocumentFromRaw>))]
public sealed record class GenericDocument : ModelBase
{
    /// <summary>
    /// Unique identifier of the document.
    /// </summary>
    public string? ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["id"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("checks", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Check>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["checks"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the document was created or uploaded.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("created_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTimeOffset?>(
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

            this._rawData["created_at"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("document_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["document_type"] = JsonSerializer.SerializeToElement(
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
    /// Signed URL for accessing the document file.
    /// </summary>
    public string? SignedURL
    {
        get
        {
            if (!this._rawData.TryGetValue("signed_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["signed_url"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("state", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["state"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["status"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("tables", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Table>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["tables"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("values", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Value>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["values"] = JsonSerializer.SerializeToElement(
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

    public GenericDocument(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GenericDocument(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static GenericDocument FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GenericDocumentFromRaw : IFromRaw<GenericDocument>
{
    public GenericDocument FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GenericDocument.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Table, TableFromRaw>))]
public sealed record class Table : ModelBase
{
    /// <summary>
    /// List of operations or actions associated with the table.
    /// </summary>
    public List<JsonElement>? Operation
    {
        get
        {
            if (!this._rawData.TryGetValue("operation", out JsonElement element))
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

            this._rawData["operation"] = JsonSerializer.SerializeToElement(
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

    public Table(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Table(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Table FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TableFromRaw : IFromRaw<Table>
{
    public Table FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Table.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Value, ValueFromRaw>))]
public sealed record class Value : ModelBase
{
    /// <summary>
    /// Confidence score (between 0 and 1) for the extracted value.
    /// </summary>
    public double? Confidence
    {
        get
        {
            if (!this._rawData.TryGetValue("confidence", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["confidence"] = JsonSerializer.SerializeToElement(
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
    /// List of integer values related to the field (e.g., bounding box coordinates).
    /// </summary>
    public List<long>? Value1
    {
        get
        {
            if (!this._rawData.TryGetValue("value", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<long>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["value"] = JsonSerializer.SerializeToElement(
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

    public Value(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Value(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Value FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ValueFromRaw : IFromRaw<Value>
{
    public Value FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Value.FromRawUnchecked(rawData);
}
