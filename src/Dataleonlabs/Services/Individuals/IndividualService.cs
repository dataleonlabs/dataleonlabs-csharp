using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Individuals;
using Dataleonlabs.Services.Individuals.Documents;

namespace Dataleonlabs.Services.Individuals;

public sealed class IndividualService : IIndividualService
{
    readonly IDataleonlabsClient _client;

    public IndividualService(IDataleonlabsClient client)
    {
        _client = client;
        _documents = new(() => new DocumentService(client));
    }

    readonly Lazy<IDocumentService> _documents;
    public IDocumentService Documents
    {
        get { return _documents.Value; }
    }

    public async Task<Individual> Create(IndividualCreateParams parameters)
    {
        HttpRequest<IndividualCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Individual>().ConfigureAwait(false);
    }

    public async Task<Individual> Retrieve(IndividualRetrieveParams parameters)
    {
        HttpRequest<IndividualRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Individual>().ConfigureAwait(false);
    }

    public async Task<Individual> Update(IndividualUpdateParams parameters)
    {
        HttpRequest<IndividualUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Individual>().ConfigureAwait(false);
    }

    public async Task<List<Individual>> List(IndividualListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<IndividualListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<List<Individual>>().ConfigureAwait(false);
    }

    public async Task Delete(IndividualDeleteParams parameters)
    {
        HttpRequest<IndividualDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return;
    }
}
