using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;
using System = System;

namespace Dataleonlabs.Models.Companies;

/// <summary>
/// Get all companies
/// </summary>
public sealed record class CompanyListParams : ParamsBase
{
    /// <summary>
    /// Filter companies created before this date (format YYYY-MM-DD)
    /// </summary>
    public System::DateOnly? EndDate
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateOnly?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.QueryProperties["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of results to return (between 1 and 100)
    /// </summary>
    public long? Limit
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["limit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of results to skip (must be ≥ 0)
    /// </summary>
    public long? Offset
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("offset", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["offset"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter by source ID
    /// </summary>
    public string? SourceID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("source_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["source_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter companies created after this date (format YYYY-MM-DD)
    /// </summary>
    public System::DateOnly? StartDate
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("start_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateOnly?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.QueryProperties["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter by company state (must be one of the allowed values)
    /// </summary>
    public ApiEnum<string, State>? State
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("state", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, State>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.QueryProperties["state"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter by individual status (must be one of the allowed values)
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Status>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.QueryProperties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter by workspace ID
    /// </summary>
    public string? WorkspaceID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("workspace_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["workspace_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override System::Uri Url(IDataleonlabsClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/companies")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request,
        IDataleonlabsClient client
    )
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

/// <summary>
/// Filter by company state (must be one of the allowed values)
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
        System::Type typeToConvert,
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
                _ => throw new DataleonlabsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Filter by individual status (must be one of the allowed values)
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Rejected,
    NeedReview,
    Approved,
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
            "rejected" => Status.Rejected,
            "need_review" => Status.NeedReview,
            "approved" => Status.Approved,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Rejected => "rejected",
                Status.NeedReview => "need_review",
                Status.Approved => "approved",
                _ => throw new DataleonlabsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
