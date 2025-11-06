using System;
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
    /// List of verification checks performed on the document.
    /// </summary>
    public List<Check>? Checks
    {
        get
        {
            if (!this.Properties.TryGetValue("checks", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Check>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["checks"] = JsonSerializer.SerializeToElement(
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
    /// Type/category of the document.
    /// </summary>
    public string? DocumentType
    {
        get
        {
            if (!this.Properties.TryGetValue("document_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["document_type"] = JsonSerializer.SerializeToElement(
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
    /// Signed URL for accessing the document file.
    /// </summary>
    public string? SignedURL
    {
        get
        {
            if (!this.Properties.TryGetValue("signed_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["signed_url"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("state", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["state"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("tables", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Table>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["tables"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("values", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Value>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["values"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GenericDocument(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static GenericDocument FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
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
            if (!this.Properties.TryGetValue("operation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["operation"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Table(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Table FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
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
            if (!this.Properties.TryGetValue("confidence", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["confidence"] = JsonSerializer.SerializeToElement(
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
    /// List of integer values related to the field (e.g., bounding box coordinates).
    /// </summary>
    public List<long>? Value1
    {
        get
        {
            if (!this.Properties.TryGetValue("value", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<long>?>(element, ModelBase.SerializerOptions);
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
        _ = this.Confidence;
        _ = this.Name;
        _ = this.Value1;
    }

    public Value() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Value(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Value FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
