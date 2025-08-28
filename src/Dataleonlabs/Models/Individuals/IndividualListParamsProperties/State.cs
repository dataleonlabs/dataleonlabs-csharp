using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dataleonlabs.Models.Individuals.IndividualListParamsProperties;

/// <summary>
/// Filter by individual status (must be one of the allowed values)
/// </summary>
[JsonConverter(typeof(StateConverter))]
public enum State
{
    Void,
    Waiting,
    Started,
    Running,
    Processed,
    Failed,
    Aborted,
    Expired,
    Deleted,
}

sealed class StateConverter : JsonConverter<State>
{
    public override State Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "VOID" => State.Void,
            "WAITING" => State.Waiting,
            "STARTED" => State.Started,
            "RUNNING" => State.Running,
            "PROCESSED" => State.Processed,
            "FAILED" => State.Failed,
            "ABORTED" => State.Aborted,
            "EXPIRED" => State.Expired,
            "DELETED" => State.Deleted,
            _ => (State)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, State value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                State.Void => "VOID",
                State.Waiting => "WAITING",
                State.Started => "STARTED",
                State.Running => "RUNNING",
                State.Processed => "PROCESSED",
                State.Failed => "FAILED",
                State.Aborted => "ABORTED",
                State.Expired => "EXPIRED",
                State.Deleted => "DELETED",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
