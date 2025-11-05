using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;
using Dataleonlabs.Services.Companies;
using Dataleonlabs.Services.Individuals;

namespace Dataleonlabs;

public sealed class DataleonlabsClient : IDataleonlabsClient
{
    readonly ClientOptions _options;

    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    public Uri BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    public TimeSpan Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    public string APIKey
    {
        get { return this._options.APIKey; }
        init { this._options.APIKey = value; }
    }

    public IDataleonlabsClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DataleonlabsClient(modifier(this._options));
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

    public async Task<HttpResponse> Execute<T>(HttpRequest<T> request)
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(request.Method, request.Params.Url(this))
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this);
        using CancellationTokenSource cts = new(this.Timeout);
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e1)
        {
            throw new DataleonlabsIOException("I/O exception", e1);
        }
        if (!responseMessage.IsSuccessStatusCode)
        {
            try
            {
                throw DataleonlabsExceptionFactory.CreateApiException(
                    responseMessage.StatusCode,
                    await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false)
                );
            }
            catch (HttpRequestException e)
            {
                throw new DataleonlabsIOException("I/O Exception", e);
            }
            finally
            {
                responseMessage.Dispose();
            }
        }
        return new() { Message = responseMessage };
    }

    public DataleonlabsClient()
    {
        _options = new();

        _companies = new(() => new CompanyService(this));
        _individuals = new(() => new IndividualService(this));
    }

    public DataleonlabsClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
