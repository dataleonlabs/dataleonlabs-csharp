using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Models.Companies.Documents;
using CompanyProperties = Dataleonlabs.Models.Companies.CompanyProperties;

namespace Dataleonlabs.Models.Companies;

[JsonConverter(typeof(ModelConverter<Company>))]
public sealed record class Company : ModelBase, IFromRaw<Company>
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
    public CompanyProperties::Company? Company1
    {
        get
        {
            if (!this.Properties.TryGetValue("company", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CompanyProperties::Company?>(
                element,
                ModelBase.SerializerOptions
            );
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
    public List<CompanyProperties::Member>? Members
    {
        get
        {
            if (!this.Properties.TryGetValue("members", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<CompanyProperties::Member>?>(
                element,
                ModelBase.SerializerOptions
            );
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
        this.Company1?.Validate();
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
