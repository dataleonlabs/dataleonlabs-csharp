using System;
using System.Threading;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Companies.Documents;

namespace Dataleonlabs.Services.Companies;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDocumentService
{
    IDocumentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get documents to an company
    /// </summary>
    Task<DocumentResponse> List(
        DocumentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get documents to an company
    /// </summary>
    Task<DocumentResponse> List(
        string companyID,
        DocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Upload documents to an company
    /// </summary>
    Task<GenericDocument> Upload(
        DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Upload documents to an company
    /// </summary>
    Task<GenericDocument> Upload(
        string companyID,
        DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    );
}
