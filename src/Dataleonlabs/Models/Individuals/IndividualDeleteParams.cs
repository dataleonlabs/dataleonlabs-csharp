using System;
using System.Net.Http;
using Dataleonlabs.Core;

namespace Dataleonlabs.Models.Individuals;

/// <summary>
/// Delete an individual by ID
/// </summary>
public sealed record class IndividualDeleteParams : ParamsBase
{
    public required string IndividualID;

    public override Uri Url(IDataleonlabsClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/individuals/{0}", this.IndividualID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request,
        IDataleonlabsClient client
    )
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
