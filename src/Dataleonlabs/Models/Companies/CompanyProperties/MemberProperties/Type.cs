using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Dataleonlabs.Models.Companies.CompanyProperties.MemberProperties;

/// <summary>
/// Member type (person or company)
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Person,
    Company,
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
            "person" => MemberProperties.Type.Person,
            "company" => MemberProperties.Type.Company,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MemberProperties.Type.Person => "person",
                MemberProperties.Type.Company => "company",
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
