using System.Threading.Tasks;
using Dataleonlabs.Models.Companies.Documents;
using Documents = Dataleonlabs.Models.Individuals.Documents;

namespace Dataleonlabs.Services.Individuals.Documents;

public interface IDocumentService
{
    /// <summary>
    /// Get documents to an individuals
    /// </summary>
    Task<DocumentResponse> List(Documents::DocumentListParams parameters);

    /// <summary>
    /// Upload documents to an individual
    /// </summary>
    Task<GenericDocument> Upload(Documents::DocumentUploadParams parameters);
}
