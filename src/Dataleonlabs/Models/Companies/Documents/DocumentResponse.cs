using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Core;

namespace Dataleonlabs.Models.Companies.Documents;

[JsonConverter(typeof(ModelConverter<DocumentResponse>))]
public sealed record class DocumentResponse : ModelBase, IFromRaw<DocumentResponse>
{
    /// <summary>
    /// List of documents associated with the response.
    /// </summary>
    public List<Document>? Documents
    {
        get
        {
            if (!this._properties.TryGetValue("documents", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Document>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["documents"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Total number of documents available in the response.
    /// </summary>
    public long? TotalDocument
    {
        get
        {
            if (!this._properties.TryGetValue("total_document", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["total_document"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Documents ?? [])
        {
            item.Validate();
        }
        _ = this.TotalDocument;
    }

    public DocumentResponse() { }

    public DocumentResponse(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static DocumentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Represents a document stored and processed by the system, such as an identity
/// card or a PDF contract.
/// </summary>
[JsonConverter(typeof(ModelConverter<Document>))]
public sealed record class Document : ModelBase, IFromRaw<Document>
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
            this._properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Functional type of the document (e.g., identity document, invoice).
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
            this._properties["document_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Original filename of the uploaded document.
    /// </summary>
    public string? Filename
    {
        get
        {
            if (!this._properties.TryGetValue("filename", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["filename"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Human-readable name of the document.
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
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Secure URL to access the document.
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
            this._properties["signed_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Processing state of the document (e.g., WAITING, STARTED, RUNNING, PROCESSED).
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
            this._properties["state"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Validation status of the document (e.g., need_review, approved, rejected).
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
            this._properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Identifier of the workspace to which the document belongs.
    /// </summary>
    public string? WorkspaceID
    {
        get
        {
            if (!this._properties.TryGetValue("workspace_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["workspace_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.DocumentType;
        _ = this.Filename;
        _ = this.Name;
        _ = this.SignedURL;
        _ = this.State;
        _ = this.Status;
        _ = this.WorkspaceID;
    }

    public Document() { }

    public Document(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Document(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Document FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
