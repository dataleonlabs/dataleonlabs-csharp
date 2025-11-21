using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;
using Dataleonlabs.Models.Individuals.Documents;
using Documents = Dataleonlabs.Models.Companies.Documents;

namespace Dataleonlabs.Services.Individuals;

public sealed class DocumentService : IDocumentService
{
    public IDocumentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DocumentService(this._client.WithOptions(modifier));
    }

    readonly IDataleonlabsClient _client;

    public DocumentService(IDataleonlabsClient client)
    {
        _client = client;
    }

    public async Task<Documents::DocumentResponse> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var documentResponse = await response
            .Deserialize<Documents::DocumentResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            documentResponse.Validate();
        }
        return documentResponse;
    }

    public async Task<Documents::DocumentResponse> List(
        string individualID,
        DocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(parameters with { IndividualID = individualID }, cancellationToken);
    }

    public async Task<Documents::GenericDocument> Upload(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var genericDocument = await response
            .Deserialize<Documents::GenericDocument>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            genericDocument.Validate();
        }
        return genericDocument;
    }

    public async Task<Documents::GenericDocument> Upload(
        string individualID,
        DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Upload(
            parameters with
            {
                IndividualID = individualID,
            },
            cancellationToken
        );
    }
}
