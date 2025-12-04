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
    /// <inheritdoc/>
    public IDocumentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DocumentService(this._client.WithOptions(modifier));
    }

    readonly IDataleonlabsClient _client;

    public DocumentService(IDataleonlabsClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<DocumentResponse> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var documentResponse = await response
            .Deserialize<DocumentResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            documentResponse.Validate();
        }
        return documentResponse;
    }

    /// <inheritdoc/>
    public async Task<DocumentResponse> List(
        string companyID,
        DocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(parameters with { CompanyID = companyID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<GenericDocument> Upload(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var genericDocument = await response
            .Deserialize<GenericDocument>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            genericDocument.Validate();
        }
        return genericDocument;
    }

    /// <inheritdoc/>
    public async Task<GenericDocument> Upload(
        string companyID,
        DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Upload(parameters with { CompanyID = companyID }, cancellationToken);
    }
}
