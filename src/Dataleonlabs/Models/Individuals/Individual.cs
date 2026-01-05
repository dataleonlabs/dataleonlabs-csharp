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
[JsonConverter(typeof(JsonModelConverter<Individual, IndividualFromRaw>))]
public sealed record class Individual : JsonModel
{
    /// <summary>
    /// Unique identifier of the individual.
    /// </summary>
    public string? ID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "id", value);
        }
    }

    /// <summary>
    /// List of AML (Anti-Money Laundering) suspicion entries linked to the individual.
    /// </summary>
    public IReadOnlyList<AmlSuspicion>? AmlSuspicions
    {
        get
        {
            return JsonModel.GetNullableClass<List<AmlSuspicion>>(this.RawData, "aml_suspicions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "aml_suspicions", value);
        }
    }

    /// <summary>
    /// URL to authenticate the individual, usually for document signing or onboarding.
    /// </summary>
    public string? AuthURL
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "auth_url"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "auth_url", value);
        }
    }

    /// <summary>
    /// Digital certificate associated with the individual, if any.
    /// </summary>
    public Certificat? Certificat
    {
        get { return JsonModel.GetNullableClass<Certificat>(this.RawData, "certificat"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "certificat", value);
        }
    }

    /// <summary>
    /// List of verification or validation checks applied to the individual.
    /// </summary>
    public IReadOnlyList<Check>? Checks
    {
        get { return JsonModel.GetNullableClass<List<Check>>(this.RawData, "checks"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "checks", value);
        }
    }

    /// <summary>
    /// Timestamp of the individual's creation in ISO 8601 format.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get { return JsonModel.GetNullableStruct<DateTimeOffset>(this.RawData, "created_at"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "created_at", value);
        }
    }

    /// <summary>
    /// All documents submitted or associated with the individual.
    /// </summary>
    public IReadOnlyList<GenericDocument>? Documents
    {
        get { return JsonModel.GetNullableClass<List<GenericDocument>>(this.RawData, "documents"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "documents", value);
        }
    }

    /// <summary>
    /// Reference to the individual's identity document.
    /// </summary>
    public IdentityCard? IdentityCard
    {
        get { return JsonModel.GetNullableClass<IdentityCard>(this.RawData, "identity_card"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "identity_card", value);
        }
    }

    /// <summary>
    /// Internal sequential number or reference for the individual.
    /// </summary>
    public long? Number
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "number"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "number", value);
        }
    }

    /// <summary>
    /// Personal details of the individual, such as name, date of birth, and contact info.
    /// </summary>
    public IndividualPerson? Person
    {
        get { return JsonModel.GetNullableClass<IndividualPerson>(this.RawData, "person"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "person", value);
        }
    }

    /// <summary>
    /// Admin or internal portal URL for viewing the individual's details.
    /// </summary>
    public string? PortalURL
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "portal_url"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "portal_url", value);
        }
    }

    /// <summary>
    /// Custom key-value metadata fields associated with the individual.
    /// </summary>
    public IReadOnlyList<Property>? Properties
    {
        get { return JsonModel.GetNullableClass<List<Property>>(this.RawData, "properties"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "properties", value);
        }
    }

    /// <summary>
    /// Risk assessment associated with the individual.
    /// </summary>
    public Risk? Risk
    {
        get { return JsonModel.GetNullableClass<Risk>(this.RawData, "risk"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "risk", value);
        }
    }

    /// <summary>
    /// Optional identifier indicating the source of the individual record.
    /// </summary>
    public string? SourceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "source_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "source_id", value);
        }
    }

    /// <summary>
    /// Current operational state in the workflow (e.g., WAITING, IN_PROGRESS, COMPLETED).
    /// </summary>
    public string? State
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "state"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "state", value);
        }
    }

    /// <summary>
    /// Overall processing status of the individual (e.g., rejected, need_review, approved).
    /// </summary>
    public string? Status
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "status"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "status", value);
        }
    }

    /// <summary>
    /// List of tags assigned to the individual for categorization or metadata purposes.
    /// </summary>
    public IReadOnlyList<Tag>? Tags
    {
        get { return JsonModel.GetNullableClass<List<Tag>>(this.RawData, "tags"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "tags", value);
        }
    }

    /// <summary>
    /// Technical metadata related to the request (e.g., QR code settings, language).
    /// </summary>
    public CompanyTechnicalData? TechnicalData
    {
        get
        {
            return JsonModel.GetNullableClass<CompanyTechnicalData>(this.RawData, "technical_data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "technical_data", value);
        }
    }

    /// <summary>
    /// Public-facing webview URL for the individual’s identification process.
    /// </summary>
    public string? WebviewURL
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "webview_url"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "webview_url", value);
        }
    }

    /// <summary>
    /// Identifier of the workspace to which the individual belongs.
    /// </summary>
    public string? WorkspaceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "workspace_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "workspace_id", value);
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

    public Individual(Individual individual)
        : base(individual) { }

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
        get { return JsonModel.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "id", value);
        }
    }

    /// <summary>
    /// Signed URL linking to the back image of the document.
    /// </summary>
    public string? BackDocumentSignedURL
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "back_document_signed_url"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "back_document_signed_url", value);
        }
    }

    /// <summary>
    /// Place of birth as indicated on the document.
    /// </summary>
    public string? BirthPlace
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "birth_place"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "birth_place", value);
        }
    }

    /// <summary>
    /// Date of birth in DD/MM/YYYY format as shown on the document.
    /// </summary>
    public string? Birthday
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "birthday"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "birthday", value);
        }
    }

    /// <summary>
    /// Country code issuing the document (ISO 3166-1 alpha-2).
    /// </summary>
    public string? Country
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "country"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "country", value);
        }
    }

    /// <summary>
    /// Date of entitlement or validity start date, in YYYY-MM-DD format.
    /// </summary>
    public string? EntitlementDate
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "entitlement_date"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "entitlement_date", value);
        }
    }

    /// <summary>
    /// Expiration date of the document, in YYYY-MM-DD format.
    /// </summary>
    public string? ExpirationDate
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "expiration_date"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "expiration_date", value);
        }
    }

    /// <summary>
    /// First name as shown on the document.
    /// </summary>
    public string? FirstName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "first_name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "first_name", value);
        }
    }

    /// <summary>
    /// Signed URL linking to the front image of the document.
    /// </summary>
    public string? FrontDocumentSignedURL
    {
        get
        {
            return JsonModel.GetNullableClass<string>(this.RawData, "front_document_signed_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "front_document_signed_url", value);
        }
    }

    /// <summary>
    /// Gender indicated on the document (e.g., "M" or "F").
    /// </summary>
    public string? Gender
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "gender"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "gender", value);
        }
    }

    /// <summary>
    /// Date when the document was issued, in YYYY-MM-DD format.
    /// </summary>
    public string? IssueDate
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "issue_date"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "issue_date", value);
        }
    }

    /// <summary>
    /// Last name as shown on the document.
    /// </summary>
    public string? LastName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "last_name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "last_name", value);
        }
    }

    /// <summary>
    /// First line of the Machine Readable Zone (MRZ) on the document.
    /// </summary>
    public string? MrzLine1
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "mrz_line_1"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "mrz_line_1", value);
        }
    }

    /// <summary>
    /// Second line of the MRZ on the document.
    /// </summary>
    public string? MrzLine2
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "mrz_line_2"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "mrz_line_2", value);
        }
    }

    /// <summary>
    /// Third line of the MRZ if applicable; otherwise null.
    /// </summary>
    public string? MrzLine3
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "mrz_line_3"); }
        init { JsonModel.Set(this._rawData, "mrz_line_3", value); }
    }

    /// <summary>
    /// Type of document (e.g., passport, identity card).
    /// </summary>
    public string? Type
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "type"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BackDocumentSignedURL;
        _ = this.BirthPlace;
        _ = this.Birthday;
        _ = this.Country;
        _ = this.EntitlementDate;
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

    public IdentityCard(IdentityCard identityCard)
        : base(identityCard) { }

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
        get { return JsonModel.GetNullableClass<string>(this.RawData, "birthday"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "birthday", value);
        }
    }

    /// <summary>
    /// Email address of the individual.
    /// </summary>
    public string? Email
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "email"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "email", value);
        }
    }

    /// <summary>
    /// Signed URL linking to the person’s face image.
    /// </summary>
    public string? FaceImageSignedURL
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "face_image_signed_url"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "face_image_signed_url", value);
        }
    }

    /// <summary>
    /// First (given) name of the person.
    /// </summary>
    public string? FirstName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "first_name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "first_name", value);
        }
    }

    /// <summary>
    /// Full name of the person, typically concatenation of first and last names.
    /// </summary>
    public string? FullName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "full_name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "full_name", value);
        }
    }

    /// <summary>
    /// Gender of the individual (e.g., "M" for male, "F" for female).
    /// </summary>
    public string? Gender
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "gender"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "gender", value);
        }
    }

    /// <summary>
    /// Last (family) name of the person.
    /// </summary>
    public string? LastName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "last_name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "last_name", value);
        }
    }

    /// <summary>
    /// Maiden name of the person, if applicable.
    /// </summary>
    public string? MaidenName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "maiden_name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "maiden_name", value);
        }
    }

    /// <summary>
    /// Nationality of the individual (ISO 3166-1 alpha-3 country code).
    /// </summary>
    public string? Nationality
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "nationality"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "nationality", value);
        }
    }

    /// <summary>
    /// Contact phone number including country code.
    /// </summary>
    public string? PhoneNumber
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "phone_number"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "phone_number", value);
        }
    }

    /// <inheritdoc/>
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

    public IndividualPerson(IndividualPerson individualPerson)
        : base(individualPerson) { }

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
        get { return JsonModel.GetNullableClass<string>(this.RawData, "key"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "key", value);
        }
    }

    /// <summary>
    /// Indicates whether the tag is private (not visible to external users).
    /// </summary>
    public bool? Private
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "private"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "private", value);
        }
    }

    /// <summary>
    /// Data type of the tag value (e.g., "string", "number", "boolean").
    /// </summary>
    public string? Type
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "type"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "type", value);
        }
    }

    /// <summary>
    /// Value assigned to the tag.
    /// </summary>
    public string? Value
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "value"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "value", value);
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tag(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
