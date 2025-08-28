using System.Threading.Tasks;
using Dataleonlabs.Models.Companies.Documents;

namespace Dataleonlabs.Services.Companies.Documents;

public interface IDocumentService
{
    /// <summary>
    /// Get documents to an company
    /// </summary>
    Task<DocumentResponse> List(DocumentListParams parameters);

    /// <summary>
    /// Upload documents to an company
    /// </summary>
    Task<GenericDocument> Upload(DocumentUploadParams parameters);
}
