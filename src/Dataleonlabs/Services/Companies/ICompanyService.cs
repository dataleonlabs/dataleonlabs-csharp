using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Services.Companies.Documents;
using Companies = Dataleonlabs.Models.Companies;

namespace Dataleonlabs.Services.Companies;

public interface ICompanyService
{
    ICompanyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDocumentService Documents { get; }

    /// <summary>
    /// Create a new company
    /// </summary>
    Task<Companies::Company1> Create(Companies::CompanyCreateParams parameters);

    /// <summary>
    /// Get a company by ID
    /// </summary>
    Task<Companies::Company1> Retrieve(Companies::CompanyRetrieveParams parameters);

    /// <summary>
    /// Update a company by ID
    /// </summary>
    Task<Companies::Company1> Update(Companies::CompanyUpdateParams parameters);

    /// <summary>
    /// Get all companies
    /// </summary>
    Task<List<Companies::Company1>> List(Companies::CompanyListParams? parameters = null);

    /// <summary>
    /// Delete a company by ID
    /// </summary>
    Task Delete(Companies::CompanyDeleteParams parameters);
}
