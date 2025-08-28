using System;
using System.Net.Http;
using Dataleonlabs.Services.Companies;
using Dataleonlabs.Services.Individuals;

namespace Dataleonlabs;

public sealed class DataleonlabsClient : IDataleonlabsClient
{
    public HttpClient HttpClient { get; init; } = new();

    Lazy<Uri> _baseUrl = new(() =>
        new Uri(
            Environment.GetEnvironmentVariable("DATALEONLABS_BASE_URL")
                ?? "https://inference.eu-west-1.dataleon.ai"
        )
    );
    public Uri BaseUrl
    {
        get { return _baseUrl.Value; }
        init { _baseUrl = new(() => value); }
    }

    Lazy<string> _apiKey = new(() =>
        Environment.GetEnvironmentVariable("DATALEONLABS_API_KEY")
        ?? throw new ArgumentNullException(nameof(APIKey))
    );
    public string APIKey
    {
        get { return _apiKey.Value; }
        init { _apiKey = new(() => value); }
    }

    readonly Lazy<ICompanyService> _companies;
    public ICompanyService Companies
    {
        get { return _companies.Value; }
    }

    readonly Lazy<IIndividualService> _individuals;
    public IIndividualService Individuals
    {
        get { return _individuals.Value; }
    }

    public DataleonlabsClient()
    {
        _companies = new(() => new CompanyService(this));
        _individuals = new(() => new IndividualService(this));
    }
}
