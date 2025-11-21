using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Services;

namespace Dataleonlabs;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDataleonlabsClient
{
    HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    bool ResponseValidation { get; init; }

    int? MaxRetries { get; init; }

    TimeSpan? Timeout { get; init; }

    /// <summary>
    /// API key needed to authorize requests.  You must provide a valid API key in
    /// the `Api-Key` header. Get your API key from the Dataleon dashboard.
    /// </summary>
    string APIKey { get; init; }

    IDataleonlabsClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICompanyService Companies { get; }

    IIndividualService Individuals { get; }

    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
