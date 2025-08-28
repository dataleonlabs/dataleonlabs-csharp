using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Models.Companies.Documents;
using MemberProperties = Dataleonlabs.Models.Companies.CompanyProperties.MemberProperties;

namespace Dataleonlabs.Models.Companies.CompanyProperties;

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
    public DateTime? Birthday
    {
        get
        {
            if (!this.Properties.TryGetValue("birthday", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
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
    public ApiEnum<string, MemberProperties::Source>? Source
    {
        get
        {
            if (!this.Properties.TryGetValue("source", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, MemberProperties::Source>?>(
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
    public ApiEnum<string, MemberProperties::Type>? Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, MemberProperties::Type>?>(
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
