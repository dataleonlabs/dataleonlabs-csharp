using System;
using System.Net.Http;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Services.Companies;
using Dataleonlabs.Services.Individuals;

namespace Dataleonlabs;

public interface IDataleonlabsClient
{
    HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    bool ResponseValidation { get; init; }

    TimeSpan Timeout { get; init; }

    /// <summary>
    /// API key needed to authorize requests.  You must provide a valid API key in
    /// the `Api-Key` header. Get your API key from the Dataleon dashboard.
    /// </summary>
    string APIKey { get; init; }

    IDataleonlabsClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICompanyService Companies { get; }

    IIndividualService Individuals { get; }

    Task<HttpResponse> Execute<T>(HttpRequest<T> request)
        where T : ParamsBase;
}
