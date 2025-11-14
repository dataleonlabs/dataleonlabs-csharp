using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Companies;
using Dataleonlabs.Services.Companies;

namespace Dataleonlabs.Services;

public interface ICompanyService
{
    ICompanyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDocumentService Documents { get; }

    /// <summary>
    /// Create a new company
    /// </summary>
    Task<CompanyCompany> Create(
        CompanyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a company by ID
    /// </summary>
    Task<CompanyCompany> Retrieve(
        CompanyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a company by ID
    /// </summary>
    Task<CompanyCompany> Update(
        CompanyUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get all companies
    /// </summary>
    Task<List<CompanyCompany>> List(
        CompanyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a company by ID
    /// </summary>
    Task Delete(CompanyDeleteParams parameters, CancellationToken cancellationToken = default);
}
