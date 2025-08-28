using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Dataleonlabs.Models.Companies.Documents.DocumentUploadParamsProperties;

namespace Dataleonlabs.Models.Companies.Documents;

/// <summary>
/// Upload documents to an company
/// </summary>
public sealed record class DocumentUploadParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string CompanyID;

    /// <summary>
    /// Filter by document type for upload (must be one of the allowed values)
    /// </summary>
    public required ApiEnum<string, DocumentType> DocumentType
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("document_type", out JsonElement element))
                throw new ArgumentOutOfRangeException("document_type", "Missing required argument");

            return JsonSerializer.Deserialize<ApiEnum<string, DocumentType>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["document_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// File to upload (required)
    /// </summary>
    public string? File
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("file", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["file"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// URL of the file to upload (either `file` or `url` is required)
    /// </summary>
    public string? URL
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IDataleonlabsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/companies/{0}/documents", this.CompanyID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IDataleonlabsClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
