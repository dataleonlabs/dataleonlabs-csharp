using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Models.Companies.Documents.DocumentResponseProperties;

namespace Dataleonlabs.Models.Companies.Documents;

[JsonConverter(typeof(ModelConverter<DocumentResponse>))]
public sealed record class DocumentResponse : ModelBase, IFromRaw<DocumentResponse>
{
    /// <summary>
    /// List of documents associated with the response.
    /// </summary>
    public List<Document>? Documents
    {
        get
        {
            if (!this.Properties.TryGetValue("documents", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Document>?>(
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
    /// Total number of documents available in the response.
    /// </summary>
    public long? TotalDocument
    {
        get
        {
            if (!this.Properties.TryGetValue("total_document", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["total_document"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Documents ?? [])
        {
            item.Validate();
        }
        _ = this.TotalDocument;
    }

    public DocumentResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static DocumentResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
