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
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICompanyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
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

    /// <inheritdoc cref="Retrieve(CompanyRetrieveParams, CancellationToken)"/>
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

    /// <inheritdoc cref="Update(CompanyUpdateParams, CancellationToken)"/>
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

    /// <inheritdoc cref="Delete(CompanyDeleteParams, CancellationToken)"/>
    Task Delete(
        string companyID,
        CompanyDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICompanyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICompanyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICompanyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDocumentServiceWithRawResponse Documents { get; }

    /// <summary>
    /// Returns a raw HTTP response for `post /companies`, but is otherwise the
    /// same as <see cref="ICompanyService.Create(CompanyCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CompanyCompany>> Create(
        CompanyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /companies/{company_id}`, but is otherwise the
    /// same as <see cref="ICompanyService.Retrieve(CompanyRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CompanyCompany>> Retrieve(
        CompanyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CompanyRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CompanyCompany>> Retrieve(
        string companyID,
        CompanyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /companies/{company_id}`, but is otherwise the
    /// same as <see cref="ICompanyService.Update(CompanyUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CompanyCompany>> Update(
        CompanyUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CompanyUpdateParams, CancellationToken)"/>
    Task<HttpResponse<CompanyCompany>> Update(
        string companyID,
        CompanyUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /companies`, but is otherwise the
    /// same as <see cref="ICompanyService.List(CompanyListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<CompanyCompany>>> List(
        CompanyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /companies/{company_id}`, but is otherwise the
    /// same as <see cref="ICompanyService.Delete(CompanyDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        CompanyDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(CompanyDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string companyID,
        CompanyDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
