using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;
using Dataleonlabs.Models.Companies.Documents;
using System = System;

namespace Dataleonlabs.Models.Companies;

[JsonConverter(typeof(ModelConverter<Company1>))]
public sealed record class Company1 : ModelBase, IFromRaw<Company1>
{
    /// <summary>
    /// List of AML (Anti-Money Laundering) suspicion entries linked to the company,
    /// including their details.
    /// </summary>
    public List<AmlSuspicion>? AmlSuspicions
    {
        get
        {
            if (!this.Properties.TryGetValue("aml_suspicions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AmlSuspicion>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["aml_suspicions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this.Properties.TryGetValue("certificat", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Certificat?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["certificat"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of verification or validation checks applied to the company, including
    /// their results and messages.
    /// </summary>
    public List<Check>? Checks
    {
        get
        {
            if (!this.Properties.TryGetValue("checks", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Check>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["checks"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Main information about the company being registered, including legal name,
    /// registration ID, and address.
    /// </summary>
    public Company2? Company
    {
        get
        {
            if (!this.Properties.TryGetValue("company", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Company2?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["company"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// All documents submitted or associated with the company, including their metadata
    /// and processing status.
    /// </summary>
    public List<GenericDocument>? Documents
    {
        get
        {
            if (!this.Properties.TryGetValue("documents", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<GenericDocument>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["documents"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of members or actors associated with the company, including personal
    /// and ownership information.
    /// </summary>
    public List<Member>? Members
    {
        get
        {
            if (!this.Properties.TryGetValue("members", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Member>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["members"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Admin or internal portal URL for viewing the company's details, typically
    /// used by internal users.
    /// </summary>
    public string? PortalURL
    {
        get
        {
            if (!this.Properties.TryGetValue("portal_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["portal_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Custom key-value metadata fields associated with the company, allowing for
    /// flexible data storage.
    /// </summary>
    public List<Property>? Properties1
    {
        get
        {
            if (!this.Properties.TryGetValue("properties", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Property>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["properties"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this.Properties.TryGetValue("risk", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Risk?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["risk"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("source_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["source_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Technical metadata related to the request, such as IP address, QR code settings,
    /// and callback URLs.
    /// </summary>
    public TechnicalData1? TechnicalData
    {
        get
        {
            if (!this.Properties.TryGetValue("technical_data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<TechnicalData1?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["technical_data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Public-facing webview URL for the company’s identification process, allowing
    /// external access to the company data.
    /// </summary>
    public string? WebviewURL
    {
        get
        {
            if (!this.Properties.TryGetValue("webview_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["webview_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
        foreach (var item in this.Properties1 ?? [])
        {
            item.Validate();
        }
        this.Risk?.Validate();
        _ = this.SourceID;
        this.TechnicalData?.Validate();
        _ = this.WebviewURL;
    }

    public Company1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Company1(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Company1 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

/// <summary>
/// Main information about the company being registered, including legal name, registration
/// ID, and address.
/// </summary>
[JsonConverter(typeof(ModelConverter<Company2>))]
public sealed record class Company2 : ModelBase, IFromRaw<Company2>
{
    /// <summary>
    /// Full registered address of the company.
    /// </summary>
    public string? Address
    {
        get
        {
            if (!this.Properties.TryGetValue("address", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["address"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Closure date of the company, if applicable.
    /// </summary>
    public System::DateOnly? ClosureDate
    {
        get
        {
            if (!this.Properties.TryGetValue("closure_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateOnly?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["closure_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Trade or commercial name of the company.
    /// </summary>
    public string? CommercialName
    {
        get
        {
            if (!this.Properties.TryGetValue("commercial_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["commercial_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Contact information for the company, including email, phone number, and address.
    /// </summary>
    public Contact? Contact
    {
        get
        {
            if (!this.Properties.TryGetValue("contact", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Contact?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["contact"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Country code where the company is registered.
    /// </summary>
    public string? Country
    {
        get
        {
            if (!this.Properties.TryGetValue("country", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["country"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Contact email address for the company.
    /// </summary>
    public string? Email
    {
        get
        {
            if (!this.Properties.TryGetValue("email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["email"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of employees in the company.
    /// </summary>
    public long? Employees
    {
        get
        {
            if (!this.Properties.TryGetValue("employees", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["employees"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Employer Identification Number (EIN) or equivalent.
    /// </summary>
    public string? EmployerIdentificationNumber
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "employer_identification_number",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["employer_identification_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Indicates whether an insolvency procedure exists for the company.
    /// </summary>
    public bool? InsolvencyExists
    {
        get
        {
            if (!this.Properties.TryGetValue("insolvency_exists", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["insolvency_exists"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Indicates whether an insolvency procedure is ongoing for the company.
    /// </summary>
    public bool? InsolvencyOngoing
    {
        get
        {
            if (!this.Properties.TryGetValue("insolvency_ongoing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["insolvency_ongoing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Legal form or structure of the company (e.g., LLC, SARL).
    /// </summary>
    public string? LegalForm
    {
        get
        {
            if (!this.Properties.TryGetValue("legal_form", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["legal_form"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Legal registered name of the company.
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Contact phone number for the company, including country code.
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            if (!this.Properties.TryGetValue("phone_number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["phone_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Date when the company was officially registered.
    /// </summary>
    public System::DateOnly? RegistrationDate
    {
        get
        {
            if (!this.Properties.TryGetValue("registration_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateOnly?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["registration_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Official company registration number or ID.
    /// </summary>
    public string? RegistrationID
    {
        get
        {
            if (!this.Properties.TryGetValue("registration_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["registration_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Total share capital of the company, including currency.
    /// </summary>
    public string? ShareCapital
    {
        get
        {
            if (!this.Properties.TryGetValue("share_capital", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["share_capital"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Current status of the company (e.g., active, inactive).
    /// </summary>
    public string? Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tax identification number for the company.
    /// </summary>
    public string? TaxIdentificationNumber
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_identification_number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["tax_identification_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Type of company within the workspace, e.g., main or affiliated.
    /// </summary>
    public string? Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Official website URL of the company.
    /// </summary>
    public string? WebsiteURL
    {
        get
        {
            if (!this.Properties.TryGetValue("website_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["website_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public Company2() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Company2(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Company2 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

/// <summary>
/// Contact information for the company, including email, phone number, and address.
/// </summary>
[JsonConverter(typeof(ModelConverter<Contact>))]
public sealed record class Contact : ModelBase, IFromRaw<Contact>
{
    /// <summary>
    /// Department of the contact person.
    /// </summary>
    public string? Department
    {
        get
        {
            if (!this.Properties.TryGetValue("department", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["department"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Email address of the contact person.
    /// </summary>
    public string? Email
    {
        get
        {
            if (!this.Properties.TryGetValue("email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["email"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// First name of the contact person.
    /// </summary>
    public string? FirstName
    {
        get
        {
            if (!this.Properties.TryGetValue("first_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["first_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Last name of the contact person.
    /// </summary>
    public string? LastName
    {
        get
        {
            if (!this.Properties.TryGetValue("last_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["last_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Phone number of the contact person.
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            if (!this.Properties.TryGetValue("phone_number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["phone_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Department;
        _ = this.Email;
        _ = this.FirstName;
        _ = this.LastName;
        _ = this.PhoneNumber;
    }

    public Contact() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Contact(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Contact FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

/// <summary>
/// Represents a member or actor of a company, including personal and ownership information.
/// </summary>
[JsonConverter(typeof(ModelConverter<Member>))]
public sealed record class Member : ModelBase, IFromRaw<Member>
{
    public string? ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Address of the member, which may include street, city, postal code, and country.
    /// </summary>
    public string? Address
    {
        get
        {
            if (!this.Properties.TryGetValue("address", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["address"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Birthday (available only if type = person)
    /// </summary>
    public System::DateTime? Birthday
    {
        get
        {
            if (!this.Properties.TryGetValue("birthday", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["birthday"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Birthplace (available only if type = person)
    /// </summary>
    public string? Birthplace
    {
        get
        {
            if (!this.Properties.TryGetValue("birthplace", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["birthplace"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// ISO 3166-1 alpha-2 country code of the member's address (e.g., "FR" for France).
    /// </summary>
    public string? Country
    {
        get
        {
            if (!this.Properties.TryGetValue("country", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["country"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of documents associated with the member, including their metadata and
    /// processing status.
    /// </summary>
    public List<GenericDocument>? Documents
    {
        get
        {
            if (!this.Properties.TryGetValue("documents", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<GenericDocument>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["documents"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this.Properties.TryGetValue("email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["email"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// First name (available only if type = person)
    /// </summary>
    public string? FirstName
    {
        get
        {
            if (!this.Properties.TryGetValue("first_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["first_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("is_beneficial_owner", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["is_beneficial_owner"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Indicates whether the member is a delegator, meaning they have authority
    /// to act on behalf of the company.
    /// </summary>
    public bool? IsDelegator
    {
        get
        {
            if (!this.Properties.TryGetValue("is_delegator", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["is_delegator"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Last name (available only if type = person)
    /// </summary>
    public string? LastName
    {
        get
        {
            if (!this.Properties.TryGetValue("last_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["last_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("liveness_verification", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["liveness_verification"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Company name (available only if type = company)
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("ownership_percentage", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ownership_percentage"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Contact phone number of the member, including country code and area code.
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            if (!this.Properties.TryGetValue("phone_number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["phone_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Postal code of the member's address, typically a numeric or alphanumeric
    /// code.
    /// </summary>
    public string? PostalCode
    {
        get
        {
            if (!this.Properties.TryGetValue("postal_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["postal_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Official registration identifier of the member, such as a national ID or company
    /// registration number.
    /// </summary>
    public string? RegistrationID
    {
        get
        {
            if (!this.Properties.TryGetValue("registration_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["registration_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("relation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["relation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("roles", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["roles"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Source of the data (e.g., government, user, company)
    /// </summary>
    public ApiEnum<string, Source>? Source
    {
        get
        {
            if (!this.Properties.TryGetValue("source", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Source>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("state", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["state"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Status of the member in the system, indicating whether they are approved,
    /// pending, or rejected. Possible values include "approved", "need_review", "rejected".
    /// </summary>
    public string? Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Member type (person or company)
    /// </summary>
    public ApiEnum<string, TypeModel>? Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, TypeModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("workspace_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["workspace_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Member(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Member FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
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
[JsonConverter(typeof(TypeModelConverter))]
public enum TypeModel
{
    Person,
    Company,
}

sealed class TypeModelConverter : JsonConverter<TypeModel>
{
    public override TypeModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "person" => TypeModel.Person,
            "company" => TypeModel.Company,
            _ => (TypeModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TypeModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TypeModel.Person => "person",
                TypeModel.Company => "company",
                _ => throw new DataleonlabsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
