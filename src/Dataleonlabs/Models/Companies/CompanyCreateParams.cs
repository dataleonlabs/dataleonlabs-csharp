using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using CompanyCreateParamsProperties = Dataleonlabs.Models.Companies.CompanyCreateParamsProperties;

namespace Dataleonlabs.Models.Companies;

/// <summary>
/// Create a new company
/// </summary>
public sealed record class CompanyCreateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// Main information about the company being registered.
    /// </summary>
    public required CompanyCreateParamsProperties::Company Company
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("company", out JsonElement element))
                throw new ArgumentOutOfRangeException("company", "Missing required argument");

            return JsonSerializer.Deserialize<CompanyCreateParamsProperties::Company>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("company");
        }
        set
        {
            this.BodyProperties["company"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Unique identifier of the workspace in which the company is being created.
    /// </summary>
    public required string WorkspaceID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("workspace_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("workspace_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("workspace_id");
        }
        set
        {
            this.BodyProperties["workspace_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional identifier to track the origin of the request or integration from
    /// your system.
    /// </summary>
    public string? SourceID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("source_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["source_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Technical metadata and callback configuration.
    /// </summary>
    public CompanyCreateParamsProperties::TechnicalData? TechnicalData
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("technical_data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CompanyCreateParamsProperties::TechnicalData?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["technical_data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IDataleonlabsClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/companies")
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
