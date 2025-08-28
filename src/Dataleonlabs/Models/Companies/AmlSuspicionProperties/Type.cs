using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Dataleonlabs.Models.Companies.AmlSuspicionProperties;

/// <summary>
/// Category of the suspicion. Possible values: "crime", "sanction", "pep", "adverse_news",
/// "other".
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Crime,
    Sanction,
    Pep,
    AdverseNews,
    Other,
}

sealed class TypeConverter : JsonConverter<Type>
{
    public override Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "crime" => AmlSuspicionProperties.Type.Crime,
            "sanction" => AmlSuspicionProperties.Type.Sanction,
            "pep" => AmlSuspicionProperties.Type.Pep,
            "adverse_news" => AmlSuspicionProperties.Type.AdverseNews,
            "other" => AmlSuspicionProperties.Type.Other,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AmlSuspicionProperties.Type.Crime => "crime",
                AmlSuspicionProperties.Type.Sanction => "sanction",
                AmlSuspicionProperties.Type.Pep => "pep",
                AmlSuspicionProperties.Type.AdverseNews => "adverse_news",
                AmlSuspicionProperties.Type.Other => "other",
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
