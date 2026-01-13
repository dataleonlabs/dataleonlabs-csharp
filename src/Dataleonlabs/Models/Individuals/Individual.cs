using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
[JsonConverter(typeof(JsonModelConverter<Individual, IndividualFromRaw>))]
public sealed record class Individual : JsonModel
{
    /// <summary>
    /// Unique identifier of the individual.
    /// </summary>
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
    /// List of AML (Anti-Money Laundering) suspicion entries linked to the individual.
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
    /// URL to authenticate the individual, usually for document signing or onboarding.
    /// </summary>
    public string? AuthUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("auth_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("auth_url", value);
        }
    }

    /// <summary>
    /// Digital certificate associated with the individual, if any.
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
    /// List of verification or validation checks applied to the individual.
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
    /// Timestamp of the individual's creation in ISO 8601 format.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// All documents submitted or associated with the individual.
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
    /// Reference to the individual's identity document.
    /// </summary>
    public IdentityCard? IdentityCard
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IdentityCard>("identity_card");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("identity_card", value);
        }
    }

    /// <summary>
    /// Internal sequential number or reference for the individual.
    /// </summary>
    public long? Number
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("number", value);
        }
    }

    /// <summary>
    /// Personal details of the individual, such as name, date of birth, and contact info.
    /// </summary>
    public IndividualPerson? Person
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<IndividualPerson>("person");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("person", value);
        }
    }

    /// <summary>
    /// Admin or internal portal URL for viewing the individual's details.
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
    /// Custom key-value metadata fields associated with the individual.
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
    /// Risk assessment associated with the individual.
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
    /// Optional identifier indicating the source of the individual record.
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
    /// Current operational state in the workflow (e.g., WAITING, IN_PROGRESS, COMPLETED).
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
    /// Overall processing status of the individual (e.g., rejected, need_review, approved).
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
    /// List of tags assigned to the individual for categorization or metadata purposes.
    /// </summary>
    public IReadOnlyList<Tag>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Tag>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Tag>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
    /// Public-facing webview URL for the individual’s identification process.
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

    /// <summary>
    /// Identifier of the workspace to which the individual belongs.
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
        foreach (var item in this.AmlSuspicions ?? [])
        {
            item.Validate();
        }
        _ = this.AuthUrl;
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
        _ = this.PortalUrl;
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
        _ = this.WebviewUrl;
        _ = this.WorkspaceID;
    }

    public Individual() { }

    public Individual(Individual individual)
        : base(individual) { }

    public Individual(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Individual(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IndividualFromRaw.FromRawUnchecked"/>
    public static Individual FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IndividualFromRaw : IFromRawJson<Individual>
{
    /// <inheritdoc/>
    public Individual FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Individual.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to the individual's identity document.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<IdentityCard, IdentityCardFromRaw>))]
public sealed record class IdentityCard : JsonModel
{
    /// <summary>
    /// Unique identifier for the document.
    /// </summary>
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
    /// Signed URL linking to the back image of the document.
    /// </summary>
    public string? BackDocumentSignedUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("back_document_signed_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("back_document_signed_url", value);
        }
    }

    /// <summary>
    /// Place of birth as indicated on the document.
    /// </summary>
    public string? BirthPlace
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("birth_place");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("birth_place", value);
        }
    }

    /// <summary>
    /// Date of birth in DD/MM/YYYY format as shown on the document.
    /// </summary>
    public string? Birthday
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("birthday");
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
    /// Country code issuing the document (ISO 3166-1 alpha-2).
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
    /// Date of entitlement or validity start date, in YYYY-MM-DD format.
    /// </summary>
    public string? EntitlementDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("entitlement_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("entitlement_date", value);
        }
    }

    /// <summary>
    /// Expiration date of the document, in YYYY-MM-DD format.
    /// </summary>
    public string? ExpirationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("expiration_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expiration_date", value);
        }
    }

    /// <summary>
    /// First name as shown on the document.
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
    /// Signed URL linking to the front image of the document.
    /// </summary>
    public string? FrontDocumentSignedUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("front_document_signed_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("front_document_signed_url", value);
        }
    }

    /// <summary>
    /// Gender indicated on the document (e.g., "M" or "F").
    /// </summary>
    public string? Gender
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("gender");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("gender", value);
        }
    }

    /// <summary>
    /// Date when the document was issued, in YYYY-MM-DD format.
    /// </summary>
    public string? IssueDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("issue_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("issue_date", value);
        }
    }

    /// <summary>
    /// Last name as shown on the document.
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
    /// First line of the Machine Readable Zone (MRZ) on the document.
    /// </summary>
    public string? MrzLine1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mrz_line_1");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mrz_line_1", value);
        }
    }

    /// <summary>
    /// Second line of the MRZ on the document.
    /// </summary>
    public string? MrzLine2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mrz_line_2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mrz_line_2", value);
        }
    }

    /// <summary>
    /// Third line of the MRZ if applicable; otherwise null.
    /// </summary>
    public string? MrzLine3
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mrz_line_3");
        }
        init { this._rawData.Set("mrz_line_3", value); }
    }

    /// <summary>
    /// Type of document (e.g., passport, identity card).
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BackDocumentSignedUrl;
        _ = this.BirthPlace;
        _ = this.Birthday;
        _ = this.Country;
        _ = this.EntitlementDate;
        _ = this.ExpirationDate;
        _ = this.FirstName;
        _ = this.FrontDocumentSignedUrl;
        _ = this.Gender;
        _ = this.IssueDate;
        _ = this.LastName;
        _ = this.MrzLine1;
        _ = this.MrzLine2;
        _ = this.MrzLine3;
        _ = this.Type;
    }

    public IdentityCard() { }

    public IdentityCard(IdentityCard identityCard)
        : base(identityCard) { }

    public IdentityCard(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IdentityCard(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IdentityCardFromRaw.FromRawUnchecked"/>
    public static IdentityCard FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IdentityCardFromRaw : IFromRawJson<IdentityCard>
{
    /// <inheritdoc/>
    public IdentityCard FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IdentityCard.FromRawUnchecked(rawData);
}

/// <summary>
/// Personal details of the individual, such as name, date of birth, and contact info.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<IndividualPerson, IndividualPersonFromRaw>))]
public sealed record class IndividualPerson : JsonModel
{
    /// <summary>
    /// Date of birth, formatted as DD/MM/YYYY.
    /// </summary>
    public string? Birthday
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("birthday");
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
    /// Email address of the individual.
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
    /// Signed URL linking to the person’s face image.
    /// </summary>
    public string? FaceImageSignedUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("face_image_signed_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("face_image_signed_url", value);
        }
    }

    /// <summary>
    /// First (given) name of the person.
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
    /// Full name of the person, typically concatenation of first and last names.
    /// </summary>
    public string? FullName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("full_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("full_name", value);
        }
    }

    /// <summary>
    /// Gender of the individual (e.g., "M" for male, "F" for female).
    /// </summary>
    public string? Gender
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("gender");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("gender", value);
        }
    }

    /// <summary>
    /// Last (family) name of the person.
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
    /// Maiden name of the person, if applicable.
    /// </summary>
    public string? MaidenName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("maiden_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("maiden_name", value);
        }
    }

    /// <summary>
    /// Nationality of the individual (ISO 3166-1 alpha-3 country code).
    /// </summary>
    public string? Nationality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nationality");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("nationality", value);
        }
    }

    /// <summary>
    /// Contact phone number including country code.
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
        _ = this.Birthday;
        _ = this.Email;
        _ = this.FaceImageSignedUrl;
        _ = this.FirstName;
        _ = this.FullName;
        _ = this.Gender;
        _ = this.LastName;
        _ = this.MaidenName;
        _ = this.Nationality;
        _ = this.PhoneNumber;
    }

    public IndividualPerson() { }

    public IndividualPerson(IndividualPerson individualPerson)
        : base(individualPerson) { }

    public IndividualPerson(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IndividualPerson(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IndividualPersonFromRaw.FromRawUnchecked"/>
    public static IndividualPerson FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IndividualPersonFromRaw : IFromRawJson<IndividualPerson>
{
    /// <inheritdoc/>
    public IndividualPerson FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IndividualPerson.FromRawUnchecked(rawData);
}

/// <summary>
/// Represents a key-value metadata tag that can be associated with entities such
/// as individuals or companies.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Tag, TagFromRaw>))]
public sealed record class Tag : JsonModel
{
    /// <summary>
    /// Name of the tag used to identify the metadata field.
    /// </summary>
    public string? Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("key", value);
        }
    }

    /// <summary>
    /// Indicates whether the tag is private (not visible to external users).
    /// </summary>
    public bool? Private
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("private");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("private", value);
        }
    }

    /// <summary>
    /// Data type of the tag value (e.g., "string", "number", "boolean").
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
    /// Value assigned to the tag.
    /// </summary>
    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Key;
        _ = this.Private;
        _ = this.Type;
        _ = this.Value;
    }

    public Tag() { }

    public Tag(Tag tag)
        : base(tag) { }

    public Tag(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tag(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TagFromRaw.FromRawUnchecked"/>
    public static Tag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TagFromRaw : IFromRawJson<Tag>
{
    /// <inheritdoc/>
    public Tag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tag.FromRawUnchecked(rawData);
}
