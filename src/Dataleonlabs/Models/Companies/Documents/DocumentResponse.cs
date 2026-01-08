using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Core;

namespace Dataleonlabs.Models.Companies.Documents;

[JsonConverter(typeof(JsonModelConverter<DocumentResponse, DocumentResponseFromRaw>))]
public sealed record class DocumentResponse : JsonModel
{
    /// <summary>
    /// List of documents associated with the response.
    /// </summary>
    public IReadOnlyList<Document>? Documents
    {
        get { return JsonModel.GetNullableClass<List<Document>>(this.RawData, "documents"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "documents", value);
        }
    }

    /// <summary>
    /// Total number of documents available in the response.
    /// </summary>
    public long? TotalDocument
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "total_document"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "total_document", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Documents ?? [])
        {
            item.Validate();
        }
        _ = this.TotalDocument;
    }

    public DocumentResponse() { }

    public DocumentResponse(DocumentResponse documentResponse)
        : base(documentResponse) { }

    public DocumentResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DocumentResponseFromRaw.FromRawUnchecked"/>
    public static DocumentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DocumentResponseFromRaw : IFromRawJson<DocumentResponse>
{
    /// <inheritdoc/>
    public DocumentResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DocumentResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Represents a document stored and processed by the system, such as an identity
/// card or a PDF contract.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Document, DocumentFromRaw>))]
public sealed record class Document : JsonModel
{
    /// <summary>
    /// Unique identifier of the document.
    /// </summary>
    public string? ID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "id", value);
        }
    }

    /// <summary>
    /// Functional type of the document (e.g., identity document, invoice).
    /// </summary>
    public string? DocumentType
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "document_type"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "document_type", value);
        }
    }

    /// <summary>
    /// Original filename of the uploaded document.
    /// </summary>
    public string? Filename
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "filename"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "filename", value);
        }
    }

    /// <summary>
    /// Human-readable name of the document.
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
    /// Secure URL to access the document.
    /// </summary>
    public string? SignedUrl
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "signed_url"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "signed_url", value);
        }
    }

    /// <summary>
    /// Processing state of the document (e.g., WAITING, STARTED, RUNNING, PROCESSED).
    /// </summary>
    public string? State
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "state"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "state", value);
        }
    }

    /// <summary>
    /// Validation status of the document (e.g., need_review, approved, rejected).
    /// </summary>
    public string? Status
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "status"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "status", value);
        }
    }

    /// <summary>
    /// Identifier of the workspace to which the document belongs.
    /// </summary>
    public string? WorkspaceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "workspace_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "workspace_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.DocumentType;
        _ = this.Filename;
        _ = this.Name;
        _ = this.SignedUrl;
        _ = this.State;
        _ = this.Status;
        _ = this.WorkspaceID;
    }

    public Document() { }

    public Document(Document document)
        : base(document) { }

    public Document(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Document(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DocumentFromRaw.FromRawUnchecked"/>
    public static Document FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DocumentFromRaw : IFromRawJson<Document>
{
    /// <inheritdoc/>
    public Document FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Document.FromRawUnchecked(rawData);
}
