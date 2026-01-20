using System;
using System.Collections.Generic;
using System.Text.Json;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;
using Dataleonlabs.Models.Companies;

namespace Dataleonlabs.Tests.Models.Companies;

public class CompanyTechnicalDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompanyTechnicalData
        {
            ActiveAmlSuspicions = false,
            ApiVersion = 2,
            ApprovedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
            ApprovedBy = "user:john.doe",
            CallbackUrl = "https://example.com/callback",
            CallbackUrlNotification = "https://example.com/notify",
            DisableNotification = false,
            DisableNotificationDate = DateTimeOffset.Parse("2025-07-12T13:10:00Z"),
            ExportType = "json",
            FilteringScoreAmlSuspicions = 0.75f,
            FinishedAt = DateTimeOffset.Parse("2025-05-05T13:10:00Z"),
            IP = "192.168.1.1",
            Language = "fra",
            LocationIP = "203.0.113.45",
            NeedReviewAt = null,
            NeedReviewBy = "user:reviewer01",
            NotificationConfirmation = false,
            PortalSteps =
            [
                CompanyTechnicalDataPortalStep.IdentityVerification,
                CompanyTechnicalDataPortalStep.Selfie,
                CompanyTechnicalDataPortalStep.FaceMatch,
            ],
            QrCode = "false",
            RawDataValue = true,
            RejectedAt = null,
            RejectedBy = "user:jane.doe",
            SessionDuration = 45,
            StartedAt = DateTimeOffset.Parse("2025-05-05T13:00:00Z"),
            TransferAt = DateTimeOffset.Parse("2025-07-12T14:00:00Z"),
            TransferMode = "API",
        };

        bool expectedActiveAmlSuspicions = false;
        long expectedApiVersion = 2;
        DateTimeOffset expectedApprovedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z");
        string expectedApprovedBy = "user:john.doe";
        string expectedCallbackUrl = "https://example.com/callback";
        string expectedCallbackUrlNotification = "https://example.com/notify";
        bool expectedDisableNotification = false;
        DateTimeOffset expectedDisableNotificationDate = DateTimeOffset.Parse(
            "2025-07-12T13:10:00Z"
        );
        string expectedExportType = "json";
        float expectedFilteringScoreAmlSuspicions = 0.75f;
        DateTimeOffset expectedFinishedAt = DateTimeOffset.Parse("2025-05-05T13:10:00Z");
        string expectedIP = "192.168.1.1";
        string expectedLanguage = "fra";
        string expectedLocationIP = "203.0.113.45";
        string expectedNeedReviewBy = "user:reviewer01";
        bool expectedNotificationConfirmation = false;
        List<ApiEnum<string, CompanyTechnicalDataPortalStep>> expectedPortalSteps =
        [
            CompanyTechnicalDataPortalStep.IdentityVerification,
            CompanyTechnicalDataPortalStep.Selfie,
            CompanyTechnicalDataPortalStep.FaceMatch,
        ];
        string expectedQrCode = "false";
        bool expectedRawDataValue = true;
        string expectedRejectedBy = "user:jane.doe";
        long expectedSessionDuration = 45;
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2025-05-05T13:00:00Z");
        DateTimeOffset expectedTransferAt = DateTimeOffset.Parse("2025-07-12T14:00:00Z");
        string expectedTransferMode = "API";

        Assert.Equal(expectedActiveAmlSuspicions, model.ActiveAmlSuspicions);
        Assert.Equal(expectedApiVersion, model.ApiVersion);
        Assert.Equal(expectedApprovedAt, model.ApprovedAt);
        Assert.Equal(expectedApprovedBy, model.ApprovedBy);
        Assert.Equal(expectedCallbackUrl, model.CallbackUrl);
        Assert.Equal(expectedCallbackUrlNotification, model.CallbackUrlNotification);
        Assert.Equal(expectedDisableNotification, model.DisableNotification);
        Assert.Equal(expectedDisableNotificationDate, model.DisableNotificationDate);
        Assert.Equal(expectedExportType, model.ExportType);
        Assert.Equal(expectedFilteringScoreAmlSuspicions, model.FilteringScoreAmlSuspicions);
        Assert.Equal(expectedFinishedAt, model.FinishedAt);
        Assert.Equal(expectedIP, model.IP);
        Assert.Equal(expectedLanguage, model.Language);
        Assert.Equal(expectedLocationIP, model.LocationIP);
        Assert.Null(model.NeedReviewAt);
        Assert.Equal(expectedNeedReviewBy, model.NeedReviewBy);
        Assert.Equal(expectedNotificationConfirmation, model.NotificationConfirmation);
        Assert.NotNull(model.PortalSteps);
        Assert.Equal(expectedPortalSteps.Count, model.PortalSteps.Count);
        for (int i = 0; i < expectedPortalSteps.Count; i++)
        {
            Assert.Equal(expectedPortalSteps[i], model.PortalSteps[i]);
        }
        Assert.Equal(expectedQrCode, model.QrCode);
        Assert.Equal(expectedRawDataValue, model.RawDataValue);
        Assert.Null(model.RejectedAt);
        Assert.Equal(expectedRejectedBy, model.RejectedBy);
        Assert.Equal(expectedSessionDuration, model.SessionDuration);
        Assert.Equal(expectedStartedAt, model.StartedAt);
        Assert.Equal(expectedTransferAt, model.TransferAt);
        Assert.Equal(expectedTransferMode, model.TransferMode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CompanyTechnicalData
        {
            ActiveAmlSuspicions = false,
            ApiVersion = 2,
            ApprovedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
            ApprovedBy = "user:john.doe",
            CallbackUrl = "https://example.com/callback",
            CallbackUrlNotification = "https://example.com/notify",
            DisableNotification = false,
            DisableNotificationDate = DateTimeOffset.Parse("2025-07-12T13:10:00Z"),
            ExportType = "json",
            FilteringScoreAmlSuspicions = 0.75f,
            FinishedAt = DateTimeOffset.Parse("2025-05-05T13:10:00Z"),
            IP = "192.168.1.1",
            Language = "fra",
            LocationIP = "203.0.113.45",
            NeedReviewAt = null,
            NeedReviewBy = "user:reviewer01",
            NotificationConfirmation = false,
            PortalSteps =
            [
                CompanyTechnicalDataPortalStep.IdentityVerification,
                CompanyTechnicalDataPortalStep.Selfie,
                CompanyTechnicalDataPortalStep.FaceMatch,
            ],
            QrCode = "false",
            RawDataValue = true,
            RejectedAt = null,
            RejectedBy = "user:jane.doe",
            SessionDuration = 45,
            StartedAt = DateTimeOffset.Parse("2025-05-05T13:00:00Z"),
            TransferAt = DateTimeOffset.Parse("2025-07-12T14:00:00Z"),
            TransferMode = "API",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CompanyTechnicalData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CompanyTechnicalData
        {
            ActiveAmlSuspicions = false,
            ApiVersion = 2,
            ApprovedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
            ApprovedBy = "user:john.doe",
            CallbackUrl = "https://example.com/callback",
            CallbackUrlNotification = "https://example.com/notify",
            DisableNotification = false,
            DisableNotificationDate = DateTimeOffset.Parse("2025-07-12T13:10:00Z"),
            ExportType = "json",
            FilteringScoreAmlSuspicions = 0.75f,
            FinishedAt = DateTimeOffset.Parse("2025-05-05T13:10:00Z"),
            IP = "192.168.1.1",
            Language = "fra",
            LocationIP = "203.0.113.45",
            NeedReviewAt = null,
            NeedReviewBy = "user:reviewer01",
            NotificationConfirmation = false,
            PortalSteps =
            [
                CompanyTechnicalDataPortalStep.IdentityVerification,
                CompanyTechnicalDataPortalStep.Selfie,
                CompanyTechnicalDataPortalStep.FaceMatch,
            ],
            QrCode = "false",
            RawDataValue = true,
            RejectedAt = null,
            RejectedBy = "user:jane.doe",
            SessionDuration = 45,
            StartedAt = DateTimeOffset.Parse("2025-05-05T13:00:00Z"),
            TransferAt = DateTimeOffset.Parse("2025-07-12T14:00:00Z"),
            TransferMode = "API",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CompanyTechnicalData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedActiveAmlSuspicions = false;
        long expectedApiVersion = 2;
        DateTimeOffset expectedApprovedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z");
        string expectedApprovedBy = "user:john.doe";
        string expectedCallbackUrl = "https://example.com/callback";
        string expectedCallbackUrlNotification = "https://example.com/notify";
        bool expectedDisableNotification = false;
        DateTimeOffset expectedDisableNotificationDate = DateTimeOffset.Parse(
            "2025-07-12T13:10:00Z"
        );
        string expectedExportType = "json";
        float expectedFilteringScoreAmlSuspicions = 0.75f;
        DateTimeOffset expectedFinishedAt = DateTimeOffset.Parse("2025-05-05T13:10:00Z");
        string expectedIP = "192.168.1.1";
        string expectedLanguage = "fra";
        string expectedLocationIP = "203.0.113.45";
        string expectedNeedReviewBy = "user:reviewer01";
        bool expectedNotificationConfirmation = false;
        List<ApiEnum<string, CompanyTechnicalDataPortalStep>> expectedPortalSteps =
        [
            CompanyTechnicalDataPortalStep.IdentityVerification,
            CompanyTechnicalDataPortalStep.Selfie,
            CompanyTechnicalDataPortalStep.FaceMatch,
        ];
        string expectedQrCode = "false";
        bool expectedRawDataValue = true;
        string expectedRejectedBy = "user:jane.doe";
        long expectedSessionDuration = 45;
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2025-05-05T13:00:00Z");
        DateTimeOffset expectedTransferAt = DateTimeOffset.Parse("2025-07-12T14:00:00Z");
        string expectedTransferMode = "API";

        Assert.Equal(expectedActiveAmlSuspicions, deserialized.ActiveAmlSuspicions);
        Assert.Equal(expectedApiVersion, deserialized.ApiVersion);
        Assert.Equal(expectedApprovedAt, deserialized.ApprovedAt);
        Assert.Equal(expectedApprovedBy, deserialized.ApprovedBy);
        Assert.Equal(expectedCallbackUrl, deserialized.CallbackUrl);
        Assert.Equal(expectedCallbackUrlNotification, deserialized.CallbackUrlNotification);
        Assert.Equal(expectedDisableNotification, deserialized.DisableNotification);
        Assert.Equal(expectedDisableNotificationDate, deserialized.DisableNotificationDate);
        Assert.Equal(expectedExportType, deserialized.ExportType);
        Assert.Equal(expectedFilteringScoreAmlSuspicions, deserialized.FilteringScoreAmlSuspicions);
        Assert.Equal(expectedFinishedAt, deserialized.FinishedAt);
        Assert.Equal(expectedIP, deserialized.IP);
        Assert.Equal(expectedLanguage, deserialized.Language);
        Assert.Equal(expectedLocationIP, deserialized.LocationIP);
        Assert.Null(deserialized.NeedReviewAt);
        Assert.Equal(expectedNeedReviewBy, deserialized.NeedReviewBy);
        Assert.Equal(expectedNotificationConfirmation, deserialized.NotificationConfirmation);
        Assert.NotNull(deserialized.PortalSteps);
        Assert.Equal(expectedPortalSteps.Count, deserialized.PortalSteps.Count);
        for (int i = 0; i < expectedPortalSteps.Count; i++)
        {
            Assert.Equal(expectedPortalSteps[i], deserialized.PortalSteps[i]);
        }
        Assert.Equal(expectedQrCode, deserialized.QrCode);
        Assert.Equal(expectedRawDataValue, deserialized.RawDataValue);
        Assert.Null(deserialized.RejectedAt);
        Assert.Equal(expectedRejectedBy, deserialized.RejectedBy);
        Assert.Equal(expectedSessionDuration, deserialized.SessionDuration);
        Assert.Equal(expectedStartedAt, deserialized.StartedAt);
        Assert.Equal(expectedTransferAt, deserialized.TransferAt);
        Assert.Equal(expectedTransferMode, deserialized.TransferMode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CompanyTechnicalData
        {
            ActiveAmlSuspicions = false,
            ApiVersion = 2,
            ApprovedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
            ApprovedBy = "user:john.doe",
            CallbackUrl = "https://example.com/callback",
            CallbackUrlNotification = "https://example.com/notify",
            DisableNotification = false,
            DisableNotificationDate = DateTimeOffset.Parse("2025-07-12T13:10:00Z"),
            ExportType = "json",
            FilteringScoreAmlSuspicions = 0.75f,
            FinishedAt = DateTimeOffset.Parse("2025-05-05T13:10:00Z"),
            IP = "192.168.1.1",
            Language = "fra",
            LocationIP = "203.0.113.45",
            NeedReviewAt = null,
            NeedReviewBy = "user:reviewer01",
            NotificationConfirmation = false,
            PortalSteps =
            [
                CompanyTechnicalDataPortalStep.IdentityVerification,
                CompanyTechnicalDataPortalStep.Selfie,
                CompanyTechnicalDataPortalStep.FaceMatch,
            ],
            QrCode = "false",
            RawDataValue = true,
            RejectedAt = null,
            RejectedBy = "user:jane.doe",
            SessionDuration = 45,
            StartedAt = DateTimeOffset.Parse("2025-05-05T13:00:00Z"),
            TransferAt = DateTimeOffset.Parse("2025-07-12T14:00:00Z"),
            TransferMode = "API",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CompanyTechnicalData
        {
            ApprovedBy = "user:john.doe",
            DisableNotificationDate = DateTimeOffset.Parse("2025-07-12T13:10:00Z"),
            NeedReviewAt = null,
            NeedReviewBy = "user:reviewer01",
            RejectedAt = null,
            RejectedBy = "user:jane.doe",
        };

        Assert.Null(model.ActiveAmlSuspicions);
        Assert.False(model.RawData.ContainsKey("active_aml_suspicions"));
        Assert.Null(model.ApiVersion);
        Assert.False(model.RawData.ContainsKey("api_version"));
        Assert.Null(model.ApprovedAt);
        Assert.False(model.RawData.ContainsKey("approved_at"));
        Assert.Null(model.CallbackUrl);
        Assert.False(model.RawData.ContainsKey("callback_url"));
        Assert.Null(model.CallbackUrlNotification);
        Assert.False(model.RawData.ContainsKey("callback_url_notification"));
        Assert.Null(model.DisableNotification);
        Assert.False(model.RawData.ContainsKey("disable_notification"));
        Assert.Null(model.ExportType);
        Assert.False(model.RawData.ContainsKey("export_type"));
        Assert.Null(model.FilteringScoreAmlSuspicions);
        Assert.False(model.RawData.ContainsKey("filtering_score_aml_suspicions"));
        Assert.Null(model.FinishedAt);
        Assert.False(model.RawData.ContainsKey("finished_at"));
        Assert.Null(model.IP);
        Assert.False(model.RawData.ContainsKey("ip"));
        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
        Assert.Null(model.LocationIP);
        Assert.False(model.RawData.ContainsKey("location_ip"));
        Assert.Null(model.NotificationConfirmation);
        Assert.False(model.RawData.ContainsKey("notification_confirmation"));
        Assert.Null(model.PortalSteps);
        Assert.False(model.RawData.ContainsKey("portal_steps"));
        Assert.Null(model.QrCode);
        Assert.False(model.RawData.ContainsKey("qr_code"));
        Assert.Null(model.RawDataValue);
        Assert.False(model.RawData.ContainsKey("raw_data"));
        Assert.Null(model.SessionDuration);
        Assert.False(model.RawData.ContainsKey("session_duration"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("started_at"));
        Assert.Null(model.TransferAt);
        Assert.False(model.RawData.ContainsKey("transfer_at"));
        Assert.Null(model.TransferMode);
        Assert.False(model.RawData.ContainsKey("transfer_mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CompanyTechnicalData
        {
            ApprovedBy = "user:john.doe",
            DisableNotificationDate = DateTimeOffset.Parse("2025-07-12T13:10:00Z"),
            NeedReviewAt = null,
            NeedReviewBy = "user:reviewer01",
            RejectedAt = null,
            RejectedBy = "user:jane.doe",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CompanyTechnicalData
        {
            ApprovedBy = "user:john.doe",
            DisableNotificationDate = DateTimeOffset.Parse("2025-07-12T13:10:00Z"),
            NeedReviewAt = null,
            NeedReviewBy = "user:reviewer01",
            RejectedAt = null,
            RejectedBy = "user:jane.doe",

            // Null should be interpreted as omitted for these properties
            ActiveAmlSuspicions = null,
            ApiVersion = null,
            ApprovedAt = null,
            CallbackUrl = null,
            CallbackUrlNotification = null,
            DisableNotification = null,
            ExportType = null,
            FilteringScoreAmlSuspicions = null,
            FinishedAt = null,
            IP = null,
            Language = null,
            LocationIP = null,
            NotificationConfirmation = null,
            PortalSteps = null,
            QrCode = null,
            RawDataValue = null,
            SessionDuration = null,
            StartedAt = null,
            TransferAt = null,
            TransferMode = null,
        };

        Assert.Null(model.ActiveAmlSuspicions);
        Assert.False(model.RawData.ContainsKey("active_aml_suspicions"));
        Assert.Null(model.ApiVersion);
        Assert.False(model.RawData.ContainsKey("api_version"));
        Assert.Null(model.ApprovedAt);
        Assert.False(model.RawData.ContainsKey("approved_at"));
        Assert.Null(model.CallbackUrl);
        Assert.False(model.RawData.ContainsKey("callback_url"));
        Assert.Null(model.CallbackUrlNotification);
        Assert.False(model.RawData.ContainsKey("callback_url_notification"));
        Assert.Null(model.DisableNotification);
        Assert.False(model.RawData.ContainsKey("disable_notification"));
        Assert.Null(model.ExportType);
        Assert.False(model.RawData.ContainsKey("export_type"));
        Assert.Null(model.FilteringScoreAmlSuspicions);
        Assert.False(model.RawData.ContainsKey("filtering_score_aml_suspicions"));
        Assert.Null(model.FinishedAt);
        Assert.False(model.RawData.ContainsKey("finished_at"));
        Assert.Null(model.IP);
        Assert.False(model.RawData.ContainsKey("ip"));
        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
        Assert.Null(model.LocationIP);
        Assert.False(model.RawData.ContainsKey("location_ip"));
        Assert.Null(model.NotificationConfirmation);
        Assert.False(model.RawData.ContainsKey("notification_confirmation"));
        Assert.Null(model.PortalSteps);
        Assert.False(model.RawData.ContainsKey("portal_steps"));
        Assert.Null(model.QrCode);
        Assert.False(model.RawData.ContainsKey("qr_code"));
        Assert.Null(model.RawDataValue);
        Assert.False(model.RawData.ContainsKey("raw_data"));
        Assert.Null(model.SessionDuration);
        Assert.False(model.RawData.ContainsKey("session_duration"));
        Assert.Null(model.StartedAt);
        Assert.False(model.RawData.ContainsKey("started_at"));
        Assert.Null(model.TransferAt);
        Assert.False(model.RawData.ContainsKey("transfer_at"));
        Assert.Null(model.TransferMode);
        Assert.False(model.RawData.ContainsKey("transfer_mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CompanyTechnicalData
        {
            ApprovedBy = "user:john.doe",
            DisableNotificationDate = DateTimeOffset.Parse("2025-07-12T13:10:00Z"),
            NeedReviewAt = null,
            NeedReviewBy = "user:reviewer01",
            RejectedAt = null,
            RejectedBy = "user:jane.doe",

            // Null should be interpreted as omitted for these properties
            ActiveAmlSuspicions = null,
            ApiVersion = null,
            ApprovedAt = null,
            CallbackUrl = null,
            CallbackUrlNotification = null,
            DisableNotification = null,
            ExportType = null,
            FilteringScoreAmlSuspicions = null,
            FinishedAt = null,
            IP = null,
            Language = null,
            LocationIP = null,
            NotificationConfirmation = null,
            PortalSteps = null,
            QrCode = null,
            RawDataValue = null,
            SessionDuration = null,
            StartedAt = null,
            TransferAt = null,
            TransferMode = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CompanyTechnicalData
        {
            ActiveAmlSuspicions = false,
            ApiVersion = 2,
            ApprovedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
            CallbackUrl = "https://example.com/callback",
            CallbackUrlNotification = "https://example.com/notify",
            DisableNotification = false,
            ExportType = "json",
            FilteringScoreAmlSuspicions = 0.75f,
            FinishedAt = DateTimeOffset.Parse("2025-05-05T13:10:00Z"),
            IP = "192.168.1.1",
            Language = "fra",
            LocationIP = "203.0.113.45",
            NotificationConfirmation = false,
            PortalSteps =
            [
                CompanyTechnicalDataPortalStep.IdentityVerification,
                CompanyTechnicalDataPortalStep.Selfie,
                CompanyTechnicalDataPortalStep.FaceMatch,
            ],
            QrCode = "false",
            RawDataValue = true,
            SessionDuration = 45,
            StartedAt = DateTimeOffset.Parse("2025-05-05T13:00:00Z"),
            TransferAt = DateTimeOffset.Parse("2025-07-12T14:00:00Z"),
            TransferMode = "API",
        };

        Assert.Null(model.ApprovedBy);
        Assert.False(model.RawData.ContainsKey("approved_by"));
        Assert.Null(model.DisableNotificationDate);
        Assert.False(model.RawData.ContainsKey("disable_notification_date"));
        Assert.Null(model.NeedReviewAt);
        Assert.False(model.RawData.ContainsKey("need_review_at"));
        Assert.Null(model.NeedReviewBy);
        Assert.False(model.RawData.ContainsKey("need_review_by"));
        Assert.Null(model.RejectedAt);
        Assert.False(model.RawData.ContainsKey("rejected_at"));
        Assert.Null(model.RejectedBy);
        Assert.False(model.RawData.ContainsKey("rejected_by"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CompanyTechnicalData
        {
            ActiveAmlSuspicions = false,
            ApiVersion = 2,
            ApprovedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
            CallbackUrl = "https://example.com/callback",
            CallbackUrlNotification = "https://example.com/notify",
            DisableNotification = false,
            ExportType = "json",
            FilteringScoreAmlSuspicions = 0.75f,
            FinishedAt = DateTimeOffset.Parse("2025-05-05T13:10:00Z"),
            IP = "192.168.1.1",
            Language = "fra",
            LocationIP = "203.0.113.45",
            NotificationConfirmation = false,
            PortalSteps =
            [
                CompanyTechnicalDataPortalStep.IdentityVerification,
                CompanyTechnicalDataPortalStep.Selfie,
                CompanyTechnicalDataPortalStep.FaceMatch,
            ],
            QrCode = "false",
            RawDataValue = true,
            SessionDuration = 45,
            StartedAt = DateTimeOffset.Parse("2025-05-05T13:00:00Z"),
            TransferAt = DateTimeOffset.Parse("2025-07-12T14:00:00Z"),
            TransferMode = "API",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CompanyTechnicalData
        {
            ActiveAmlSuspicions = false,
            ApiVersion = 2,
            ApprovedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
            CallbackUrl = "https://example.com/callback",
            CallbackUrlNotification = "https://example.com/notify",
            DisableNotification = false,
            ExportType = "json",
            FilteringScoreAmlSuspicions = 0.75f,
            FinishedAt = DateTimeOffset.Parse("2025-05-05T13:10:00Z"),
            IP = "192.168.1.1",
            Language = "fra",
            LocationIP = "203.0.113.45",
            NotificationConfirmation = false,
            PortalSteps =
            [
                CompanyTechnicalDataPortalStep.IdentityVerification,
                CompanyTechnicalDataPortalStep.Selfie,
                CompanyTechnicalDataPortalStep.FaceMatch,
            ],
            QrCode = "false",
            RawDataValue = true,
            SessionDuration = 45,
            StartedAt = DateTimeOffset.Parse("2025-05-05T13:00:00Z"),
            TransferAt = DateTimeOffset.Parse("2025-07-12T14:00:00Z"),
            TransferMode = "API",

            ApprovedBy = null,
            DisableNotificationDate = null,
            NeedReviewAt = null,
            NeedReviewBy = null,
            RejectedAt = null,
            RejectedBy = null,
        };

        Assert.Null(model.ApprovedBy);
        Assert.True(model.RawData.ContainsKey("approved_by"));
        Assert.Null(model.DisableNotificationDate);
        Assert.True(model.RawData.ContainsKey("disable_notification_date"));
        Assert.Null(model.NeedReviewAt);
        Assert.True(model.RawData.ContainsKey("need_review_at"));
        Assert.Null(model.NeedReviewBy);
        Assert.True(model.RawData.ContainsKey("need_review_by"));
        Assert.Null(model.RejectedAt);
        Assert.True(model.RawData.ContainsKey("rejected_at"));
        Assert.Null(model.RejectedBy);
        Assert.True(model.RawData.ContainsKey("rejected_by"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CompanyTechnicalData
        {
            ActiveAmlSuspicions = false,
            ApiVersion = 2,
            ApprovedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
            CallbackUrl = "https://example.com/callback",
            CallbackUrlNotification = "https://example.com/notify",
            DisableNotification = false,
            ExportType = "json",
            FilteringScoreAmlSuspicions = 0.75f,
            FinishedAt = DateTimeOffset.Parse("2025-05-05T13:10:00Z"),
            IP = "192.168.1.1",
            Language = "fra",
            LocationIP = "203.0.113.45",
            NotificationConfirmation = false,
            PortalSteps =
            [
                CompanyTechnicalDataPortalStep.IdentityVerification,
                CompanyTechnicalDataPortalStep.Selfie,
                CompanyTechnicalDataPortalStep.FaceMatch,
            ],
            QrCode = "false",
            RawDataValue = true,
            SessionDuration = 45,
            StartedAt = DateTimeOffset.Parse("2025-05-05T13:00:00Z"),
            TransferAt = DateTimeOffset.Parse("2025-07-12T14:00:00Z"),
            TransferMode = "API",

            ApprovedBy = null,
            DisableNotificationDate = null,
            NeedReviewAt = null,
            NeedReviewBy = null,
            RejectedAt = null,
            RejectedBy = null,
        };

        model.Validate();
    }
}

public class CompanyTechnicalDataPortalStepTest : TestBase
{
    [Theory]
    [InlineData(CompanyTechnicalDataPortalStep.IdentityVerification)]
    [InlineData(CompanyTechnicalDataPortalStep.DocumentSigning)]
    [InlineData(CompanyTechnicalDataPortalStep.ProofOfAddress)]
    [InlineData(CompanyTechnicalDataPortalStep.Selfie)]
    [InlineData(CompanyTechnicalDataPortalStep.FaceMatch)]
    public void Validation_Works(CompanyTechnicalDataPortalStep rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CompanyTechnicalDataPortalStep> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CompanyTechnicalDataPortalStep>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DataleonlabsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CompanyTechnicalDataPortalStep.IdentityVerification)]
    [InlineData(CompanyTechnicalDataPortalStep.DocumentSigning)]
    [InlineData(CompanyTechnicalDataPortalStep.ProofOfAddress)]
    [InlineData(CompanyTechnicalDataPortalStep.Selfie)]
    [InlineData(CompanyTechnicalDataPortalStep.FaceMatch)]
    public void SerializationRoundtrip_Works(CompanyTechnicalDataPortalStep rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CompanyTechnicalDataPortalStep> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CompanyTechnicalDataPortalStep>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CompanyTechnicalDataPortalStep>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CompanyTechnicalDataPortalStep>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
