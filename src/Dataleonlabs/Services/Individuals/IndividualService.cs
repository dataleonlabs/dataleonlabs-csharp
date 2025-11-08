using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Individuals;
using Dataleonlabs.Services.Individuals.Documents;

namespace Dataleonlabs.Services.Individuals;

public sealed class IndividualService : IIndividualService
{
    public IIndividualService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new IndividualService(this._client.WithOptions(modifier));
    }

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

    public async Task<Individual> Create(
        IndividualCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<IndividualCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var individual = await response
            .Deserialize<Individual>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            individual.Validate();
        }
        return individual;
    }

    public async Task<Individual> Retrieve(
        IndividualRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<IndividualRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var individual = await response
            .Deserialize<Individual>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            individual.Validate();
        }
        return individual;
    }

    public async Task<Individual> Update(
        IndividualUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<IndividualUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var individual = await response
            .Deserialize<Individual>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            individual.Validate();
        }
        return individual;
    }

    public async Task<List<Individual>> List(
        IndividualListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<IndividualListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var individuals = await response
            .Deserialize<List<Individual>>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            foreach (var item in individuals)
            {
                item.Validate();
            }
        }
        return individuals;
    }

    public async Task Delete(
        IndividualDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<IndividualDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
