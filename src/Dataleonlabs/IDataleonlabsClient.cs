using System;
using System.Net.Http;
using Dataleonlabs.Services.Companies;
using Dataleonlabs.Services.Individuals;

namespace Dataleonlabs;

public interface IDataleonlabsClient
{
    HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    /// <summary>
    /// API key needed to authorize requests.  You must provide a valid API key in
    /// the `Api-Key` header. Get your API key from the Dataleon dashboard.
    /// </summary>
    string APIKey { get; init; }

    ICompanyService Companies { get; }

    IIndividualService Individuals { get; }
}
