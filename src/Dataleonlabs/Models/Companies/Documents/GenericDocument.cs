using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Core;

namespace Dataleonlabs.Models.Companies.Documents;

/// <summary>
/// Represents a general document with metadata, verification checks, and extracted data.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GenericDocument, GenericDocumentFromRaw>))]
public sealed record class GenericDocument : JsonModel
{
    /// <summary>
    /// Unique identifier of the document.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// List of verification checks performed on the document.
    /// </summary>
    public IReadOnlyList<Check>? Checks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Check>>("checks");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Check>?>(
                "checks",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Type/category of the document.
    /// </summary>
    public string? DocumentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("document_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("document_type", value);
        }
    }

    /// <summary>
    /// Name or label for the document.
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
    /// Signed URL for accessing the document file.
    /// </summary>
    public string? SignedUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("signed_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("signed_url", value);
        }
    }

    /// <summary>
    /// Current processing state of the document (e.g., WAITING, PROCESSED).
    /// </summary>
    public string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("state", value);
        }
    }

    /// <summary>
    /// Status of the document reception or approval.
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// List of tables extracted from the document, each containing operations.
    /// </summary>
    public IReadOnlyList<Table>? Tables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Table>>("tables");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Table>?>(
                "tables",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Extracted key-value pairs from the document, including confidence scores.
    /// </summary>
    public IReadOnlyList<Value>? Values
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Value>>("values");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Value>?>(
                "values",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
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
        _ = this.SignedUrl;
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

    public GenericDocument(GenericDocument genericDocument)
        : base(genericDocument) { }

    public GenericDocument(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GenericDocument(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GenericDocumentFromRaw.FromRawUnchecked"/>
    public static GenericDocument FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GenericDocumentFromRaw : IFromRawJson<GenericDocument>
{
    /// <inheritdoc/>
    public GenericDocument FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GenericDocument.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Table, TableFromRaw>))]
public sealed record class Table : JsonModel
{
    /// <summary>
    /// List of operations or actions associated with the table.
    /// </summary>
    public IReadOnlyList<JsonElement>? Operation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<JsonElement>>("operation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<JsonElement>?>(
                "operation",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Operation;
    }

    public Table() { }

    public Table(Table table)
        : base(table) { }

    public Table(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Table(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TableFromRaw.FromRawUnchecked"/>
    public static Table FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TableFromRaw : IFromRawJson<Table>
{
    /// <inheritdoc/>
    public Table FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Table.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Value, ValueFromRaw>))]
public sealed record class Value : JsonModel
{
    /// <summary>
    /// Confidence score (between 0 and 1) for the extracted value.
    /// </summary>
    public double? Confidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("confidence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confidence", value);
        }
    }

    /// <summary>
    /// Name or label of the extracted field.
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
    /// List of integer values related to the field (e.g., bounding box coordinates).
    /// </summary>
    public IReadOnlyList<long>? ValueValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>("value");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<long>?>(
                "value",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Confidence;
        _ = this.Name;
        _ = this.ValueValue;
    }

    public Value() { }

    public Value(Value value)
        : base(value) { }

    public Value(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Value(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValueFromRaw.FromRawUnchecked"/>
    public static Value FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ValueFromRaw : IFromRawJson<Value>
{
    /// <inheritdoc/>
    public Value FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Value.FromRawUnchecked(rawData);
}
