using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;
using System = System;

namespace Dataleonlabs.Models.Companies;

/// <summary>
/// Contains technical metadata related to processing and communication of an entity.
/// </summary>
[JsonConverter(typeof(ModelConverter<CompanyTechnicalData, CompanyTechnicalDataFromRaw>))]
public sealed record class CompanyTechnicalData : ModelBase
{
    /// <summary>
    /// Flag indicating whether there are active research AML (Anti-Money Laundering)
    /// suspicions for the object when you apply for a new entry or get an existing one.
    /// </summary>
    public bool? ActiveAmlSuspicions
    {
        get
        {
            if (!this._rawData.TryGetValue("active_aml_suspicions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["active_aml_suspicions"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("api_version", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["api_version"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the request or process was approved.
    /// </summary>
    public System::DateTimeOffset? ApprovedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("approved_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["approved_at"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("callback_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["callback_url"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("callback_url_notification", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["callback_url_notification"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("disable_notification", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["disable_notification"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when notifications were disabled; null if never disabled.
    /// </summary>
    public System::DateTimeOffset? DisableNotificationDate
    {
        get
        {
            if (!this._rawData.TryGetValue("disable_notification_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["disable_notification_date"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("export_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["export_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Minimum filtering score (between 0 and 1) for AML suspicions to be considered.
    /// </summary>
    public float? FilteringScoreAmlSuspicions
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "filtering_score_aml_suspicions",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<float?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["filtering_score_aml_suspicions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the process finished.
    /// </summary>
    public System::DateTimeOffset? FinishedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("finished_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["finished_at"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("ip", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["ip"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("language", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["language"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("location_ip", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["location_ip"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp indicating when the request or process needs review; null if none.
    /// </summary>
    public System::DateTimeOffset? NeedReviewAt
    {
        get
        {
            if (!this._rawData.TryGetValue("need_review_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["need_review_at"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("notification_confirmation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["notification_confirmation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// List of steps to include in the portal workflow.
    /// </summary>
    public List<ApiEnum<string, PortalStep1>>? PortalSteps
    {
        get
        {
            if (!this._rawData.TryGetValue("portal_steps", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ApiEnum<string, PortalStep1>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["portal_steps"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("qr_code", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["qr_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Flag indicating whether to include raw data in the response.
    /// </summary>
    public bool? RawData1
    {
        get
        {
            if (!this._rawData.TryGetValue("raw_data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["raw_data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the request or process was rejected; null if not rejected.
    /// </summary>
    public System::DateTimeOffset? RejectedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("rejected_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["rejected_at"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("session_duration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["session_duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Timestamp when the process started.
    /// </summary>
    public System::DateTimeOffset? StartedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("started_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["started_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Date/time of data transfer.
    /// </summary>
    public System::DateTimeOffset? TransferAt
    {
        get
        {
            if (!this._rawData.TryGetValue("transfer_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["transfer_at"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("transfer_mode", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["transfer_mode"] = JsonSerializer.SerializeToElement(
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
        _ = this.FilteringScoreAmlSuspicions;
        _ = this.FinishedAt;
        _ = this.IP;
        _ = this.Language;
        _ = this.LocationIP;
        _ = this.NeedReviewAt;
        _ = this.NotificationConfirmation;
        foreach (var item in this.PortalSteps ?? [])
        {
            item.Validate();
        }
        _ = this.QrCode;
        _ = this.RawData1;
        _ = this.RejectedAt;
        _ = this.SessionDuration;
        _ = this.StartedAt;
        _ = this.TransferAt;
        _ = this.TransferMode;
    }

    public CompanyTechnicalData() { }

    public CompanyTechnicalData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompanyTechnicalData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static CompanyTechnicalData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CompanyTechnicalDataFromRaw : IFromRaw<CompanyTechnicalData>
{
    public CompanyTechnicalData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CompanyTechnicalData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PortalStep1Converter))]
public enum PortalStep1
{
    IdentityVerification,
    DocumentSigning,
    ProofOfAddress,
    Selfie,
    FaceMatch,
}

sealed class PortalStep1Converter : JsonConverter<PortalStep1>
{
    public override PortalStep1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "identity_verification" => PortalStep1.IdentityVerification,
            "document_signing" => PortalStep1.DocumentSigning,
            "proof_of_address" => PortalStep1.ProofOfAddress,
            "selfie" => PortalStep1.Selfie,
            "face_match" => PortalStep1.FaceMatch,
            _ => (PortalStep1)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortalStep1 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PortalStep1.IdentityVerification => "identity_verification",
                PortalStep1.DocumentSigning => "document_signing",
                PortalStep1.ProofOfAddress => "proof_of_address",
                PortalStep1.Selfie => "selfie",
                PortalStep1.FaceMatch => "face_match",
                _ => throw new DataleonlabsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
