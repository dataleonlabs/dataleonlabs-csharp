using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Dataleonlabs.Models.Companies.CompanyProperties.MemberProperties;

/// <summary>
/// Source of the data (e.g., government, user, company)
/// </summary>
[JsonConverter(typeof(SourceConverter))]
public enum Source
{
    Gouve,
    User,
    Company,
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "gouve" => Source.Gouve,
            "user" => Source.User,
            "company" => Source.Company,
            _ => (Source)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Source.Gouve => "gouve",
                Source.User => "user",
                Source.Company => "company",
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
