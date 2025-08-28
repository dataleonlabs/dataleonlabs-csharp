using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dataleonlabs.Models.Individuals.IndividualProperties;

/// <summary>
/// Reference to the individual's identity document.
/// </summary>
[JsonConverter(typeof(ModelConverter<IdentityCard>))]
public sealed record class IdentityCard : ModelBase, IFromRaw<IdentityCard>
{
    /// <summary>
    /// Unique identifier for the document.
    /// </summary>
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
    /// Signed URL linking to the back image of the document.
    /// </summary>
    public string? BackDocumentSignedURL
    {
        get
        {
            if (!this.Properties.TryGetValue("back_document_signed_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["back_document_signed_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Place of birth as indicated on the document.
    /// </summary>
    public string? BirthPlace
    {
        get
        {
            if (!this.Properties.TryGetValue("birth_place", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["birth_place"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Date of birth in DD/MM/YYYY format as shown on the document.
    /// </summary>
    public string? Birthday
    {
        get
        {
            if (!this.Properties.TryGetValue("birthday", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
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
    /// Country code issuing the document (ISO 3166-1 alpha-2).
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
    /// Expiration date of the document, in YYYY-MM-DD format.
    /// </summary>
    public string? ExpirationDate
    {
        get
        {
            if (!this.Properties.TryGetValue("expiration_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["expiration_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// First name as shown on the document.
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
    /// Signed URL linking to the front image of the document.
    /// </summary>
    public string? FrontDocumentSignedURL
    {
        get
        {
            if (!this.Properties.TryGetValue("front_document_signed_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["front_document_signed_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Gender indicated on the document (e.g., "M" or "F").
    /// </summary>
    public string? Gender
    {
        get
        {
            if (!this.Properties.TryGetValue("gender", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["gender"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Date when the document was issued, in YYYY-MM-DD format.
    /// </summary>
    public string? IssueDate
    {
        get
        {
            if (!this.Properties.TryGetValue("issue_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["issue_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Last name as shown on the document.
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
    /// First line of the Machine Readable Zone (MRZ) on the document.
    /// </summary>
    public string? MrzLine1
    {
        get
        {
            if (!this.Properties.TryGetValue("mrz_line_1", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["mrz_line_1"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Second line of the MRZ on the document.
    /// </summary>
    public string? MrzLine2
    {
        get
        {
            if (!this.Properties.TryGetValue("mrz_line_2", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["mrz_line_2"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Third line of the MRZ if applicable; otherwise null.
    /// </summary>
    public string? MrzLine3
    {
        get
        {
            if (!this.Properties.TryGetValue("mrz_line_3", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["mrz_line_3"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Type of document (e.g., passport, identity card).
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

    public override void Validate()
    {
        _ = this.ID;
        _ = this.BackDocumentSignedURL;
        _ = this.BirthPlace;
        _ = this.Birthday;
        _ = this.Country;
        _ = this.ExpirationDate;
        _ = this.FirstName;
        _ = this.FrontDocumentSignedURL;
        _ = this.Gender;
        _ = this.IssueDate;
        _ = this.LastName;
        _ = this.MrzLine1;
        _ = this.MrzLine2;
        _ = this.MrzLine3;
        _ = this.Type;
    }

    public IdentityCard() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IdentityCard(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static IdentityCard FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
