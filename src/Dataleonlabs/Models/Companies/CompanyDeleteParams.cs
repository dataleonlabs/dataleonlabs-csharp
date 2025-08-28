using System;
using System.Net.Http;

namespace Dataleonlabs.Models.Companies;

/// <summary>
/// Delete a company by ID
/// </summary>
public sealed record class CompanyDeleteParams : ParamsBase
{
    public required string CompanyID;

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
