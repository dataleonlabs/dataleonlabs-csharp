using System;
using System.Threading;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Individuals.Documents;
using Documents = Dataleonlabs.Models.Companies.Documents;

namespace Dataleonlabs.Services.Individuals;

public interface IDocumentService
{
    IDocumentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get documents to an individuals
    /// </summary>
    Task<Documents::DocumentResponse> List(
        DocumentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Upload documents to an individual
    /// </summary>
    Task<Documents::GenericDocument> Upload(
        DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    );
}
