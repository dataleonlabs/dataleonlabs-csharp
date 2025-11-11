using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Companies.Documents;
using Documents = Dataleonlabs.Models.Individuals.Documents;

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

    public async Task<DocumentResponse> List(
        Documents::DocumentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Documents::DocumentListParams> request = new()
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

    public async Task<GenericDocument> Upload(
        Documents::DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Documents::DocumentUploadParams> request = new()
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
}
