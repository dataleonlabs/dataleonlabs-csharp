using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dataleonlabs.Models.Companies.CompanyProperties.CompanyProperties;

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
