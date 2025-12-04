using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;
using Dataleonlabs.Models.Companies.Documents;
using System = System;

namespace Dataleonlabs.Models.Companies;

[JsonConverter(typeof(ModelConverter<CompanyCompany, CompanyCompanyFromRaw>))]
public sealed record class CompanyCompany : ModelBase
{
    /// <summary>
    /// List of AML (Anti-Money Laundering) suspicion entries linked to the company,
    /// including their details.
    /// </summary>
    public IReadOnlyList<AmlSuspicion>? AmlSuspicions
    {
        get
        {
            return ModelBase.GetNullableClass<List<AmlSuspicion>>(this.RawData, "aml_suspicions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "aml_suspicions", value);
        }
    }

    /// <summary>
    /// Digital certificate associated with the company, if any, including its creation
    /// timestamp and filename.
    /// </summary>
    public Certificat? Certificat
    {
        get { return ModelBase.GetNullableClass<Certificat>(this.RawData, "certificat"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "certificat", value);
        }
    }

    /// <summary>
    /// List of verification or validation checks applied to the company, including
    /// their results and messages.
    /// </summary>
    public IReadOnlyList<Check>? Checks
    {
        get { return ModelBase.GetNullableClass<List<Check>>(this.RawData, "checks"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "checks", value);
        }
    }

    /// <summary>
    /// Main information about the company being registered, including legal name,
    /// registration ID, and address.
    /// </summary>
    public CompanyCompanyCompany? Company
    {
        get { return ModelBase.GetNullableClass<CompanyCompanyCompany>(this.RawData, "company"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "company", value);
        }
    }

    /// <summary>
    /// All documents submitted or associated with the company, including their metadata
    /// and processing status.
    /// </summary>
    public IReadOnlyList<GenericDocument>? Documents
    {
        get { return ModelBase.GetNullableClass<List<GenericDocument>>(this.RawData, "documents"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "documents", value);
        }
    }

    /// <summary>
    /// List of members or actors associated with the company, including personal
    /// and ownership information.
    /// </summary>
    public IReadOnlyList<Member>? Members
    {
        get { return ModelBase.GetNullableClass<List<Member>>(this.RawData, "members"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "members", value);
        }
    }

    /// <summary>
    /// Admin or internal portal URL for viewing the company's details, typically
    /// used by internal users.
    /// </summary>
    public string? PortalURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "portal_url"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "portal_url", value);
        }
    }

    /// <summary>
    /// Custom key-value metadata fields associated with the company, allowing for
    /// flexible data storage.
    /// </summary>
    public IReadOnlyList<Property>? Properties
    {
        get { return ModelBase.GetNullableClass<List<Property>>(this.RawData, "properties"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "properties", value);
        }
    }

    /// <summary>
    /// Risk assessment associated with the company, including a risk code, reason,
    /// and confidence score.
    /// </summary>
    public Risk? Risk
    {
        get { return ModelBase.GetNullableClass<Risk>(this.RawData, "risk"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "risk", value);
        }
    }

    /// <summary>
    /// Optional identifier indicating the source of the company record, useful for
    /// tracking or integration purposes.
    /// </summary>
    public string? SourceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "source_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "source_id", value);
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
            return ModelBase.GetNullableClass<CompanyTechnicalData>(this.RawData, "technical_data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "technical_data", value);
        }
    }

    /// <summary>
    /// Public-facing webview URL for the company’s identification process, allowing
    /// external access to the company data.
    /// </summary>
    public string? WebviewURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "webview_url"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "webview_url", value);
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
        _ = this.PortalURL;
        foreach (var item in this.Properties ?? [])
        {
            item.Validate();
        }
        this.Risk?.Validate();
        _ = this.SourceID;
        this.TechnicalData?.Validate();
        _ = this.WebviewURL;
    }

    public CompanyCompany() { }

    public CompanyCompany(CompanyCompany companyCompany)
        : base(companyCompany) { }

    public CompanyCompany(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompanyCompany(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CompanyCompanyFromRaw.FromRawUnchecked"/>
    public static CompanyCompany FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CompanyCompanyFromRaw : IFromRaw<CompanyCompany>
{
    /// <inheritdoc/>
    public CompanyCompany FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CompanyCompany.FromRawUnchecked(rawData);
}

/// <summary>
/// Main information about the company being registered, including legal name, registration
/// ID, and address.
/// </summary>
[JsonConverter(typeof(ModelConverter<CompanyCompanyCompany, CompanyCompanyCompanyFromRaw>))]
public sealed record class CompanyCompanyCompany : ModelBase
{
    /// <summary>
    /// Full registered address of the company.
    /// </summary>
    public string? Address
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "address"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "address", value);
        }
    }

    /// <summary>
    /// Closure date of the company, if applicable.
    /// </summary>
    public
#if NET
    System::DateOnly
#else
    System::DateTimeOffset
#endif
    ? ClosureDate
    {
        get { return ModelBase.GetNullableStruct<
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
#endif
            >(this.RawData, "closure_date"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "closure_date", value);
        }
    }

    /// <summary>
    /// Trade or commercial name of the company.
    /// </summary>
    public string? CommercialName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "commercial_name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "commercial_name", value);
        }
    }

    /// <summary>
    /// Contact information for the company, including email, phone number, and address.
    /// </summary>
    public Contact? Contact
    {
        get { return ModelBase.GetNullableClass<Contact>(this.RawData, "contact"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "contact", value);
        }
    }

    /// <summary>
    /// Country code where the company is registered.
    /// </summary>
    public string? Country
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "country"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "country", value);
        }
    }

    /// <summary>
    /// Contact email address for the company.
    /// </summary>
    public string? Email
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "email"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "email", value);
        }
    }

    /// <summary>
    /// Number of employees in the company.
    /// </summary>
    public long? Employees
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "employees"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "employees", value);
        }
    }

    /// <summary>
    /// Employer Identification Number (EIN) or equivalent.
    /// </summary>
    public string? EmployerIdentificationNumber
    {
        get
        {
            return ModelBase.GetNullableClass<string>(
                this.RawData,
                "employer_identification_number"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "employer_identification_number", value);
        }
    }

    /// <summary>
    /// Indicates whether an insolvency procedure exists for the company.
    /// </summary>
    public bool? InsolvencyExists
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "insolvency_exists"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "insolvency_exists", value);
        }
    }

    /// <summary>
    /// Indicates whether an insolvency procedure is ongoing for the company.
    /// </summary>
    public bool? InsolvencyOngoing
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "insolvency_ongoing"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "insolvency_ongoing", value);
        }
    }

    /// <summary>
    /// Legal form or structure of the company (e.g., LLC, SARL).
    /// </summary>
    public string? LegalForm
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "legal_form"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "legal_form", value);
        }
    }

    /// <summary>
    /// Legal registered name of the company.
    /// </summary>
    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "name", value);
        }
    }

    /// <summary>
    /// Contact phone number for the company, including country code.
    /// </summary>
    public string? PhoneNumber
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "phone_number"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "phone_number", value);
        }
    }

    /// <summary>
    /// Date when the company was officially registered.
    /// </summary>
    public
#if NET
    System::DateOnly
#else
    System::DateTimeOffset
#endif
    ? RegistrationDate
    {
        get
        {
            return ModelBase.GetNullableStruct<
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
#endif
            >(this.RawData, "registration_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "registration_date", value);
        }
    }

    /// <summary>
    /// Official company registration number or ID.
    /// </summary>
    public string? RegistrationID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "registration_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "registration_id", value);
        }
    }

    /// <summary>
    /// Total share capital of the company, including currency.
    /// </summary>
    public string? ShareCapital
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "share_capital"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "share_capital", value);
        }
    }

    /// <summary>
    /// Current status of the company (e.g., active, inactive).
    /// </summary>
    public string? Status
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "status"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "status", value);
        }
    }

    /// <summary>
    /// Tax identification number for the company.
    /// </summary>
    public string? TaxIdentificationNumber
    {
        get
        {
            return ModelBase.GetNullableClass<string>(this.RawData, "tax_identification_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "tax_identification_number", value);
        }
    }

    /// <summary>
    /// Type of company within the workspace, e.g., main or affiliated.
    /// </summary>
    public string? Type
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "type"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "type", value);
        }
    }

    /// <summary>
    /// Official website URL of the company.
    /// </summary>
    public string? WebsiteURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "website_url"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "website_url", value);
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
        _ = this.WebsiteURL;
    }

    public CompanyCompanyCompany() { }

    public CompanyCompanyCompany(CompanyCompanyCompany companyCompanyCompany)
        : base(companyCompanyCompany) { }

    public CompanyCompanyCompany(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompanyCompanyCompany(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class CompanyCompanyCompanyFromRaw : IFromRaw<CompanyCompanyCompany>
{
    /// <inheritdoc/>
    public CompanyCompanyCompany FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CompanyCompanyCompany.FromRawUnchecked(rawData);
}

/// <summary>
/// Contact information for the company, including email, phone number, and address.
/// </summary>
[JsonConverter(typeof(ModelConverter<Contact, ContactFromRaw>))]
public sealed record class Contact : ModelBase
{
    /// <summary>
    /// Department of the contact person.
    /// </summary>
    public string? Department
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "department"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "department", value);
        }
    }

    /// <summary>
    /// Email address of the contact person.
    /// </summary>
    public string? Email
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "email"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "email", value);
        }
    }

    /// <summary>
    /// First name of the contact person.
    /// </summary>
    public string? FirstName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "first_name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "first_name", value);
        }
    }

    /// <summary>
    /// Last name of the contact person.
    /// </summary>
    public string? LastName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "last_name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "last_name", value);
        }
    }

    /// <summary>
    /// Phone number of the contact person.
    /// </summary>
    public string? PhoneNumber
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "phone_number"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "phone_number", value);
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Contact(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContactFromRaw.FromRawUnchecked"/>
    public static Contact FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContactFromRaw : IFromRaw<Contact>
{
    /// <inheritdoc/>
    public Contact FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Contact.FromRawUnchecked(rawData);
}

/// <summary>
/// Represents a member or actor of a company, including personal and ownership information.
/// </summary>
[JsonConverter(typeof(ModelConverter<Member, MemberFromRaw>))]
public sealed record class Member : ModelBase
{
    public string? ID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "id", value);
        }
    }

    /// <summary>
    /// Address of the member, which may include street, city, postal code, and country.
    /// </summary>
    public string? Address
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "address"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "address", value);
        }
    }

    /// <summary>
    /// Birthday (available only if type = person)
    /// </summary>
    public System::DateTimeOffset? Birthday
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(this.RawData, "birthday");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "birthday", value);
        }
    }

    /// <summary>
    /// Birthplace (available only if type = person)
    /// </summary>
    public string? Birthplace
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "birthplace"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "birthplace", value);
        }
    }

    /// <summary>
    /// ISO 3166-1 alpha-2 country code of the member's address (e.g., "FR" for France).
    /// </summary>
    public string? Country
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "country"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "country", value);
        }
    }

    /// <summary>
    /// List of documents associated with the member, including their metadata and
    /// processing status.
    /// </summary>
    public IReadOnlyList<GenericDocument>? Documents
    {
        get { return ModelBase.GetNullableClass<List<GenericDocument>>(this.RawData, "documents"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "documents", value);
        }
    }

    /// <summary>
    /// Email address of the member, which may be used for communication or verification
    /// purposes.
    /// </summary>
    public string? Email
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "email"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "email", value);
        }
    }

    /// <summary>
    /// First name (available only if type = person)
    /// </summary>
    public string? FirstName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "first_name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "first_name", value);
        }
    }

    /// <summary>
    /// Indicates whether the member is a beneficial owner of the company, meaning
    /// they have significant control or ownership.
    /// </summary>
    public bool? IsBeneficialOwner
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "is_beneficial_owner"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "is_beneficial_owner", value);
        }
    }

    /// <summary>
    /// Indicates whether the member is a delegator, meaning they have authority to
    /// act on behalf of the company.
    /// </summary>
    public bool? IsDelegator
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "is_delegator"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "is_delegator", value);
        }
    }

    /// <summary>
    /// Last name (available only if type = person)
    /// </summary>
    public string? LastName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "last_name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "last_name", value);
        }
    }

    /// <summary>
    /// Indicates whether liveness verification was performed for the member, typically
    /// in the context of identity checks.
    /// </summary>
    public bool? LivenessVerification
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "liveness_verification"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "liveness_verification", value);
        }
    }

    /// <summary>
    /// Company name (available only if type = company)
    /// </summary>
    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "name", value);
        }
    }

    /// <summary>
    /// Percentage of ownership the member has in the company, expressed as an integer
    /// between 0 and 100.
    /// </summary>
    public long? OwnershipPercentage
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "ownership_percentage"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "ownership_percentage", value);
        }
    }

    /// <summary>
    /// Contact phone number of the member, including country code and area code.
    /// </summary>
    public string? PhoneNumber
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "phone_number"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "phone_number", value);
        }
    }

    /// <summary>
    /// Postal code of the member's address, typically a numeric or alphanumeric code.
    /// </summary>
    public string? PostalCode
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "postal_code"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "postal_code", value);
        }
    }

    /// <summary>
    /// Official registration identifier of the member, such as a national ID or
    /// company registration number.
    /// </summary>
    public string? RegistrationID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "registration_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "registration_id", value);
        }
    }

    /// <summary>
    /// Type of relationship the member has with the company, such as "shareholder",
    /// "director", or "beneficial_owner".
    /// </summary>
    public string? Relation
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "relation"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "relation", value);
        }
    }

    /// <summary>
    /// Role of the member within the company, such as "legal_representative", "director",
    /// or "manager".
    /// </summary>
    public string? Roles
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "roles"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "roles", value);
        }
    }

    /// <summary>
    /// Source of the data (e.g., government, user, company)
    /// </summary>
    public ApiEnum<string, Source>? Source
    {
        get { return ModelBase.GetNullableClass<ApiEnum<string, Source>>(this.RawData, "source"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "source", value);
        }
    }

    /// <summary>
    /// Current state of the member in the workflow, such as "WAITING", "STARTED",
    /// "RUNNING", or "PROCESSED".
    /// </summary>
    public string? State
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "state"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "state", value);
        }
    }

    /// <summary>
    /// Status of the member in the system, indicating whether they are approved,
    /// pending, or rejected. Possible values include "approved", "need_review",
    /// "rejected".
    /// </summary>
    public string? Status
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "status"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "status", value);
        }
    }

    /// <summary>
    /// Member type (person or company)
    /// </summary>
    public ApiEnum<string, MemberType>? Type
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, MemberType>>(this.RawData, "type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "type", value);
        }
    }

    /// <summary>
    /// Identifier of the workspace to which the member belongs, used for organizational
    /// purposes.
    /// </summary>
    public string? WorkspaceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "workspace_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "workspace_id", value);
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Member(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MemberFromRaw.FromRawUnchecked"/>
    public static Member FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MemberFromRaw : IFromRaw<Member>
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
