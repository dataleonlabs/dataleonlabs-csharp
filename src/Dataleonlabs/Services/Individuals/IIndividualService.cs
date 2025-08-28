using System.Collections.Generic;
using System.Threading.Tasks;
using Dataleonlabs.Models.Individuals;
using Dataleonlabs.Services.Individuals.Documents;

namespace Dataleonlabs.Services.Individuals;

public interface IIndividualService
{
    IDocumentService Documents { get; }

    /// <summary>
    /// Create a new individual
    /// </summary>
    Task<Individual> Create(IndividualCreateParams parameters);

    /// <summary>
    /// Get an individual by ID
    /// </summary>
    Task<Individual> Retrieve(IndividualRetrieveParams parameters);

    /// <summary>
    /// Update an individual by ID
    /// </summary>
    Task<Individual> Update(IndividualUpdateParams parameters);

    /// <summary>
    /// Get all individuals
    /// </summary>
    Task<List<Individual>> List(IndividualListParams? parameters = null);

    /// <summary>
    /// Delete an individual by ID
    /// </summary>
    Task Delete(IndividualDeleteParams parameters);
}
