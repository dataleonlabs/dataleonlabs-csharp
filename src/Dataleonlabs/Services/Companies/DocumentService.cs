using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;
using Dataleonlabs.Models.Companies.Documents;

namespace Dataleonlabs.Services.Companies;

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
    public async Task<DocumentResponse> List(
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
    public Task<DocumentResponse> List(
        string companyID,
        DocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CompanyID = companyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<GenericDocument> Upload(
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
    public Task<GenericDocument> Upload(
        string companyID,
        DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Upload(parameters with { CompanyID = companyID }, cancellationToken);
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
    public async Task<HttpResponse<DocumentResponse>> List(
        DocumentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CompanyID == null)
        {
            throw new DataleonlabsInvalidDataException("'parameters.CompanyID' cannot be null");
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
                    .Deserialize<DocumentResponse>(token)
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
    public Task<HttpResponse<DocumentResponse>> List(
        string companyID,
        DocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CompanyID = companyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GenericDocument>> Upload(
        DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CompanyID == null)
        {
            throw new DataleonlabsInvalidDataException("'parameters.CompanyID' cannot be null");
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
                    .Deserialize<GenericDocument>(token)
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
    public Task<HttpResponse<GenericDocument>> Upload(
        string companyID,
        DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Upload(parameters with { CompanyID = companyID }, cancellationToken);
    }
}
