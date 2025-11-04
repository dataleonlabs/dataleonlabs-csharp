using System.Net.Http;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Companies.Documents;

namespace Dataleonlabs.Services.Companies.Documents;

public sealed class DocumentService : IDocumentService
{
    readonly IDataleonlabsClient _client;

    public DocumentService(IDataleonlabsClient client)
    {
        _client = client;
    }

    public async Task<DocumentResponse> List(DocumentListParams parameters)
    {
        HttpRequest<DocumentListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var documentResponse = await response.Deserialize<DocumentResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            documentResponse.Validate();
        }
        return documentResponse;
    }

    public async Task<GenericDocument> Upload(DocumentUploadParams parameters)
    {
        HttpRequest<DocumentUploadParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var genericDocument = await response.Deserialize<GenericDocument>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            genericDocument.Validate();
        }
        return genericDocument;
    }
}
