using System.Collections.Generic;
using System.Threading.Tasks;
using Dataleonlabs.Models.Companies;
using Dataleonlabs.Services.Companies.Documents;

namespace Dataleonlabs.Services.Companies;

public interface ICompanyService
{
    IDocumentService Documents { get; }

    /// <summary>
    /// Create a new company
    /// </summary>
    Task<Company> Create(CompanyCreateParams parameters);

    /// <summary>
    /// Get a company by ID
    /// </summary>
    Task<Company> Retrieve(CompanyRetrieveParams parameters);

    /// <summary>
    /// Update a company by ID
    /// </summary>
    Task<Company> Update(CompanyUpdateParams parameters);

    /// <summary>
    /// Get all companies
    /// </summary>
    Task<List<Company>> List(CompanyListParams? parameters = null);

    /// <summary>
    /// Delete a company by ID
    /// </summary>
    Task Delete(CompanyDeleteParams parameters);
}
