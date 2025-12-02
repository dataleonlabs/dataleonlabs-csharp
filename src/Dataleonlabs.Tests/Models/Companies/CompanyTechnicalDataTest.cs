using System;
using System.Collections.Generic;
using Dataleonlabs.Core;
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
            APIVersion = 2,
            ApprovedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
            CallbackURL = "https://example.com/callback",
            CallbackURLNotification = "https://example.com/notify",
            DisableNotification = false,
            DisableNotificationDate = DateTimeOffset.Parse("2025-07-12T13:10:00Z"),
            ExportType = "json",
            FilteringScoreAmlSuspicions = 0.75,
            FinishedAt = DateTimeOffset.Parse("2025-05-05T13:10:00Z"),
            IP = "192.168.1.1",
            Language = "fra",
            LocationIP = "203.0.113.45",
            NeedReviewAt = null,
            NotificationConfirmation = false,
            PortalSteps =
            [
                PortalStep1.IdentityVerification,
                PortalStep1.Selfie,
                PortalStep1.FaceMatch,
            ],
            QrCode = "false",
            RawData1 = true,
            RejectedAt = null,
            SessionDuration = 45,
            StartedAt = DateTimeOffset.Parse("2025-05-05T13:00:00Z"),
            TransferAt = DateTimeOffset.Parse("2025-07-12T14:00:00Z"),
            TransferMode = "API",
        };

        bool expectedActiveAmlSuspicions = false;
        long expectedAPIVersion = 2;
        DateTimeOffset expectedApprovedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z");
        string expectedCallbackURL = "https://example.com/callback";
        string expectedCallbackURLNotification = "https://example.com/notify";
        bool expectedDisableNotification = false;
        DateTimeOffset expectedDisableNotificationDate = DateTimeOffset.Parse(
            "2025-07-12T13:10:00Z"
        );
        string expectedExportType = "json";
        float expectedFilteringScoreAmlSuspicions = 0.75;
        DateTimeOffset expectedFinishedAt = DateTimeOffset.Parse("2025-05-05T13:10:00Z");
        string expectedIP = "192.168.1.1";
        string expectedLanguage = "fra";
        string expectedLocationIP = "203.0.113.45";
        DateTimeOffset expectedNeedReviewAt = null;
        bool expectedNotificationConfirmation = false;
        List<ApiEnum<string, PortalStep1>> expectedPortalSteps =
        [
            PortalStep1.IdentityVerification,
            PortalStep1.Selfie,
            PortalStep1.FaceMatch,
        ];
        string expectedQrCode = "false";
        bool expectedRawData1 = true;
        DateTimeOffset expectedRejectedAt = null;
        long expectedSessionDuration = 45;
        DateTimeOffset expectedStartedAt = DateTimeOffset.Parse("2025-05-05T13:00:00Z");
        DateTimeOffset expectedTransferAt = DateTimeOffset.Parse("2025-07-12T14:00:00Z");
        string expectedTransferMode = "API";

        Assert.Equal(expectedActiveAmlSuspicions, model.ActiveAmlSuspicions);
        Assert.Equal(expectedAPIVersion, model.APIVersion);
        Assert.Equal(expectedApprovedAt, model.ApprovedAt);
        Assert.Equal(expectedCallbackURL, model.CallbackURL);
        Assert.Equal(expectedCallbackURLNotification, model.CallbackURLNotification);
        Assert.Equal(expectedDisableNotification, model.DisableNotification);
        Assert.Equal(expectedDisableNotificationDate, model.DisableNotificationDate);
        Assert.Equal(expectedExportType, model.ExportType);
        Assert.Equal(expectedFilteringScoreAmlSuspicions, model.FilteringScoreAmlSuspicions);
        Assert.Equal(expectedFinishedAt, model.FinishedAt);
        Assert.Equal(expectedIP, model.IP);
        Assert.Equal(expectedLanguage, model.Language);
        Assert.Equal(expectedLocationIP, model.LocationIP);
        Assert.Equal(expectedNeedReviewAt, model.NeedReviewAt);
        Assert.Equal(expectedNotificationConfirmation, model.NotificationConfirmation);
        Assert.Equal(expectedPortalSteps.Count, model.PortalSteps.Count);
        for (int i = 0; i < expectedPortalSteps.Count; i++)
        {
            Assert.Equal(expectedPortalSteps[i], model.PortalSteps[i]);
        }
        Assert.Equal(expectedQrCode, model.QrCode);
        Assert.Equal(expectedRawData1, model.RawData1);
        Assert.Equal(expectedRejectedAt, model.RejectedAt);
        Assert.Equal(expectedSessionDuration, model.SessionDuration);
        Assert.Equal(expectedStartedAt, model.StartedAt);
        Assert.Equal(expectedTransferAt, model.TransferAt);
        Assert.Equal(expectedTransferMode, model.TransferMode);
    }
}
