using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Services.Companies.Documents;
using Companies = Dataleonlabs.Models.Companies;

namespace Dataleonlabs.Services.Companies;

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

    public async Task<Companies::Company1> Create(
        Companies::CompanyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Companies::CompanyCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var company = await response
            .Deserialize<Companies::Company1>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            company.Validate();
        }
        return company;
    }

    public async Task<Companies::Company1> Retrieve(
        Companies::CompanyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Companies::CompanyRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var company = await response
            .Deserialize<Companies::Company1>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            company.Validate();
        }
        return company;
    }

    public async Task<Companies::Company1> Update(
        Companies::CompanyUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Companies::CompanyUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var company = await response
            .Deserialize<Companies::Company1>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            company.Validate();
        }
        return company;
    }

    public async Task<List<Companies::Company1>> List(
        Companies::CompanyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<Companies::CompanyListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var companies = await response
            .Deserialize<List<Companies::Company1>>(cancellationToken)
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
        Companies::CompanyDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Companies::CompanyDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
