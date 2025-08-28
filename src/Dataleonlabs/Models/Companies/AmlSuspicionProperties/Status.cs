using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Dataleonlabs.Models.Companies.AmlSuspicionProperties;

/// <summary>
/// Status of the suspicion review process. Possible values: "true_positive", "false_positive",
/// "pending".
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    TruePositive,
    FalsePositive,
    Pending,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "true_positive" => Status.TruePositive,
            "false_positive" => Status.FalsePositive,
            "pending" => Status.Pending,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.TruePositive => "true_positive",
                Status.FalsePositive => "false_positive",
                Status.Pending => "pending",
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
