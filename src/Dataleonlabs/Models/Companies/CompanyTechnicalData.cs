using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
[JsonConverter(typeof(JsonModelConverter<CompanyTechnicalData, CompanyTechnicalDataFromRaw>))]
public sealed record class CompanyTechnicalData : JsonModel
{
    /// <summary>
    /// Flag indicating whether there are active research AML (Anti-Money Laundering)
    /// suspicions for the object when you apply for a new entry or get an existing one.
    /// </summary>
    public bool? ActiveAmlSuspicions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("active_aml_suspicions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("active_aml_suspicions", value);
        }
    }

    /// <summary>
    /// Version number of the API used.
    /// </summary>
    public long? ApiVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("api_version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("api_version", value);
        }
    }

    /// <summary>
    /// Timestamp when the request or process was approved.
    /// </summary>
    public System::DateTimeOffset? ApprovedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("approved_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("approved_at", value);
        }
    }

    /// <summary>
    /// URL to receive callback data from the AML system.
    /// </summary>
    public string? CallbackUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("callback_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("callback_url", value);
        }
    }

    /// <summary>
    /// URL to receive notification updates about the processing status.
    /// </summary>
    public string? CallbackUrlNotification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("callback_url_notification");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("callback_url_notification", value);
        }
    }

    /// <summary>
    /// Flag to indicate if notifications are disabled.
    /// </summary>
    public bool? DisableNotification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("disable_notification");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("disable_notification", value);
        }
    }

    /// <summary>
    /// Timestamp when notifications were disabled; null if never disabled.
    /// </summary>
    public System::DateTimeOffset? DisableNotificationDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "disable_notification_date"
            );
        }
        init { this._rawData.Set("disable_notification_date", value); }
    }

    /// <summary>
    /// Export format defined by the API (e.g., "json", "xml").
    /// </summary>
    public string? ExportType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("export_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("export_type", value);
        }
    }

    /// <summary>
    /// Minimum filtering score (between 0 and 1) for AML suspicions to be considered.
    /// </summary>
    public float? FilteringScoreAmlSuspicions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("filtering_score_aml_suspicions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("filtering_score_aml_suspicions", value);
        }
    }

    /// <summary>
    /// Timestamp when the process finished.
    /// </summary>
    public System::DateTimeOffset? FinishedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("finished_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("finished_at", value);
        }
    }

    /// <summary>
    /// IP address of the our system handling the request.
    /// </summary>
    public string? IP
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ip");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ip", value);
        }
    }

    /// <summary>
    /// Language preference used in the client workspace (e.g., "fra").
    /// </summary>
    public string? Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("language");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("language", value);
        }
    }

    /// <summary>
    /// IP address of the end client (final user) captured.
    /// </summary>
    public string? LocationIP
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("location_ip");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("location_ip", value);
        }
    }

    /// <summary>
    /// Timestamp indicating when the request or process needs review; null if none.
    /// </summary>
    public System::DateTimeOffset? NeedReviewAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("need_review_at");
        }
        init { this._rawData.Set("need_review_at", value); }
    }

    /// <summary>
    /// Flag indicating if notification confirmation is required or received.
    /// </summary>
    public bool? NotificationConfirmation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("notification_confirmation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("notification_confirmation", value);
        }
    }

    /// <summary>
    /// List of steps to include in the portal workflow.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, CompanyTechnicalDataPortalStep>>? PortalSteps
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, CompanyTechnicalDataPortalStep>>
            >("portal_steps");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, CompanyTechnicalDataPortalStep>>?>(
                "portal_steps",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("qr_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("qr_code", value);
        }
    }

    /// <summary>
    /// Flag indicating whether to include raw data in the response.
    /// </summary>
    public bool? RawDataValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("raw_data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("raw_data", value);
        }
    }

    /// <summary>
    /// Timestamp when the request or process was rejected; null if not rejected.
    /// </summary>
    public System::DateTimeOffset? RejectedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("rejected_at");
        }
        init { this._rawData.Set("rejected_at", value); }
    }

    /// <summary>
    /// Duration of the user session in seconds.
    /// </summary>
    public long? SessionDuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("session_duration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("session_duration", value);
        }
    }

    /// <summary>
    /// Timestamp when the process started.
    /// </summary>
    public System::DateTimeOffset? StartedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("started_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("started_at", value);
        }
    }

    /// <summary>
    /// Date/time of data transfer.
    /// </summary>
    public System::DateTimeOffset? TransferAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("transfer_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transfer_at", value);
        }
    }

    /// <summary>
    /// Mode of data transfer.
    /// </summary>
    public string? TransferMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transfer_mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transfer_mode", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActiveAmlSuspicions;
        _ = this.ApiVersion;
        _ = this.ApprovedAt;
        _ = this.CallbackUrl;
        _ = this.CallbackUrlNotification;
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
        _ = this.RawDataValue;
        _ = this.RejectedAt;
        _ = this.SessionDuration;
        _ = this.StartedAt;
        _ = this.TransferAt;
        _ = this.TransferMode;
    }

    public CompanyTechnicalData() { }

    public CompanyTechnicalData(CompanyTechnicalData companyTechnicalData)
        : base(companyTechnicalData) { }

    public CompanyTechnicalData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CompanyTechnicalData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CompanyTechnicalDataFromRaw.FromRawUnchecked"/>
    public static CompanyTechnicalData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CompanyTechnicalDataFromRaw : IFromRawJson<CompanyTechnicalData>
{
    /// <inheritdoc/>
    public CompanyTechnicalData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CompanyTechnicalData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CompanyTechnicalDataPortalStepConverter))]
public enum CompanyTechnicalDataPortalStep
{
    IdentityVerification,
    DocumentSigning,
    ProofOfAddress,
    Selfie,
    FaceMatch,
}

sealed class CompanyTechnicalDataPortalStepConverter : JsonConverter<CompanyTechnicalDataPortalStep>
{
    public override CompanyTechnicalDataPortalStep Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "identity_verification" => CompanyTechnicalDataPortalStep.IdentityVerification,
            "document_signing" => CompanyTechnicalDataPortalStep.DocumentSigning,
            "proof_of_address" => CompanyTechnicalDataPortalStep.ProofOfAddress,
            "selfie" => CompanyTechnicalDataPortalStep.Selfie,
            "face_match" => CompanyTechnicalDataPortalStep.FaceMatch,
            _ => (CompanyTechnicalDataPortalStep)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CompanyTechnicalDataPortalStep value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CompanyTechnicalDataPortalStep.IdentityVerification => "identity_verification",
                CompanyTechnicalDataPortalStep.DocumentSigning => "document_signing",
                CompanyTechnicalDataPortalStep.ProofOfAddress => "proof_of_address",
                CompanyTechnicalDataPortalStep.Selfie => "selfie",
                CompanyTechnicalDataPortalStep.FaceMatch => "face_match",
                _ => throw new DataleonlabsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
