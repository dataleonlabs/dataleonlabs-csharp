using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Companies;
using Dataleonlabs.Models.Companies.Documents;

namespace Dataleonlabs.Models.Individuals;

/// <summary>
/// Represents a single individual record, including identification, status, and associated metadata.
/// </summary>
[JsonConverter(typeof(ModelConverter<Individual, IndividualFromRaw>))]
public sealed record class Individual : ModelBase
{
    /// <summary>
    /// Unique identifier of the individual.
    /// </summary>
    public string? ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of AML (Anti-Money Laundering) suspicion entries linked to the individual.
    /// </summary>
    public IReadOnlyList<AmlSuspicion>? AmlSuspicions
    {
        get
        {
            if (!this._rawData.TryGetValue("aml_suspicions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AmlSuspicion>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["aml_suspicions"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("auth_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["auth_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Digital certificate associated with the individual, if any.
    /// </summary>
    public Certificat? Certificat
    {
        get
        {
            if (!this._rawData.TryGetValue("certificat", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Certificat?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["certificat"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of verification or validation checks applied to the individual.
    /// </summary>
    public IReadOnlyList<Check>? Checks
    {
        get
        {
            if (!this._rawData.TryGetValue("checks", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Check>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["checks"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp of the individual's creation in ISO 8601 format.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("created_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// All documents submitted or associated with the individual.
    /// </summary>
    public IReadOnlyList<GenericDocument>? Documents
    {
        get
        {
            if (!this._rawData.TryGetValue("documents", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<GenericDocument>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["documents"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("identity_card", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<IdentityCard?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["identity_card"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Personal details of the individual, such as name, date of birth, and contact info.
    /// </summary>
    public IndividualPerson? Person
    {
        get
        {
            if (!this._rawData.TryGetValue("person", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<IndividualPerson?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["person"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("portal_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["portal_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Custom key-value metadata fields associated with the individual.
    /// </summary>
    public IReadOnlyList<Property>? Properties
    {
        get
        {
            if (!this._rawData.TryGetValue("properties", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Property>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["properties"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Risk assessment associated with the individual.
    /// </summary>
    public Risk? Risk
    {
        get
        {
            if (!this._rawData.TryGetValue("risk", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Risk?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["risk"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("source_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["source_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("state", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["state"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of tags assigned to the individual for categorization or metadata purposes.
    /// </summary>
    public IReadOnlyList<Tag>? Tags
    {
        get
        {
            if (!this._rawData.TryGetValue("tags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Tag>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["tags"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Technical metadata related to the request (e.g., QR code settings, language).
    /// </summary>
    public CompanyTechnicalData? TechnicalData
    {
        get
        {
            if (!this._rawData.TryGetValue("technical_data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CompanyTechnicalData?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["technical_data"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("webview_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["webview_url"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("workspace_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["workspace_id"] = JsonSerializer.SerializeToElement(
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
        foreach (var item in this.Properties ?? [])
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

    public Individual(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Individual(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Individual FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IndividualFromRaw : IFromRaw<Individual>
{
    public Individual FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Individual.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to the individual's identity document.
/// </summary>
[JsonConverter(typeof(ModelConverter<IdentityCard, IdentityCardFromRaw>))]
public sealed record class IdentityCard : ModelBase
{
    /// <summary>
    /// Unique identifier for the document.
    /// </summary>
    public string? ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["id"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("back_document_signed_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["back_document_signed_url"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("birth_place", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["birth_place"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("birthday", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["birthday"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("country", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["country"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("expiration_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["expiration_date"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("first_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["first_name"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("front_document_signed_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["front_document_signed_url"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("gender", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["gender"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("issue_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["issue_date"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("last_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["last_name"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("mrz_line_1", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["mrz_line_1"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("mrz_line_2", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["mrz_line_2"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("mrz_line_3", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["mrz_line_3"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["type"] = JsonSerializer.SerializeToElement(
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

    public IdentityCard(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IdentityCard(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static IdentityCard FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IdentityCardFromRaw : IFromRaw<IdentityCard>
{
    public IdentityCard FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IdentityCard.FromRawUnchecked(rawData);
}

/// <summary>
/// Personal details of the individual, such as name, date of birth, and contact info.
/// </summary>
[JsonConverter(typeof(ModelConverter<IndividualPerson, IndividualPersonFromRaw>))]
public sealed record class IndividualPerson : ModelBase
{
    /// <summary>
    /// Date of birth, formatted as DD/MM/YYYY.
    /// </summary>
    public string? Birthday
    {
        get
        {
            if (!this._rawData.TryGetValue("birthday", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["birthday"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["email"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("face_image_signed_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["face_image_signed_url"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("first_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["first_name"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("full_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["full_name"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("gender", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["gender"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("last_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["last_name"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("maiden_name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["maiden_name"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("nationality", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["nationality"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("phone_number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["phone_number"] = JsonSerializer.SerializeToElement(
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

    public IndividualPerson() { }

    public IndividualPerson(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IndividualPerson(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static IndividualPerson FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IndividualPersonFromRaw : IFromRaw<IndividualPerson>
{
    public IndividualPerson FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IndividualPerson.FromRawUnchecked(rawData);
}

/// <summary>
/// Represents a key-value metadata tag that can be associated with entities such
/// as individuals or companies.
/// </summary>
[JsonConverter(typeof(ModelConverter<Tag, TagFromRaw>))]
public sealed record class Tag : ModelBase
{
    /// <summary>
    /// Name of the tag used to identify the metadata field.
    /// </summary>
    public string? Key
    {
        get
        {
            if (!this._rawData.TryGetValue("key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["key"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("private", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["private"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["type"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("value", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["value"] = JsonSerializer.SerializeToElement(
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

    public Tag(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tag(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Tag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TagFromRaw : IFromRaw<Tag>
{
    public Tag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tag.FromRawUnchecked(rawData);
}
