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

    /// <summary>
    /// Get an individual by ID
    /// </summary>
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

    /// <summary>
    /// Update an individual by ID
    /// </summary>
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

    /// <summary>
    /// Delete an individual by ID
    /// </summary>
    Task Delete(
        string individualID,
        IndividualDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
