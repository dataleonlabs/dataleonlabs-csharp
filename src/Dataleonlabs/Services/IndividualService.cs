using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;
using Dataleonlabs.Models.Individuals;
using Dataleonlabs.Services.Individuals;

namespace Dataleonlabs.Services;

/// <inheritdoc/>
public sealed class IndividualService : IIndividualService
{
    /// <inheritdoc/>
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

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public async Task<Individual> Retrieve(
        IndividualRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.IndividualID == null)
        {
            throw new DataleonlabsInvalidDataException("'parameters.IndividualID' cannot be null");
        }

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

    /// <inheritdoc/>
    public async Task<Individual> Retrieve(
        string individualID,
        IndividualRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(
            parameters with
            {
                IndividualID = individualID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<Individual> Update(
        IndividualUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.IndividualID == null)
        {
            throw new DataleonlabsInvalidDataException("'parameters.IndividualID' cannot be null");
        }

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

    /// <inheritdoc/>
    public async Task<Individual> Update(
        string individualID,
        IndividualUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Update(
            parameters with
            {
                IndividualID = individualID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public async Task Delete(
        IndividualDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.IndividualID == null)
        {
            throw new DataleonlabsInvalidDataException("'parameters.IndividualID' cannot be null");
        }

        HttpRequest<IndividualDeleteParams> request = new()
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
        string individualID,
        IndividualDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { IndividualID = individualID }, cancellationToken);
    }
}
