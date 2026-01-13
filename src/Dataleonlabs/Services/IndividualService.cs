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
    readonly Lazy<IIndividualServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IIndividualServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDataleonlabsClient _client;

    /// <inheritdoc/>
    public IIndividualService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new IndividualService(this._client.WithOptions(modifier));
    }

    public IndividualService(IDataleonlabsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new IndividualServiceWithRawResponse(client.WithRawResponse));
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
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Individual> Retrieve(
        IndividualRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Individual> Retrieve(
        string individualID,
        IndividualRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { IndividualID = individualID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Individual> Update(
        IndividualUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Individual> Update(
        string individualID,
        IndividualUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { IndividualID = individualID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<Individual>> List(
        IndividualListParams? parameters = null,
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
        IndividualDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string individualID,
        IndividualDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { IndividualID = individualID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class IndividualServiceWithRawResponse : IIndividualServiceWithRawResponse
{
    readonly IDataleonlabsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IIndividualServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new IndividualServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public IndividualServiceWithRawResponse(IDataleonlabsClientWithRawResponse client)
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
    public async Task<HttpResponse<Individual>> Create(
        IndividualCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<IndividualCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var individual = await response
                    .Deserialize<Individual>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    individual.Validate();
                }
                return individual;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Individual>> Retrieve(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var individual = await response
                    .Deserialize<Individual>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    individual.Validate();
                }
                return individual;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Individual>> Retrieve(
        string individualID,
        IndividualRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { IndividualID = individualID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Individual>> Update(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var individual = await response
                    .Deserialize<Individual>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    individual.Validate();
                }
                return individual;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Individual>> Update(
        string individualID,
        IndividualUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { IndividualID = individualID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<Individual>>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var individuals = await response
                    .Deserialize<List<Individual>>(token)
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
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string individualID,
        IndividualDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { IndividualID = individualID }, cancellationToken);
    }
}
