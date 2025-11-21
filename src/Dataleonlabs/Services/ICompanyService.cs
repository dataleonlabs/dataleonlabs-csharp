using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Companies;
using Dataleonlabs.Services.Companies;

namespace Dataleonlabs.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
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
    /// Get a company by ID
    /// </summary>
    Task<CompanyCompany> Retrieve(
        string companyID,
        CompanyRetrieveParams? parameters = null,
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
    /// Update a company by ID
    /// </summary>
    Task<CompanyCompany> Update(
        string companyID,
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

    /// <summary>
    /// Delete a company by ID
    /// </summary>
    Task Delete(
        string companyID,
        CompanyDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
