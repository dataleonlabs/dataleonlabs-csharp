using System;
using System.Net.Http;
using System.Text.Json;
using Dataleonlabs.Models.Companies.CompanyListParamsProperties;

namespace Dataleonlabs.Models.Companies;

/// <summary>
/// Get all companies
/// </summary>
public sealed record class CompanyListParams : ParamsBase
{
    /// <summary>
    /// Filter companies created before this date (format YYYY-MM-DD)
    /// </summary>
    public DateOnly? EndDate
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateOnly?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of results to return (between 1 and 100)
    /// </summary>
    public long? Limit
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["limit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of results to skip (must be ≥ 0)
    /// </summary>
    public long? Offset
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("offset", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["offset"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter by source ID
    /// </summary>
    public string? SourceID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("source_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["source_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter companies created after this date (format YYYY-MM-DD)
    /// </summary>
    public DateOnly? StartDate
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("start_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateOnly?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter by company state (must be one of the allowed values)
    /// </summary>
    public ApiEnum<string, State>? State
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("state", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, State>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.QueryProperties["state"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter by individual status (must be one of the allowed values)
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Status>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.QueryProperties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter by workspace ID
    /// </summary>
    public string? WorkspaceID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("workspace_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["workspace_id"] = JsonSerializer.SerializeToElement(
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

    public void AddHeadersToRequest(HttpRequestMessage request, IDataleonlabsClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
