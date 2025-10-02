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
        return await response.Deserialize<DocumentResponse>().ConfigureAwait(false);
    }

    public async Task<GenericDocument> Upload(DocumentUploadParams parameters)
    {
        HttpRequest<DocumentUploadParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<GenericDocument>().ConfigureAwait(false);
    }
}
