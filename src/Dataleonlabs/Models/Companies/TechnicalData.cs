using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dataleonlabs.Models.Companies;

/// <summary>
/// Contains technical metadata related to processing and communication of an entity.
/// </summary>
[JsonConverter(typeof(ModelConverter<TechnicalData>))]
public sealed record class TechnicalData : ModelBase, IFromRaw<TechnicalData>
{
    /// <summary>
    /// Flag indicating whether there are active research AML (Anti-Money Laundering)
    /// suspicions for the object when you apply for a new entry or get an existing one.
    /// </summary>
    public bool? ActiveAmlSuspicions
    {
        get
        {
            if (!this.Properties.TryGetValue("active_aml_suspicions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["active_aml_suspicions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Version number of the API used.
    /// </summary>
    public long? APIVersion
    {
        get
        {
            if (!this.Properties.TryGetValue("api_version", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["api_version"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the request or process was approved.
    /// </summary>
    public DateTime? ApprovedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("approved_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["approved_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// URL to receive callback data from the AML system.
    /// </summary>
    public string? CallbackURL
    {
        get
        {
            if (!this.Properties.TryGetValue("callback_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["callback_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// URL to receive notification updates about the processing status.
    /// </summary>
    public string? CallbackURLNotification
    {
        get
        {
            if (!this.Properties.TryGetValue("callback_url_notification", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["callback_url_notification"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Flag to indicate if notifications are disabled.
    /// </summary>
    public bool? DisableNotification
    {
        get
        {
            if (!this.Properties.TryGetValue("disable_notification", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["disable_notification"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when notifications were disabled; null if never disabled.
    /// </summary>
    public DateTime? DisableNotificationDate
    {
        get
        {
            if (!this.Properties.TryGetValue("disable_notification_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["disable_notification_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Export format defined by the API (e.g., "json", "xml").
    /// </summary>
    public string? ExportType
    {
        get
        {
            if (!this.Properties.TryGetValue("export_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["export_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the process finished.
    /// </summary>
    public DateTime? FinishedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("finished_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["finished_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// IP address of the our system handling the request.
    /// </summary>
    public string? IP
    {
        get
        {
            if (!this.Properties.TryGetValue("ip", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ip"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Language preference used in the client workspace (e.g., "fra").
    /// </summary>
    public string? Language
    {
        get
        {
            if (!this.Properties.TryGetValue("language", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["language"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// IP address of the end client (final user) captured.
    /// </summary>
    public string? LocationIP
    {
        get
        {
            if (!this.Properties.TryGetValue("location_ip", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["location_ip"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp indicating when the request or process needs review; null if none.
    /// </summary>
    public DateTime? NeedReviewAt
    {
        get
        {
            if (!this.Properties.TryGetValue("need_review_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["need_review_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Flag indicating if notification confirmation is required or received.
    /// </summary>
    public bool? NotificationConfirmation
    {
        get
        {
            if (!this.Properties.TryGetValue("notification_confirmation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["notification_confirmation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Indicates whether QR code is enabled ("true" or "false").
    /// </summary>
    public string? QrCode
    {
        get
        {
            if (!this.Properties.TryGetValue("qr_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["qr_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Flag indicating whether to include raw data in the response.
    /// </summary>
    public bool? RawData
    {
        get
        {
            if (!this.Properties.TryGetValue("raw_data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["raw_data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the request or process was rejected; null if not rejected.
    /// </summary>
    public DateTime? RejectedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("rejected_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["rejected_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Duration of the user session in seconds.
    /// </summary>
    public long? SessionDuration
    {
        get
        {
            if (!this.Properties.TryGetValue("session_duration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["session_duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the process started.
    /// </summary>
    public DateTime? StartedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("started_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["started_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Date/time of data transfer.
    /// </summary>
    public DateTime? TransferAt
    {
        get
        {
            if (!this.Properties.TryGetValue("transfer_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["transfer_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Mode of data transfer.
    /// </summary>
    public string? TransferMode
    {
        get
        {
            if (!this.Properties.TryGetValue("transfer_mode", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["transfer_mode"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ActiveAmlSuspicions;
        _ = this.APIVersion;
        _ = this.ApprovedAt;
        _ = this.CallbackURL;
        _ = this.CallbackURLNotification;
        _ = this.DisableNotification;
        _ = this.DisableNotificationDate;
        _ = this.ExportType;
        _ = this.FinishedAt;
        _ = this.IP;
        _ = this.Language;
        _ = this.LocationIP;
        _ = this.NeedReviewAt;
        _ = this.NotificationConfirmation;
        _ = this.QrCode;
        _ = this.RawData;
        _ = this.RejectedAt;
        _ = this.SessionDuration;
        _ = this.StartedAt;
        _ = this.TransferAt;
        _ = this.TransferMode;
    }

    public TechnicalData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TechnicalData(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TechnicalData FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
