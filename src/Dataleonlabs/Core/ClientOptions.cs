using System;
using System.Net.Http;
using Dataleonlabs.Exceptions;

namespace Dataleonlabs.Core;

public struct ClientOptions()
{
    public HttpClient HttpClient { get; set; } = new();

    Lazy<Uri> _baseUrl = new(() =>
        new Uri(
            Environment.GetEnvironmentVariable("DATALEONLABS_BASE_URL")
                ?? "https://inference.eu-west-1.dataleon.ai"
        )
    );
    public Uri BaseUrl
    {
        readonly get { return _baseUrl.Value; }
        set { _baseUrl = new(() => value); }
    }

    /// <summary>
    /// API key needed to authorize requests.  You must provide a valid API key in
    /// the `Api-Key` header. Get your API key from the Dataleon dashboard.
    /// </summary>
    Lazy<string> _apiKey = new(() =>
        Environment.GetEnvironmentVariable("DATALEONLABS_API_KEY")
        ?? throw new DataleonlabsInvalidDataException(
            string.Format("{0} cannot be null", nameof(APIKey)),
            new ArgumentNullException(nameof(APIKey))
        )
    );

    /// <summary>
    /// API key needed to authorize requests.  You must provide a valid API key in
    /// the `Api-Key` header. Get your API key from the Dataleon dashboard.
    /// </summary>
    public string APIKey
    {
        readonly get { return _apiKey.Value; }
        set { _apiKey = new(() => value); }
    }
}
