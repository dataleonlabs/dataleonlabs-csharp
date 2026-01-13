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
    /// Get documents to an individuals
    /// </summary>
    Task<Documents::DocumentResponse> List(
        DocumentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(DocumentListParams, CancellationToken)"/>
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

    /// <inheritdoc cref="Upload(DocumentUploadParams, CancellationToken)"/>
    Task<Documents::GenericDocument> Upload(
        string individualID,
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
    /// Returns a raw HTTP response for `get /individuals/{individual_id}/documents`, but is otherwise the
    /// same as <see cref="IDocumentService.List(DocumentListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Documents::DocumentResponse>> List(
        DocumentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(DocumentListParams, CancellationToken)"/>
    Task<HttpResponse<Documents::DocumentResponse>> List(
        string individualID,
        DocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /individuals/{individual_id}/documents`, but is otherwise the
    /// same as <see cref="IDocumentService.Upload(DocumentUploadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Documents::GenericDocument>> Upload(
        DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Upload(DocumentUploadParams, CancellationToken)"/>
    Task<HttpResponse<Documents::GenericDocument>> Upload(
        string individualID,
        DocumentUploadParams parameters,
        CancellationToken cancellationToken = default
    );
}
