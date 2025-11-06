using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Companies.Documents;
using Companies = Dataleonlabs.Models.Companies;

namespace Dataleonlabs.Models.Individuals;

/// <summary>
/// Represents a single individual record, including identification, status, and
/// associated metadata.
/// </summary>
[JsonConverter(typeof(ModelConverter<Individual>))]
public sealed record class Individual : ModelBase, IFromRaw<Individual>
{
    /// <summary>
    /// Unique identifier of the individual.
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
    /// List of AML (Anti-Money Laundering) suspicion entries linked to the individual.
    /// </summary>
    public List<Companies::AmlSuspicion>? AmlSuspicions
    {
        get
        {
            if (!this.Properties.TryGetValue("aml_suspicions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Companies::AmlSuspicion>?>(
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
    /// URL to authenticate the individual, usually for document signing or onboarding.
    /// </summary>
    public string? AuthURL
    {
        get
        {
            if (!this.Properties.TryGetValue("auth_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["auth_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Digital certificate associated with the individual, if any.
    /// </summary>
    public Companies::Certificat? Certificat
    {
        get
        {
            if (!this.Properties.TryGetValue("certificat", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Companies::Certificat?>(
                element,
                ModelBase.SerializerOptions
            );
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
    /// List of verification or validation checks applied to the individual.
    /// </summary>
    public List<Companies::Check>? Checks
    {
        get
        {
            if (!this.Properties.TryGetValue("checks", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Companies::Check>?>(
                element,
                ModelBase.SerializerOptions
            );
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
    /// Timestamp of the individual's creation in ISO 8601 format.
    /// </summary>
    public DateTime? CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// All documents submitted or associated with the individual.
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
    /// Reference to the individual's identity document.
    /// </summary>
    public IdentityCard? IdentityCard
    {
        get
        {
            if (!this.Properties.TryGetValue("identity_card", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<IdentityCard?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["identity_card"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Internal sequential number or reference for the individual.
    /// </summary>
    public long? Number
    {
        get
        {
            if (!this.Properties.TryGetValue("number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Personal details of the individual, such as name, date of birth, and contact info.
    /// </summary>
    public Person1? Person
    {
        get
        {
            if (!this.Properties.TryGetValue("person", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Person1?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["person"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Admin or internal portal URL for viewing the individual's details.
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
    /// Custom key-value metadata fields associated with the individual.
    /// </summary>
    public List<Companies::Property>? Properties1
    {
        get
        {
            if (!this.Properties.TryGetValue("properties", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Companies::Property>?>(
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
    /// Risk assessment associated with the individual.
    /// </summary>
    public Companies::Risk? Risk
    {
        get
        {
            if (!this.Properties.TryGetValue("risk", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Companies::Risk?>(
                element,
                ModelBase.SerializerOptions
            );
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
    /// Optional identifier indicating the source of the individual record.
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
    /// Current operational state in the workflow (e.g., WAITING, IN_PROGRESS, COMPLETED).
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
    /// Overall processing status of the individual (e.g., rejected, need_review, approved).
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
    /// List of tags assigned to the individual for categorization or metadata purposes.
    /// </summary>
    public List<Tag>? Tags
    {
        get
        {
            if (!this.Properties.TryGetValue("tags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Tag>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["tags"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Technical metadata related to the request (e.g., QR code settings, language).
    /// </summary>
    public Companies::TechnicalData1? TechnicalData
    {
        get
        {
            if (!this.Properties.TryGetValue("technical_data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Companies::TechnicalData1?>(
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
    /// Public-facing webview URL for the individual’s identification process.
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

    /// <summary>
    /// Identifier of the workspace to which the individual belongs.
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
        foreach (var item in this.AmlSuspicions ?? [])
        {
            item.Validate();
        }
        _ = this.AuthURL;
        this.Certificat?.Validate();
        foreach (var item in this.Checks ?? [])
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        foreach (var item in this.Documents ?? [])
        {
            item.Validate();
        }
        this.IdentityCard?.Validate();
        _ = this.Number;
        this.Person?.Validate();
        _ = this.PortalURL;
        foreach (var item in this.Properties1 ?? [])
        {
            item.Validate();
        }
        this.Risk?.Validate();
        _ = this.SourceID;
        _ = this.State;
        _ = this.Status;
        foreach (var item in this.Tags ?? [])
        {
            item.Validate();
        }
        this.TechnicalData?.Validate();
        _ = this.WebviewURL;
        _ = this.WorkspaceID;
    }

    public Individual() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Individual(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Individual FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

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

/// <summary>
/// Personal details of the individual, such as name, date of birth, and contact info.
/// </summary>
[JsonConverter(typeof(ModelConverter<Person1>))]
public sealed record class Person1 : ModelBase, IFromRaw<Person1>
{
    /// <summary>
    /// Date of birth, formatted as DD/MM/YYYY.
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
    /// Email address of the individual.
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
    /// Signed URL linking to the person’s face image.
    /// </summary>
    public string? FaceImageSignedURL
    {
        get
        {
            if (!this.Properties.TryGetValue("face_image_signed_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["face_image_signed_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// First (given) name of the person.
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
    /// Full name of the person, typically concatenation of first and last names.
    /// </summary>
    public string? FullName
    {
        get
        {
            if (!this.Properties.TryGetValue("full_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["full_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Gender of the individual (e.g., "M" for male, "F" for female).
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
    /// Last (family) name of the person.
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
    /// Maiden name of the person, if applicable.
    /// </summary>
    public string? MaidenName
    {
        get
        {
            if (!this.Properties.TryGetValue("maiden_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["maiden_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Nationality of the individual (ISO 3166-1 alpha-3 country code).
    /// </summary>
    public string? Nationality
    {
        get
        {
            if (!this.Properties.TryGetValue("nationality", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["nationality"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Contact phone number including country code.
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
        _ = this.Birthday;
        _ = this.Email;
        _ = this.FaceImageSignedURL;
        _ = this.FirstName;
        _ = this.FullName;
        _ = this.Gender;
        _ = this.LastName;
        _ = this.MaidenName;
        _ = this.Nationality;
        _ = this.PhoneNumber;
    }

    public Person1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Person1(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Person1 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

/// <summary>
/// Represents a key-value metadata tag that can be associated with entities such
/// as individuals or companies.
/// </summary>
[JsonConverter(typeof(ModelConverter<Tag>))]
public sealed record class Tag : ModelBase, IFromRaw<Tag>
{
    /// <summary>
    /// Name of the tag used to identify the metadata field.
    /// </summary>
    public string? Key
    {
        get
        {
            if (!this.Properties.TryGetValue("key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Indicates whether the tag is private (not visible to external users).
    /// </summary>
    public bool? Private
    {
        get
        {
            if (!this.Properties.TryGetValue("private", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["private"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Data type of the tag value (e.g., "string", "number", "boolean").
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
    /// Value assigned to the tag.
    /// </summary>
    public string? Value
    {
        get
        {
            if (!this.Properties.TryGetValue("value", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Key;
        _ = this.Private;
        _ = this.Type;
        _ = this.Value;
    }

    public Tag() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tag(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Tag FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
