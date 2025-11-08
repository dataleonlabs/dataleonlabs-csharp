using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Individuals;
using Dataleonlabs.Services.Individuals.Documents;

namespace Dataleonlabs.Services.Individuals;

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
    /// Update an individual by ID
    /// </summary>
    Task<Individual> Update(
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
}
