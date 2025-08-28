using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Models.Companies;
using Dataleonlabs.Models.Companies.Documents;
using Dataleonlabs.Models.Individuals.IndividualProperties;

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
    /// List of verification or validation checks applied to the individual.
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
    public Person? Person
    {
        get
        {
            if (!this.Properties.TryGetValue("person", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Person?>(element, ModelBase.SerializerOptions);
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
    /// Risk assessment associated with the individual.
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
    public TechnicalData? TechnicalData
    {
        get
        {
            if (!this.Properties.TryGetValue("technical_data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<TechnicalData?>(element, ModelBase.SerializerOptions);
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
