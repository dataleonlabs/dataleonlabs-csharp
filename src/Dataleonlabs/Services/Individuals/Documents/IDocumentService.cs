using System;
using System.Threading;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Companies.Documents;
using Documents = Dataleonlabs.Models.Individuals.Documents;

namespace Dataleonlabs.Services.Individuals.Documents;

public interface IDocumentService
{
    IDocumentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get documents to an individuals
    /// </summary>
    Task<DocumentResponse> List(
        Documents::DocumentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Upload documents to an individual
    /// </summary>
    Task<GenericDocument> Upload(
        Documents::DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    );
}
