using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;
using Dataleonlabs.Models.Companies.Documents;
using System = System;

namespace Dataleonlabs.Models.Companies;

[JsonConverter(typeof(JsonModelConverter<CompanyCompany, CompanyCompanyFromRaw>))]
public sealed record class CompanyCompany : JsonModel
{
    /// <summary>
    /// List of AML (Anti-Money Laundering) suspicion entries linked to the company,
    /// including their details.
    /// </summary>
    public IReadOnlyList<AmlSuspicion>? AmlSuspicions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AmlSuspicion>>("aml_suspicions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<AmlSuspicion>?>(
                "aml_suspicions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Digital certificate associated with the company, if any, including its creation
    /// timestamp and filename.
    /// </summary>
    public Certificat? Certificat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Certificat>("certificat");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("certificat", value);
        }
    }

    /// <summary>
    /// List of verification or validation checks applied to the company, including
    /// their results and messages.
    /// </summary>
    public IReadOnlyList<Check>? Checks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Check>>("checks");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Check>?>(
                "checks",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Main information about the company being registered, including legal name,
    /// registration ID, and address.
    /// </summary>
    public CompanyCompanyCompany? Company
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CompanyCompanyCompany>("company");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("company", value);
        }
    }

    /// <summary>
    /// All documents submitted or associated with the company, including their metadata
    /// and processing status.
    /// </summary>
    public IReadOnlyList<GenericDocument>? Documents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<GenericDocument>>("documents");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<GenericDocument>?>(
                "documents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of members or actors associated with the company, including personal
    /// and ownership information.
    /// </summary>
    public IReadOnlyList<Member>? Members
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Member>>("members");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Member>?>(
                "members",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Admin or internal portal URL for viewing the company's details, typically
    /// used by internal users.
    /// </summary>
    public string? PortalUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("portal_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("portal_url", value);
        }
    }

    /// <summary>
    /// Custom key-value metadata fields associated with the company, allowing for
    /// flexible data storage.
    /// </summary>
    public IReadOnlyList<Property>? Properties
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Property>>("properties");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Property>?>(
                "properties",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Risk assessment associated with the company, including a risk code, reason,
    /// and confidence score.
    /// </summary>
    public Risk? Risk
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Risk>("risk");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("risk", value);
        }
    }

    /// <summary>
    /// Optional identifier indicating the source of the company record, useful for
    /// tracking or integration purposes.
    /// </summary>
    public string? SourceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source_id", value);
        }
    }

    /// <summary>
    /// Technical metadata related to the request, such as IP address, QR code settings,
    /// and callback URLs.
    /// </summary>
    public CompanyTechnicalData? TechnicalData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CompanyTechnicalData>("technical_data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("technical_data", value);
        }
    }

    /// <summary>
    /// Public-facing webview URL for the company’s identification process, allowing
    /// external access to the company data.
    /// </summary>
    public string? WebviewUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("webview_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("webview_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.AmlSuspicions ?? [])
        {
            item.Validate();
        }
        this.Certificat?.Validate();
        foreach (var item in this.Checks ?? [])
        {
            item.Validate();
        }
        this.Company?.Validate();
        foreach (var item in this.Documents ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Members ?? [])
        {
            item.Validate();
        }
        _ = this.PortalUrl;
        foreach (var item in this.Properties ?? [])
        {
            item.Validate();
        }
        this.Risk?.Validate();
        _ = this.SourceID;
        this.TechnicalData?.Validate();
        _ = this.WebviewUrl;
    }

    public CompanyCompany() { }

    public CompanyCompany(CompanyCompany companyCompany)
        : base(companyCompany) { }

    public CompanyCompany(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompanyCompany(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CompanyCompanyFromRaw.FromRawUnchecked"/>
    public static CompanyCompany FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CompanyCompanyFromRaw : IFromRawJson<CompanyCompany>
{
    /// <inheritdoc/>
    public CompanyCompany FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CompanyCompany.FromRawUnchecked(rawData);
}

/// <summary>
/// Main information about the company being registered, including legal name, registration
/// ID, and address.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CompanyCompanyCompany, CompanyCompanyCompanyFromRaw>))]
public sealed record class CompanyCompanyCompany : JsonModel
{
    /// <summary>
    /// Full registered address of the company.
    /// </summary>
    public string? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address", value);
        }
    }

    /// <summary>
    /// Closure date of the company, if applicable.
    /// </summary>
    public string? ClosureDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("closure_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("closure_date", value);
        }
    }

    /// <summary>
    /// Trade or commercial name of the company.
    /// </summary>
    public string? CommercialName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("commercial_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("commercial_name", value);
        }
    }

    /// <summary>
    /// Contact information for the company, including email, phone number, and address.
    /// </summary>
    public Contact? Contact
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Contact>("contact");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contact", value);
        }
    }

    /// <summary>
    /// Country code where the company is registered.
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("country", value);
        }
    }

    /// <summary>
    /// Contact email address for the company.
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <summary>
    /// Number of employees in the company.
    /// </summary>
    public long? Employees
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("employees");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("employees", value);
        }
    }

    /// <summary>
    /// Employer Identification Number (EIN) or equivalent.
    /// </summary>
    public string? EmployerIdentificationNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("employer_identification_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("employer_identification_number", value);
        }
    }

    /// <summary>
    /// Indicates whether an insolvency procedure exists for the company.
    /// </summary>
    public bool? InsolvencyExists
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("insolvency_exists");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("insolvency_exists", value);
        }
    }

    /// <summary>
    /// Indicates whether an insolvency procedure is ongoing for the company.
    /// </summary>
    public bool? InsolvencyOngoing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("insolvency_ongoing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("insolvency_ongoing", value);
        }
    }

    /// <summary>
    /// Legal form or structure of the company (e.g., LLC, SARL).
    /// </summary>
    public string? LegalForm
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("legal_form");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("legal_form", value);
        }
    }

    /// <summary>
    /// Legal registered name of the company.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Contact phone number for the company, including country code.
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <summary>
    /// Date when the company was officially registered.
    /// </summary>
    public string? RegistrationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("registration_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("registration_date", value);
        }
    }

    /// <summary>
    /// Official company registration number or ID.
    /// </summary>
    public string? RegistrationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("registration_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("registration_id", value);
        }
    }

    /// <summary>
    /// Total share capital of the company, including currency.
    /// </summary>
    public string? ShareCapital
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("share_capital");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("share_capital", value);
        }
    }

    /// <summary>
    /// Current status of the company (e.g., active, inactive).
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// Tax identification number for the company.
    /// </summary>
    public string? TaxIdentificationNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tax_identification_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tax_identification_number", value);
        }
    }

    /// <summary>
    /// Type of company within the workspace, e.g., main or affiliated.
    /// </summary>
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// Official website URL of the company.
    /// </summary>
    public string? WebsiteUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("website_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("website_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Address;
        _ = this.ClosureDate;
        _ = this.CommercialName;
        this.Contact?.Validate();
        _ = this.Country;
        _ = this.Email;
        _ = this.Employees;
        _ = this.EmployerIdentificationNumber;
        _ = this.InsolvencyExists;
        _ = this.InsolvencyOngoing;
        _ = this.LegalForm;
        _ = this.Name;
        _ = this.PhoneNumber;
        _ = this.RegistrationDate;
        _ = this.RegistrationID;
        _ = this.ShareCapital;
        _ = this.Status;
        _ = this.TaxIdentificationNumber;
        _ = this.Type;
        _ = this.WebsiteUrl;
    }

    public CompanyCompanyCompany() { }

    public CompanyCompanyCompany(CompanyCompanyCompany companyCompanyCompany)
        : base(companyCompanyCompany) { }

    public CompanyCompanyCompany(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompanyCompanyCompany(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CompanyCompanyCompanyFromRaw.FromRawUnchecked"/>
    public static CompanyCompanyCompany FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CompanyCompanyCompanyFromRaw : IFromRawJson<CompanyCompanyCompany>
{
    /// <inheritdoc/>
    public CompanyCompanyCompany FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CompanyCompanyCompany.FromRawUnchecked(rawData);
}

/// <summary>
/// Contact information for the company, including email, phone number, and address.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Contact, ContactFromRaw>))]
public sealed record class Contact : JsonModel
{
    /// <summary>
    /// Department of the contact person.
    /// </summary>
    public string? Department
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("department");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("department", value);
        }
    }

    /// <summary>
    /// Email address of the contact person.
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <summary>
    /// First name of the contact person.
    /// </summary>
    public string? FirstName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("first_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("first_name", value);
        }
    }

    /// <summary>
    /// Last name of the contact person.
    /// </summary>
    public string? LastName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("last_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("last_name", value);
        }
    }

    /// <summary>
    /// Phone number of the contact person.
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Department;
        _ = this.Email;
        _ = this.FirstName;
        _ = this.LastName;
        _ = this.PhoneNumber;
    }

    public Contact() { }

    public Contact(Contact contact)
        : base(contact) { }

    public Contact(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Contact(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContactFromRaw.FromRawUnchecked"/>
    public static Contact FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContactFromRaw : IFromRawJson<Contact>
{
    /// <inheritdoc/>
    public Contact FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Contact.FromRawUnchecked(rawData);
}

/// <summary>
/// Represents a member or actor of a company, including personal and ownership information.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Member, MemberFromRaw>))]
public sealed record class Member : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Address of the member, which may include street, city, postal code, and country.
    /// </summary>
    public string? Address
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("address");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address", value);
        }
    }

    /// <summary>
    /// Birthday (available only if type = person)
    /// </summary>
    public System::DateTimeOffset? Birthday
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("birthday");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("birthday", value);
        }
    }

    /// <summary>
    /// Birthplace (available only if type = person)
    /// </summary>
    public string? Birthplace
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("birthplace");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("birthplace", value);
        }
    }

    /// <summary>
    /// ISO 3166-1 alpha-2 country code of the member's address (e.g., "FR" for France).
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("country", value);
        }
    }

    /// <summary>
    /// List of documents associated with the member, including their metadata and
    /// processing status.
    /// </summary>
    public IReadOnlyList<GenericDocument>? Documents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<GenericDocument>>("documents");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<GenericDocument>?>(
                "documents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Email address of the member, which may be used for communication or verification
    /// purposes.
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <summary>
    /// First name (available only if type = person)
    /// </summary>
    public string? FirstName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("first_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("first_name", value);
        }
    }

    /// <summary>
    /// Indicates whether the member is a beneficial owner of the company, meaning
    /// they have significant control or ownership.
    /// </summary>
    public bool? IsBeneficialOwner
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_beneficial_owner");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_beneficial_owner", value);
        }
    }

    /// <summary>
    /// Indicates whether the member is a delegator, meaning they have authority to
    /// act on behalf of the company.
    /// </summary>
    public bool? IsDelegator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_delegator");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_delegator", value);
        }
    }

    /// <summary>
    /// Last name (available only if type = person)
    /// </summary>
    public string? LastName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("last_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("last_name", value);
        }
    }

    /// <summary>
    /// Indicates whether liveness verification was performed for the member, typically
    /// in the context of identity checks.
    /// </summary>
    public bool? LivenessVerification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("liveness_verification");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("liveness_verification", value);
        }
    }

    /// <summary>
    /// Company name (available only if type = company)
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Percentage of ownership the member has in the company, expressed as an integer
    /// between 0 and 100.
    /// </summary>
    public long? OwnershipPercentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("ownership_percentage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ownership_percentage", value);
        }
    }

    /// <summary>
    /// Contact phone number of the member, including country code and area code.
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <summary>
    /// Postal code of the member's address, typically a numeric or alphanumeric code.
    /// </summary>
    public string? PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("postal_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("postal_code", value);
        }
    }

    /// <summary>
    /// Official registration identifier of the member, such as a national ID or
    /// company registration number.
    /// </summary>
    public string? RegistrationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("registration_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("registration_id", value);
        }
    }

    /// <summary>
    /// Type of relationship the member has with the company, such as "shareholder",
    /// "director", or "beneficial_owner".
    /// </summary>
    public string? Relation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("relation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("relation", value);
        }
    }

    /// <summary>
    /// Role of the member within the company, such as "legal_representative", "director",
    /// or "manager".
    /// </summary>
    public string? Roles
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("roles");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("roles", value);
        }
    }

    /// <summary>
    /// Source of the data (e.g., government, user, company)
    /// </summary>
    public ApiEnum<string, Source>? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Source>>("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    /// <summary>
    /// Current state of the member in the workflow, such as "WAITING", "STARTED",
    /// "RUNNING", or "PROCESSED".
    /// </summary>
    public string? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("state", value);
        }
    }

    /// <summary>
    /// Status of the member in the system, indicating whether they are approved,
    /// pending, or rejected. Possible values include "approved", "need_review",
    /// "rejected".
    /// </summary>
    public string? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// Member type (person or company)
    /// </summary>
    public ApiEnum<string, MemberType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MemberType>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// Identifier of the workspace to which the member belongs, used for organizational
    /// purposes.
    /// </summary>
    public string? WorkspaceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("workspace_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("workspace_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Address;
        _ = this.Birthday;
        _ = this.Birthplace;
        _ = this.Country;
        foreach (var item in this.Documents ?? [])
        {
            item.Validate();
        }
        _ = this.Email;
        _ = this.FirstName;
        _ = this.IsBeneficialOwner;
        _ = this.IsDelegator;
        _ = this.LastName;
        _ = this.LivenessVerification;
        _ = this.Name;
        _ = this.OwnershipPercentage;
        _ = this.PhoneNumber;
        _ = this.PostalCode;
        _ = this.RegistrationID;
        _ = this.Relation;
        _ = this.Roles;
        this.Source?.Validate();
        _ = this.State;
        _ = this.Status;
        this.Type?.Validate();
        _ = this.WorkspaceID;
    }

    public Member() { }

    public Member(Member member)
        : base(member) { }

    public Member(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Member(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MemberFromRaw.FromRawUnchecked"/>
    public static Member FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MemberFromRaw : IFromRawJson<Member>
{
    /// <inheritdoc/>
    public Member FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Member.FromRawUnchecked(rawData);
}

/// <summary>
/// Source of the data (e.g., government, user, company)
/// </summary>
[JsonConverter(typeof(SourceConverter))]
public enum Source
{
    Gouve,
    User,
    Company,
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "gouve" => Source.Gouve,
            "user" => Source.User,
            "company" => Source.Company,
            _ => (Source)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Source.Gouve => "gouve",
                Source.User => "user",
                Source.Company => "company",
                _ => throw new DataleonlabsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Member type (person or company)
/// </summary>
[JsonConverter(typeof(MemberTypeConverter))]
public enum MemberType
{
    Person,
    Company,
}

sealed class MemberTypeConverter : JsonConverter<MemberType>
{
    public override MemberType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "person" => MemberType.Person,
            "company" => MemberType.Company,
            _ => (MemberType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MemberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MemberType.Person => "person",
                MemberType.Company => "company",
                _ => throw new DataleonlabsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
