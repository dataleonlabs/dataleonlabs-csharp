using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Individuals;
using Dataleonlabs.Services.Individuals;

namespace Dataleonlabs.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IIndividualService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IIndividualServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIndividualService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDocumentService Documents { get; }

    /// <summary>
    /// Create a new individual
    /// </summary>
    Task<Individual> Create(
        IndividualCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get an individual by ID
    /// </summary>
    Task<Individual> Retrieve(
        IndividualRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(IndividualRetrieveParams, CancellationToken)"/>
    Task<Individual> Retrieve(
        string individualID,
        IndividualRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an individual by ID
    /// </summary>
    Task<Individual> Update(
        IndividualUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(IndividualUpdateParams, CancellationToken)"/>
    Task<Individual> Update(
        string individualID,
        IndividualUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get all individuals
    /// </summary>
    Task<List<Individual>> List(
        IndividualListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an individual by ID
    /// </summary>
    Task Delete(IndividualDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(IndividualDeleteParams, CancellationToken)"/>
    Task Delete(
        string individualID,
        IndividualDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IIndividualService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IIndividualServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIndividualServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDocumentServiceWithRawResponse Documents { get; }

    /// <summary>
    /// Returns a raw HTTP response for `post /individuals`, but is otherwise the
    /// same as <see cref="IIndividualService.Create(IndividualCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Individual>> Create(
        IndividualCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /individuals/{individual_id}`, but is otherwise the
    /// same as <see cref="IIndividualService.Retrieve(IndividualRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Individual>> Retrieve(
        IndividualRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(IndividualRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Individual>> Retrieve(
        string individualID,
        IndividualRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /individuals/{individual_id}`, but is otherwise the
    /// same as <see cref="IIndividualService.Update(IndividualUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Individual>> Update(
        IndividualUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(IndividualUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Individual>> Update(
        string individualID,
        IndividualUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /individuals`, but is otherwise the
    /// same as <see cref="IIndividualService.List(IndividualListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<Individual>>> List(
        IndividualListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /individuals/{individual_id}`, but is otherwise the
    /// same as <see cref="IIndividualService.Delete(IndividualDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        IndividualDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(IndividualDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string individualID,
        IndividualDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
