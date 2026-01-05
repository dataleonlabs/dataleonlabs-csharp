using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;

namespace Dataleonlabs.Models.Individuals;

/// <summary>
/// Get all individuals
/// </summary>
public sealed record class IndividualListParams : ParamsBase
{
    /// <summary>
    /// Filter individuals created before this date (format YYYY-MM-DD)
    /// </summary>
    public string? EndDate
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "end_date"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "end_date", value);
        }
    }

    /// <summary>
    /// Number of results to return (between 1 and 100)
    /// </summary>
    public long? Limit
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawQueryData, "limit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "limit", value);
        }
    }

    /// <summary>
    /// Number of results to offset (must be ≥ 0)
    /// </summary>
    public long? Offset
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawQueryData, "offset"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "offset", value);
        }
    }

    /// <summary>
    /// Filter by source ID
    /// </summary>
    public string? SourceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "source_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "source_id", value);
        }
    }

    /// <summary>
    /// Filter individuals created after this date (format YYYY-MM-DD)
    /// </summary>
    public string? StartDate
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "start_date"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "start_date", value);
        }
    }

    /// <summary>
    /// Filter by individual status (must be one of the allowed values)
    /// </summary>
    public ApiEnum<string, State>? State
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, State>>(this.RawQueryData, "state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "state", value);
        }
    }

    /// <summary>
    /// Filter by individual status (must be one of the allowed values)
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, Status>>(this.RawQueryData, "status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "status", value);
        }
    }

    /// <summary>
    /// Filter by workspace ID
    /// </summary>
    public string? WorkspaceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "workspace_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "workspace_id", value);
        }
    }

    public IndividualListParams() { }

    public IndividualListParams(IndividualListParams individualListParams)
        : base(individualListParams) { }

    public IndividualListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IndividualListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static IndividualListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/individuals")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

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
        Type typeToConvert,
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
