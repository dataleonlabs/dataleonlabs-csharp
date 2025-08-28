using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dataleonlabs.Models.Companies.Documents.GenericDocumentProperties;

[JsonConverter(typeof(ModelConverter<Table>))]
public sealed record class Table : ModelBase, IFromRaw<Table>
{
    /// <summary>
    /// List of operations or actions associated with the table.
    /// </summary>
    public List<JsonElement>? Operation
    {
        get
        {
            if (!this.Properties.TryGetValue("operation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["operation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Operation ?? [])
        {
            _ = item;
        }
    }

    public Table() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Table(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Table FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
