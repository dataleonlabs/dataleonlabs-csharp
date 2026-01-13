using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;
using Dataleonlabs.Models.Companies;
using Dataleonlabs.Services.Companies;

namespace Dataleonlabs.Services;

/// <inheritdoc/>
public sealed class CompanyService : ICompanyService
{
    readonly Lazy<ICompanyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICompanyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDataleonlabsClient _client;

    /// <inheritdoc/>
    public ICompanyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CompanyService(this._client.WithOptions(modifier));
    }

    public CompanyService(IDataleonlabsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CompanyServiceWithRawResponse(client.WithRawResponse));
        _documents = new(() => new DocumentService(client));
    }

    readonly Lazy<IDocumentService> _documents;
    public IDocumentService Documents
    {
        get { return _documents.Value; }
    }

    /// <inheritdoc/>
    public async Task<CompanyCompany> Create(
        CompanyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CompanyCompany> Retrieve(
        CompanyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CompanyCompany> Retrieve(
        string companyID,
        CompanyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CompanyID = companyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CompanyCompany> Update(
        CompanyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CompanyCompany> Update(
        string companyID,
        CompanyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { CompanyID = companyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<CompanyCompany>> List(
        CompanyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        CompanyDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string companyID,
        CompanyDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { CompanyID = companyID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CompanyServiceWithRawResponse : ICompanyServiceWithRawResponse
{
    readonly IDataleonlabsClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICompanyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CompanyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CompanyServiceWithRawResponse(IDataleonlabsClientWithRawResponse client)
    {
        _client = client;

        _documents = new(() => new DocumentServiceWithRawResponse(client));
    }

    readonly Lazy<IDocumentServiceWithRawResponse> _documents;
    public IDocumentServiceWithRawResponse Documents
    {
        get { return _documents.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CompanyCompany>> Create(
        CompanyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CompanyCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var company = await response
                    .Deserialize<CompanyCompany>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    company.Validate();
                }
                return company;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CompanyCompany>> Retrieve(
        CompanyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CompanyID == null)
        {
            throw new DataleonlabsInvalidDataException("'parameters.CompanyID' cannot be null");
        }

        HttpRequest<CompanyRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var company = await response
                    .Deserialize<CompanyCompany>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    company.Validate();
                }
                return company;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CompanyCompany>> Retrieve(
        string companyID,
        CompanyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CompanyID = companyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CompanyCompany>> Update(
        CompanyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CompanyID == null)
        {
            throw new DataleonlabsInvalidDataException("'parameters.CompanyID' cannot be null");
        }

        HttpRequest<CompanyUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var company = await response
                    .Deserialize<CompanyCompany>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    company.Validate();
                }
                return company;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CompanyCompany>> Update(
        string companyID,
        CompanyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { CompanyID = companyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<CompanyCompany>>> List(
        CompanyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CompanyListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var companies = await response
                    .Deserialize<List<CompanyCompany>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in companies)
                    {
                        item.Validate();
                    }
                }
                return companies;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        CompanyDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CompanyID == null)
        {
            throw new DataleonlabsInvalidDataException("'parameters.CompanyID' cannot be null");
        }

        HttpRequest<CompanyDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string companyID,
        CompanyDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { CompanyID = companyID }, cancellationToken);
    }
}
