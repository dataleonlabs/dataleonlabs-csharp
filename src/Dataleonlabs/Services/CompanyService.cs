using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Companies;
using Dataleonlabs.Services.Companies;

namespace Dataleonlabs.Services;

public sealed class CompanyService : ICompanyService
{
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

    public async Task<Company1> Create(
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
        var company = await response.Deserialize<Company1>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            company.Validate();
        }
        return company;
    }

    public async Task<Company1> Retrieve(
        CompanyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CompanyRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var company = await response.Deserialize<Company1>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            company.Validate();
        }
        return company;
    }

    public async Task<Company1> Update(
        CompanyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CompanyUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var company = await response.Deserialize<Company1>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            company.Validate();
        }
        return company;
    }

    public async Task<List<Company1>> List(
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
            .Deserialize<List<Company1>>(cancellationToken)
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

    public async Task Delete(
        CompanyDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CompanyDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
