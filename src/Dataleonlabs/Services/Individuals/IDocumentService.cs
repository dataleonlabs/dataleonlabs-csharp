using System;
using System.Threading;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Individuals.Documents;
using Documents = Dataleonlabs.Models.Companies.Documents;

namespace Dataleonlabs.Services.Individuals;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
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
    /// Get documents to an individuals
    /// </summary>
    Task<Documents::DocumentResponse> List(
        string individualID,
        DocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Upload documents to an individual
    /// </summary>
    Task<Documents::GenericDocument> Upload(
        DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Upload documents to an individual
    /// </summary>
    Task<Documents::GenericDocument> Upload(
        string individualID,
        DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    );
}
