using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dataleonlabs.Models.Individuals.IndividualCreateParamsProperties.PersonProperties;

/// <summary>
/// Gender of the individual (M for male, F for female).
/// </summary>
[JsonConverter(typeof(GenderConverter))]
public enum Gender
{
    M,
    F,
}

sealed class GenderConverter : JsonConverter<Gender>
{
    public override Gender Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "M" => Gender.M,
            "F" => Gender.F,
            _ => (Gender)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Gender value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Gender.M => "M",
                Gender.F => "F",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
