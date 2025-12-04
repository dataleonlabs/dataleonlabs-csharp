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
    /// <inheritdoc/>
    public ICompanyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CompanyService(this._client.WithOptions(modifier));
    }

    readonly IDataleonlabsClient _client;

    public CompanyService(IDataleonlabsClient client)
    {
        _client = client;
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
        HttpRequest<CompanyCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var company = await response
            .Deserialize<CompanyCompany>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            company.Validate();
        }
        return company;
    }

    /// <inheritdoc/>
    public async Task<CompanyCompany> Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var company = await response
            .Deserialize<CompanyCompany>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            company.Validate();
        }
        return company;
    }

    /// <inheritdoc/>
    public async Task<CompanyCompany> Retrieve(
        string companyID,
        CompanyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { CompanyID = companyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CompanyCompany> Update(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var company = await response
            .Deserialize<CompanyCompany>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            company.Validate();
        }
        return company;
    }

    /// <inheritdoc/>
    public async Task<CompanyCompany> Update(
        string companyID,
        CompanyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Update(parameters with { CompanyID = companyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<CompanyCompany>> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var companies = await response
            .Deserialize<List<CompanyCompany>>(cancellationToken)
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

    /// <inheritdoc/>
    public async Task Delete(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string companyID,
        CompanyDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { CompanyID = companyID }, cancellationToken);
    }
}
