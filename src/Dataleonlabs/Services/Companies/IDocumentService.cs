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
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDocumentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDocumentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get documents to an company
    /// </summary>
    Task<DocumentResponse> List(
        DocumentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(DocumentListParams, CancellationToken)"/>
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

    /// <inheritdoc cref="Upload(DocumentUploadParams, CancellationToken)"/>
    Task<GenericDocument> Upload(
        string companyID,
        DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDocumentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDocumentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDocumentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /companies/{company_id}/documents`, but is otherwise the
    /// same as <see cref="IDocumentService.List(DocumentListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DocumentResponse>> List(
        DocumentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(DocumentListParams, CancellationToken)"/>
    Task<HttpResponse<DocumentResponse>> List(
        string companyID,
        DocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /companies/{company_id}/documents`, but is otherwise the
    /// same as <see cref="IDocumentService.Upload(DocumentUploadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<GenericDocument>> Upload(
        DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Upload(DocumentUploadParams, CancellationToken)"/>
    Task<HttpResponse<GenericDocument>> Upload(
        string companyID,
        DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    );
}
