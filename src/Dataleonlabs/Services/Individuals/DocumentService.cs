using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;
using Dataleonlabs.Models.Individuals.Documents;
using Documents = Dataleonlabs.Models.Companies.Documents;

namespace Dataleonlabs.Services.Individuals;

/// <inheritdoc/>
public sealed class DocumentService : IDocumentService
{
    readonly Lazy<IDocumentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDocumentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IDataleonlabsClient _client;

    /// <inheritdoc/>
    public IDocumentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DocumentService(this._client.WithOptions(modifier));
    }

    public DocumentService(IDataleonlabsClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DocumentServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Documents::DocumentResponse> List(
        DocumentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Documents::DocumentResponse> List(
        string individualID,
        DocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { IndividualID = individualID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Documents::GenericDocument> Upload(
        DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Upload(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Documents::GenericDocument> Upload(
        string individualID,
        DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Upload(parameters with { IndividualID = individualID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class DocumentServiceWithRawResponse : IDocumentServiceWithRawResponse
{
    readonly IDataleonlabsClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDocumentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DocumentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DocumentServiceWithRawResponse(IDataleonlabsClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Documents::DocumentResponse>> List(
        DocumentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.IndividualID == null)
        {
            throw new DataleonlabsInvalidDataException("'parameters.IndividualID' cannot be null");
        }

        HttpRequest<DocumentListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var documentResponse = await response
                    .Deserialize<Documents::DocumentResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    documentResponse.Validate();
                }
                return documentResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Documents::DocumentResponse>> List(
        string individualID,
        DocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { IndividualID = individualID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Documents::GenericDocument>> Upload(
        DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.IndividualID == null)
        {
            throw new DataleonlabsInvalidDataException("'parameters.IndividualID' cannot be null");
        }

        HttpRequest<DocumentUploadParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var genericDocument = await response
                    .Deserialize<Documents::GenericDocument>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    genericDocument.Validate();
                }
                return genericDocument;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Documents::GenericDocument>> Upload(
        string individualID,
        DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Upload(parameters with { IndividualID = individualID }, cancellationToken);
    }
}
