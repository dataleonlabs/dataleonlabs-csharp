using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Models.Companies.CompanyProperties.CompanyProperties;

namespace Dataleonlabs.Models.Companies.CompanyProperties;

/// <summary>
/// Main information about the company being registered, including legal name, registration
/// ID, and address.
/// </summary>
[JsonConverter(typeof(ModelConverter<Company>))]
public sealed record class Company : ModelBase, IFromRaw<Company>
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
    public DateOnly? ClosureDate
    {
        get
        {
            if (!this.Properties.TryGetValue("closure_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateOnly?>(element, ModelBase.SerializerOptions);
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
    public DateOnly? RegistrationDate
    {
        get
        {
            if (!this.Properties.TryGetValue("registration_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateOnly?>(element, ModelBase.SerializerOptions);
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

    public Company() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Company(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Company FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
