using System;
using System.Net.Http;
using System.Text.Json;

namespace Dataleonlabs.Models.Companies;

/// <summary>
/// Get a company by ID
/// </summary>
public sealed record class CompanyRetrieveParams : ParamsBase
{
    public required string CompanyID;

    /// <summary>
    /// Include document signed url
    /// </summary>
    public bool? Document
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("document", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["document"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Scope filter (id or scope)
    /// </summary>
    public string? Scope
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("scope", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["scope"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IDataleonlabsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/companies/{0}", this.CompanyID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
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
