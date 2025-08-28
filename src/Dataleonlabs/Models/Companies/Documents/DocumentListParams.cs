using System;
using System.Net.Http;

namespace Dataleonlabs.Models.Companies.Documents;

/// <summary>
/// Get documents to an company
/// </summary>
public sealed record class DocumentListParams : ParamsBase
{
    public required string CompanyID;

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

    public void AddHeadersToRequest(HttpRequestMessage request, IDataleonlabsClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
