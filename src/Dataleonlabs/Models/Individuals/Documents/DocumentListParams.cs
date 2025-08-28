using System;
using System.Net.Http;

namespace Dataleonlabs.Models.Individuals.Documents;

/// <summary>
/// Get documents to an individuals
/// </summary>
public sealed record class DocumentListParams : ParamsBase
{
    public required string IndividualID;

    public override Uri Url(IDataleonlabsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/individuals/{0}/documents", this.IndividualID)
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
