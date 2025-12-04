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
        get { return ModelBase.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "id", value);
        }
    }

    /// <summary>
    /// List of verification checks performed on the document.
    /// </summary>
    public IReadOnlyList<Check>? Checks
    {
        get { return ModelBase.GetNullableClass<List<Check>>(this.RawData, "checks"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "checks", value);
        }
    }

    /// <summary>
    /// Timestamp when the document was created or uploaded.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get { return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawData, "created_at"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "created_at", value);
        }
    }

    /// <summary>
    /// Type/category of the document.
    /// </summary>
    public string? DocumentType
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "document_type"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "document_type", value);
        }
    }

    /// <summary>
    /// Name or label for the document.
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
    /// Signed URL for accessing the document file.
    /// </summary>
    public string? SignedURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "signed_url"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "signed_url", value);
        }
    }

    /// <summary>
    /// Current processing state of the document (e.g., WAITING, PROCESSED).
    /// </summary>
    public string? State
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "state"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "state", value);
        }
    }

    /// <summary>
    /// Status of the document reception or approval.
    /// </summary>
    public string? Status
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "status"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "status", value);
        }
    }

    /// <summary>
    /// List of tables extracted from the document, each containing operations.
    /// </summary>
    public IReadOnlyList<Table>? Tables
    {
        get { return ModelBase.GetNullableClass<List<Table>>(this.RawData, "tables"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "tables", value);
        }
    }

    /// <summary>
    /// Extracted key-value pairs from the document, including confidence scores.
    /// </summary>
    public IReadOnlyList<Value>? Values
    {
        get { return ModelBase.GetNullableClass<List<Value>>(this.RawData, "values"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "values", value);
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
    public IReadOnlyList<JsonElement>? Operation
    {
        get { return ModelBase.GetNullableClass<List<JsonElement>>(this.RawData, "operation"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "operation", value);
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
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "confidence"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "confidence", value);
        }
    }

    /// <summary>
    /// Name or label of the extracted field.
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
    /// List of integer values related to the field (e.g., bounding box coordinates).
    /// </summary>
    public IReadOnlyList<long>? ValueValue
    {
        get { return ModelBase.GetNullableClass<List<long>>(this.RawData, "value"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "value", value);
        }
    }

    public override void Validate()
    {
        _ = this.Confidence;
        _ = this.Name;
        _ = this.ValueValue;
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
