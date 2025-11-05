using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Companies;
using Dataleonlabs.Services.Companies.Documents;

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

    public async Task<Company> Create(CompanyCreateParams parameters)
    {
        HttpRequest<CompanyCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var company = await response.Deserialize<Company>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            company.Validate();
        }
        return company;
    }

    public async Task<Company> Retrieve(CompanyRetrieveParams parameters)
    {
        HttpRequest<CompanyRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var company = await response.Deserialize<Company>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            company.Validate();
        }
        return company;
    }

    public async Task<Company> Update(CompanyUpdateParams parameters)
    {
        HttpRequest<CompanyUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var company = await response.Deserialize<Company>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            company.Validate();
        }
        return company;
    }

    public async Task<List<Company>> List(CompanyListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<CompanyListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var companies = await response.Deserialize<List<Company>>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            foreach (var item in companies)
            {
                item.Validate();
            }
        }
        return companies;
    }

    public async Task Delete(CompanyDeleteParams parameters)
    {
        HttpRequest<CompanyDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }
}
