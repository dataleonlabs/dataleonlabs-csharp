using System;
using System.Collections.Generic;
using System.Text.Json;
using Dataleonlabs.Models.Companies.Documents;
using Dataleonlabs.Models.Individuals;
using Companies = Dataleonlabs.Models.Companies;

namespace Dataleonlabs.Tests.Models.Individuals;

public class IndividualTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Individual
        {
            ID = "123e4567-e89b-12d3-a456-426614174000",
            AmlSuspicions =
            [
                new()
                {
                    Caption = "Suspicious activity",
                    Country = "FR",
                    Gender = "M",
                    Relation = "linked",
                    Schema = "v1",
                    Score = 0.85f,
                    Source = "https://aml-checker.example.com/api/v1/suspicion/12345",
                    Status = Companies::AmlSuspicionStatus.Pending,
                    Type = Companies::Type.Pep,
                },
            ],
            AuthUrl = "https://id.dataleon.ai/a/123",
            Certificat = new()
            {
                ID = "cert_123",
                CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
                Filename = "certificate.pdf",
            },
            Checks =
            [
                new()
                {
                    Masked = false,
                    Message = "Name matched successfully",
                    Name = "name_match",
                    ValidateValue = true,
                    Weight = 1,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Documents =
            [
                new()
                {
                    ID = "doc_123",
                    Checks =
                    [
                        new()
                        {
                            Masked = false,
                            Message = "Name matched successfully",
                            Name = "name_match",
                            ValidateValue = true,
                            Weight = 1,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
                    DocumentType = "generic",
                    Name = "generic_doc",
                    SignedUrl = "https://cdn.example.com/doc.pdf",
                    State = "SUBMITTED",
                    Status = "approved",
                    Tables =
                    [
                        new() { Operation = [JsonSerializer.Deserialize<JsonElement>("{}")] },
                    ],
                    Values =
                    [
                        new()
                        {
                            Confidence = 0.95,
                            Name = "Full Name",
                            ValueValue = [100, 200],
                        },
                    ],
                },
            ],
            IdentityCard = new()
            {
                ID = "doc_001",
                BackDocumentSignedUrl = "https://cdn.example.com/back.jpg",
                BirthPlace = "Paris",
                Birthday = "01/01/1990",
                Country = "FR",
                EntitlementDate = "entitlement_date",
                ExpirationDate = "2030-01-01",
                FirstName = "John",
                FrontDocumentSignedUrl = "https://cdn.example.com/front.jpg",
                Gender = "M",
                IssueDate = "2020-01-01",
                LastName = "Doe",
                MrzLine1 = "P<FRADOE<<JOHN<<<<<<<<<<<<<<<<<<<",
                MrzLine2 = "1234567890FRA9001019M2301012<<<<<<<<<<<<<<04",
                MrzLine3 = null,
                Type = "passport",
            },
            Number = 42,
            Person = new()
            {
                Birthday = "01/01/1990",
                Email = "john.doe@example.com",
                FaceImageSignedUrl = "https://cdn.example.com/face.jpg",
                FirstName = "John",
                FullName = "John Doe",
                Gender = "M",
                LastName = "Doe",
                MaidenName = "Smith",
                Nationality = "FRA",
                PhoneNumber = "+33612345678",
            },
            PortalUrl = "https://portal.dataleon.ai/w/123",
            Properties =
            [
                new()
                {
                    Name = "property_name",
                    Type = "string",
                    Value = "property_value",
                },
            ],
            Risk = new()
            {
                Code = "20030",
                Reason = "Document mismatch",
                Score = 0.92f,
            },
            SourceID = "ID54410069066",
            State = "WAITING",
            Status = "rejected",
            Tags =
            [
                new()
                {
                    Key = "tag_name",
                    Private = false,
                    Type = "string",
                    Value = "tag_value",
                },
            ],
            TechnicalData = new()
            {
                ActiveAmlSuspicions = false,
                ApiVersion = 2,
                ApprovedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
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
                NotificationConfirmation = false,
                PortalSteps =
                [
                    Companies::CompanyTechnicalDataPortalStep.IdentityVerification,
                    Companies::CompanyTechnicalDataPortalStep.Selfie,
                    Companies::CompanyTechnicalDataPortalStep.FaceMatch,
                ],
                QrCode = "false",
                RawDataValue = true,
                RejectedAt = null,
                SessionDuration = 45,
                StartedAt = DateTimeOffset.Parse("2025-05-05T13:00:00Z"),
                TransferAt = DateTimeOffset.Parse("2025-07-12T14:00:00Z"),
                TransferMode = "API",
            },
            WebviewUrl = "https://id.dataleon.ai/w/123",
            WorkspaceID = "wk_123",
        };

        string expectedID = "123e4567-e89b-12d3-a456-426614174000";
        List<Companies::AmlSuspicion> expectedAmlSuspicions =
        [
            new()
            {
                Caption = "Suspicious activity",
                Country = "FR",
                Gender = "M",
                Relation = "linked",
                Schema = "v1",
                Score = 0.85f,
                Source = "https://aml-checker.example.com/api/v1/suspicion/12345",
                Status = Companies::AmlSuspicionStatus.Pending,
                Type = Companies::Type.Pep,
            },
        ];
        string expectedAuthUrl = "https://id.dataleon.ai/a/123";
        Companies::Certificat expectedCertificat = new()
        {
            ID = "cert_123",
            CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
            Filename = "certificate.pdf",
        };
        List<Companies::Check> expectedChecks =
        [
            new()
            {
                Masked = false,
                Message = "Name matched successfully",
                Name = "name_match",
                ValidateValue = true,
                Weight = 1,
            },
        ];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<GenericDocument> expectedDocuments =
        [
            new()
            {
                ID = "doc_123",
                Checks =
                [
                    new()
                    {
                        Masked = false,
                        Message = "Name matched successfully",
                        Name = "name_match",
                        ValidateValue = true,
                        Weight = 1,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
                DocumentType = "generic",
                Name = "generic_doc",
                SignedUrl = "https://cdn.example.com/doc.pdf",
                State = "SUBMITTED",
                Status = "approved",
                Tables = [new() { Operation = [JsonSerializer.Deserialize<JsonElement>("{}")] }],
                Values =
                [
                    new()
                    {
                        Confidence = 0.95,
                        Name = "Full Name",
                        ValueValue = [100, 200],
                    },
                ],
            },
        ];
        IdentityCard expectedIdentityCard = new()
        {
            ID = "doc_001",
            BackDocumentSignedUrl = "https://cdn.example.com/back.jpg",
            BirthPlace = "Paris",
            Birthday = "01/01/1990",
            Country = "FR",
            EntitlementDate = "entitlement_date",
            ExpirationDate = "2030-01-01",
            FirstName = "John",
            FrontDocumentSignedUrl = "https://cdn.example.com/front.jpg",
            Gender = "M",
            IssueDate = "2020-01-01",
            LastName = "Doe",
            MrzLine1 = "P<FRADOE<<JOHN<<<<<<<<<<<<<<<<<<<",
            MrzLine2 = "1234567890FRA9001019M2301012<<<<<<<<<<<<<<04",
            MrzLine3 = null,
            Type = "passport",
        };
        long expectedNumber = 42;
        IndividualPerson expectedPerson = new()
        {
            Birthday = "01/01/1990",
            Email = "john.doe@example.com",
            FaceImageSignedUrl = "https://cdn.example.com/face.jpg",
            FirstName = "John",
            FullName = "John Doe",
            Gender = "M",
            LastName = "Doe",
            MaidenName = "Smith",
            Nationality = "FRA",
            PhoneNumber = "+33612345678",
        };
        string expectedPortalUrl = "https://portal.dataleon.ai/w/123";
        List<Companies::Property> expectedProperties =
        [
            new()
            {
                Name = "property_name",
                Type = "string",
                Value = "property_value",
            },
        ];
        Companies::Risk expectedRisk = new()
        {
            Code = "20030",
            Reason = "Document mismatch",
            Score = 0.92f,
        };
        string expectedSourceID = "ID54410069066";
        string expectedState = "WAITING";
        string expectedStatus = "rejected";
        List<Tag> expectedTags =
        [
            new()
            {
                Key = "tag_name",
                Private = false,
                Type = "string",
                Value = "tag_value",
            },
        ];
        Companies::CompanyTechnicalData expectedTechnicalData = new()
        {
            ActiveAmlSuspicions = false,
            ApiVersion = 2,
            ApprovedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
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
            NotificationConfirmation = false,
            PortalSteps =
            [
                Companies::CompanyTechnicalDataPortalStep.IdentityVerification,
                Companies::CompanyTechnicalDataPortalStep.Selfie,
                Companies::CompanyTechnicalDataPortalStep.FaceMatch,
            ],
            QrCode = "false",
            RawDataValue = true,
            RejectedAt = null,
            SessionDuration = 45,
            StartedAt = DateTimeOffset.Parse("2025-05-05T13:00:00Z"),
            TransferAt = DateTimeOffset.Parse("2025-07-12T14:00:00Z"),
            TransferMode = "API",
        };
        string expectedWebviewUrl = "https://id.dataleon.ai/w/123";
        string expectedWorkspaceID = "wk_123";

        Assert.Equal(expectedID, model.ID);
        Assert.NotNull(model.AmlSuspicions);
        Assert.Equal(expectedAmlSuspicions.Count, model.AmlSuspicions.Count);
        for (int i = 0; i < expectedAmlSuspicions.Count; i++)
        {
            Assert.Equal(expectedAmlSuspicions[i], model.AmlSuspicions[i]);
        }
        Assert.Equal(expectedAuthUrl, model.AuthUrl);
        Assert.Equal(expectedCertificat, model.Certificat);
        Assert.NotNull(model.Checks);
        Assert.Equal(expectedChecks.Count, model.Checks.Count);
        for (int i = 0; i < expectedChecks.Count; i++)
        {
            Assert.Equal(expectedChecks[i], model.Checks[i]);
        }
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.NotNull(model.Documents);
        Assert.Equal(expectedDocuments.Count, model.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], model.Documents[i]);
        }
        Assert.Equal(expectedIdentityCard, model.IdentityCard);
        Assert.Equal(expectedNumber, model.Number);
        Assert.Equal(expectedPerson, model.Person);
        Assert.Equal(expectedPortalUrl, model.PortalUrl);
        Assert.NotNull(model.Properties);
        Assert.Equal(expectedProperties.Count, model.Properties.Count);
        for (int i = 0; i < expectedProperties.Count; i++)
        {
            Assert.Equal(expectedProperties[i], model.Properties[i]);
        }
        Assert.Equal(expectedRisk, model.Risk);
        Assert.Equal(expectedSourceID, model.SourceID);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedTechnicalData, model.TechnicalData);
        Assert.Equal(expectedWebviewUrl, model.WebviewUrl);
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Individual
        {
            ID = "123e4567-e89b-12d3-a456-426614174000",
            AmlSuspicions =
            [
                new()
                {
                    Caption = "Suspicious activity",
                    Country = "FR",
                    Gender = "M",
                    Relation = "linked",
                    Schema = "v1",
                    Score = 0.85f,
                    Source = "https://aml-checker.example.com/api/v1/suspicion/12345",
                    Status = Companies::AmlSuspicionStatus.Pending,
                    Type = Companies::Type.Pep,
                },
            ],
            AuthUrl = "https://id.dataleon.ai/a/123",
            Certificat = new()
            {
                ID = "cert_123",
                CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
                Filename = "certificate.pdf",
            },
            Checks =
            [
                new()
                {
                    Masked = false,
                    Message = "Name matched successfully",
                    Name = "name_match",
                    ValidateValue = true,
                    Weight = 1,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Documents =
            [
                new()
                {
                    ID = "doc_123",
                    Checks =
                    [
                        new()
                        {
                            Masked = false,
                            Message = "Name matched successfully",
                            Name = "name_match",
                            ValidateValue = true,
                            Weight = 1,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
                    DocumentType = "generic",
                    Name = "generic_doc",
                    SignedUrl = "https://cdn.example.com/doc.pdf",
                    State = "SUBMITTED",
                    Status = "approved",
                    Tables =
                    [
                        new() { Operation = [JsonSerializer.Deserialize<JsonElement>("{}")] },
                    ],
                    Values =
                    [
                        new()
                        {
                            Confidence = 0.95,
                            Name = "Full Name",
                            ValueValue = [100, 200],
                        },
                    ],
                },
            ],
            IdentityCard = new()
            {
                ID = "doc_001",
                BackDocumentSignedUrl = "https://cdn.example.com/back.jpg",
                BirthPlace = "Paris",
                Birthday = "01/01/1990",
                Country = "FR",
                EntitlementDate = "entitlement_date",
                ExpirationDate = "2030-01-01",
                FirstName = "John",
                FrontDocumentSignedUrl = "https://cdn.example.com/front.jpg",
                Gender = "M",
                IssueDate = "2020-01-01",
                LastName = "Doe",
                MrzLine1 = "P<FRADOE<<JOHN<<<<<<<<<<<<<<<<<<<",
                MrzLine2 = "1234567890FRA9001019M2301012<<<<<<<<<<<<<<04",
                MrzLine3 = null,
                Type = "passport",
            },
            Number = 42,
            Person = new()
            {
                Birthday = "01/01/1990",
                Email = "john.doe@example.com",
                FaceImageSignedUrl = "https://cdn.example.com/face.jpg",
                FirstName = "John",
                FullName = "John Doe",
                Gender = "M",
                LastName = "Doe",
                MaidenName = "Smith",
                Nationality = "FRA",
                PhoneNumber = "+33612345678",
            },
            PortalUrl = "https://portal.dataleon.ai/w/123",
            Properties =
            [
                new()
                {
                    Name = "property_name",
                    Type = "string",
                    Value = "property_value",
                },
            ],
            Risk = new()
            {
                Code = "20030",
                Reason = "Document mismatch",
                Score = 0.92f,
            },
            SourceID = "ID54410069066",
            State = "WAITING",
            Status = "rejected",
            Tags =
            [
                new()
                {
                    Key = "tag_name",
                    Private = false,
                    Type = "string",
                    Value = "tag_value",
                },
            ],
            TechnicalData = new()
            {
                ActiveAmlSuspicions = false,
                ApiVersion = 2,
                ApprovedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
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
                NotificationConfirmation = false,
                PortalSteps =
                [
                    Companies::CompanyTechnicalDataPortalStep.IdentityVerification,
                    Companies::CompanyTechnicalDataPortalStep.Selfie,
                    Companies::CompanyTechnicalDataPortalStep.FaceMatch,
                ],
                QrCode = "false",
                RawDataValue = true,
                RejectedAt = null,
                SessionDuration = 45,
                StartedAt = DateTimeOffset.Parse("2025-05-05T13:00:00Z"),
                TransferAt = DateTimeOffset.Parse("2025-07-12T14:00:00Z"),
                TransferMode = "API",
            },
            WebviewUrl = "https://id.dataleon.ai/w/123",
            WorkspaceID = "wk_123",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Individual>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Individual
        {
            ID = "123e4567-e89b-12d3-a456-426614174000",
            AmlSuspicions =
            [
                new()
                {
                    Caption = "Suspicious activity",
                    Country = "FR",
                    Gender = "M",
                    Relation = "linked",
                    Schema = "v1",
                    Score = 0.85f,
                    Source = "https://aml-checker.example.com/api/v1/suspicion/12345",
                    Status = Companies::AmlSuspicionStatus.Pending,
                    Type = Companies::Type.Pep,
                },
            ],
            AuthUrl = "https://id.dataleon.ai/a/123",
            Certificat = new()
            {
                ID = "cert_123",
                CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
                Filename = "certificate.pdf",
            },
            Checks =
            [
                new()
                {
                    Masked = false,
                    Message = "Name matched successfully",
                    Name = "name_match",
                    ValidateValue = true,
                    Weight = 1,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Documents =
            [
                new()
                {
                    ID = "doc_123",
                    Checks =
                    [
                        new()
                        {
                            Masked = false,
                            Message = "Name matched successfully",
                            Name = "name_match",
                            ValidateValue = true,
                            Weight = 1,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
                    DocumentType = "generic",
                    Name = "generic_doc",
                    SignedUrl = "https://cdn.example.com/doc.pdf",
                    State = "SUBMITTED",
                    Status = "approved",
                    Tables =
                    [
                        new() { Operation = [JsonSerializer.Deserialize<JsonElement>("{}")] },
                    ],
                    Values =
                    [
                        new()
                        {
                            Confidence = 0.95,
                            Name = "Full Name",
                            ValueValue = [100, 200],
                        },
                    ],
                },
            ],
            IdentityCard = new()
            {
                ID = "doc_001",
                BackDocumentSignedUrl = "https://cdn.example.com/back.jpg",
                BirthPlace = "Paris",
                Birthday = "01/01/1990",
                Country = "FR",
                EntitlementDate = "entitlement_date",
                ExpirationDate = "2030-01-01",
                FirstName = "John",
                FrontDocumentSignedUrl = "https://cdn.example.com/front.jpg",
                Gender = "M",
                IssueDate = "2020-01-01",
                LastName = "Doe",
                MrzLine1 = "P<FRADOE<<JOHN<<<<<<<<<<<<<<<<<<<",
                MrzLine2 = "1234567890FRA9001019M2301012<<<<<<<<<<<<<<04",
                MrzLine3 = null,
                Type = "passport",
            },
            Number = 42,
            Person = new()
            {
                Birthday = "01/01/1990",
                Email = "john.doe@example.com",
                FaceImageSignedUrl = "https://cdn.example.com/face.jpg",
                FirstName = "John",
                FullName = "John Doe",
                Gender = "M",
                LastName = "Doe",
                MaidenName = "Smith",
                Nationality = "FRA",
                PhoneNumber = "+33612345678",
            },
            PortalUrl = "https://portal.dataleon.ai/w/123",
            Properties =
            [
                new()
                {
                    Name = "property_name",
                    Type = "string",
                    Value = "property_value",
                },
            ],
            Risk = new()
            {
                Code = "20030",
                Reason = "Document mismatch",
                Score = 0.92f,
            },
            SourceID = "ID54410069066",
            State = "WAITING",
            Status = "rejected",
            Tags =
            [
                new()
                {
                    Key = "tag_name",
                    Private = false,
                    Type = "string",
                    Value = "tag_value",
                },
            ],
            TechnicalData = new()
            {
                ActiveAmlSuspicions = false,
                ApiVersion = 2,
                ApprovedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
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
                NotificationConfirmation = false,
                PortalSteps =
                [
                    Companies::CompanyTechnicalDataPortalStep.IdentityVerification,
                    Companies::CompanyTechnicalDataPortalStep.Selfie,
                    Companies::CompanyTechnicalDataPortalStep.FaceMatch,
                ],
                QrCode = "false",
                RawDataValue = true,
                RejectedAt = null,
                SessionDuration = 45,
                StartedAt = DateTimeOffset.Parse("2025-05-05T13:00:00Z"),
                TransferAt = DateTimeOffset.Parse("2025-07-12T14:00:00Z"),
                TransferMode = "API",
            },
            WebviewUrl = "https://id.dataleon.ai/w/123",
            WorkspaceID = "wk_123",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Individual>(element);
        Assert.NotNull(deserialized);

        string expectedID = "123e4567-e89b-12d3-a456-426614174000";
        List<Companies::AmlSuspicion> expectedAmlSuspicions =
        [
            new()
            {
                Caption = "Suspicious activity",
                Country = "FR",
                Gender = "M",
                Relation = "linked",
                Schema = "v1",
                Score = 0.85f,
                Source = "https://aml-checker.example.com/api/v1/suspicion/12345",
                Status = Companies::AmlSuspicionStatus.Pending,
                Type = Companies::Type.Pep,
            },
        ];
        string expectedAuthUrl = "https://id.dataleon.ai/a/123";
        Companies::Certificat expectedCertificat = new()
        {
            ID = "cert_123",
            CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
            Filename = "certificate.pdf",
        };
        List<Companies::Check> expectedChecks =
        [
            new()
            {
                Masked = false,
                Message = "Name matched successfully",
                Name = "name_match",
                ValidateValue = true,
                Weight = 1,
            },
        ];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<GenericDocument> expectedDocuments =
        [
            new()
            {
                ID = "doc_123",
                Checks =
                [
                    new()
                    {
                        Masked = false,
                        Message = "Name matched successfully",
                        Name = "name_match",
                        ValidateValue = true,
                        Weight = 1,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
                DocumentType = "generic",
                Name = "generic_doc",
                SignedUrl = "https://cdn.example.com/doc.pdf",
                State = "SUBMITTED",
                Status = "approved",
                Tables = [new() { Operation = [JsonSerializer.Deserialize<JsonElement>("{}")] }],
                Values =
                [
                    new()
                    {
                        Confidence = 0.95,
                        Name = "Full Name",
                        ValueValue = [100, 200],
                    },
                ],
            },
        ];
        IdentityCard expectedIdentityCard = new()
        {
            ID = "doc_001",
            BackDocumentSignedUrl = "https://cdn.example.com/back.jpg",
            BirthPlace = "Paris",
            Birthday = "01/01/1990",
            Country = "FR",
            EntitlementDate = "entitlement_date",
            ExpirationDate = "2030-01-01",
            FirstName = "John",
            FrontDocumentSignedUrl = "https://cdn.example.com/front.jpg",
            Gender = "M",
            IssueDate = "2020-01-01",
            LastName = "Doe",
            MrzLine1 = "P<FRADOE<<JOHN<<<<<<<<<<<<<<<<<<<",
            MrzLine2 = "1234567890FRA9001019M2301012<<<<<<<<<<<<<<04",
            MrzLine3 = null,
            Type = "passport",
        };
        long expectedNumber = 42;
        IndividualPerson expectedPerson = new()
        {
            Birthday = "01/01/1990",
            Email = "john.doe@example.com",
            FaceImageSignedUrl = "https://cdn.example.com/face.jpg",
            FirstName = "John",
            FullName = "John Doe",
            Gender = "M",
            LastName = "Doe",
            MaidenName = "Smith",
            Nationality = "FRA",
            PhoneNumber = "+33612345678",
        };
        string expectedPortalUrl = "https://portal.dataleon.ai/w/123";
        List<Companies::Property> expectedProperties =
        [
            new()
            {
                Name = "property_name",
                Type = "string",
                Value = "property_value",
            },
        ];
        Companies::Risk expectedRisk = new()
        {
            Code = "20030",
            Reason = "Document mismatch",
            Score = 0.92f,
        };
        string expectedSourceID = "ID54410069066";
        string expectedState = "WAITING";
        string expectedStatus = "rejected";
        List<Tag> expectedTags =
        [
            new()
            {
                Key = "tag_name",
                Private = false,
                Type = "string",
                Value = "tag_value",
            },
        ];
        Companies::CompanyTechnicalData expectedTechnicalData = new()
        {
            ActiveAmlSuspicions = false,
            ApiVersion = 2,
            ApprovedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
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
            NotificationConfirmation = false,
            PortalSteps =
            [
                Companies::CompanyTechnicalDataPortalStep.IdentityVerification,
                Companies::CompanyTechnicalDataPortalStep.Selfie,
                Companies::CompanyTechnicalDataPortalStep.FaceMatch,
            ],
            QrCode = "false",
            RawDataValue = true,
            RejectedAt = null,
            SessionDuration = 45,
            StartedAt = DateTimeOffset.Parse("2025-05-05T13:00:00Z"),
            TransferAt = DateTimeOffset.Parse("2025-07-12T14:00:00Z"),
            TransferMode = "API",
        };
        string expectedWebviewUrl = "https://id.dataleon.ai/w/123";
        string expectedWorkspaceID = "wk_123";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.NotNull(deserialized.AmlSuspicions);
        Assert.Equal(expectedAmlSuspicions.Count, deserialized.AmlSuspicions.Count);
        for (int i = 0; i < expectedAmlSuspicions.Count; i++)
        {
            Assert.Equal(expectedAmlSuspicions[i], deserialized.AmlSuspicions[i]);
        }
        Assert.Equal(expectedAuthUrl, deserialized.AuthUrl);
        Assert.Equal(expectedCertificat, deserialized.Certificat);
        Assert.NotNull(deserialized.Checks);
        Assert.Equal(expectedChecks.Count, deserialized.Checks.Count);
        for (int i = 0; i < expectedChecks.Count; i++)
        {
            Assert.Equal(expectedChecks[i], deserialized.Checks[i]);
        }
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.NotNull(deserialized.Documents);
        Assert.Equal(expectedDocuments.Count, deserialized.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], deserialized.Documents[i]);
        }
        Assert.Equal(expectedIdentityCard, deserialized.IdentityCard);
        Assert.Equal(expectedNumber, deserialized.Number);
        Assert.Equal(expectedPerson, deserialized.Person);
        Assert.Equal(expectedPortalUrl, deserialized.PortalUrl);
        Assert.NotNull(deserialized.Properties);
        Assert.Equal(expectedProperties.Count, deserialized.Properties.Count);
        for (int i = 0; i < expectedProperties.Count; i++)
        {
            Assert.Equal(expectedProperties[i], deserialized.Properties[i]);
        }
        Assert.Equal(expectedRisk, deserialized.Risk);
        Assert.Equal(expectedSourceID, deserialized.SourceID);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.Equal(expectedTechnicalData, deserialized.TechnicalData);
        Assert.Equal(expectedWebviewUrl, deserialized.WebviewUrl);
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Individual
        {
            ID = "123e4567-e89b-12d3-a456-426614174000",
            AmlSuspicions =
            [
                new()
                {
                    Caption = "Suspicious activity",
                    Country = "FR",
                    Gender = "M",
                    Relation = "linked",
                    Schema = "v1",
                    Score = 0.85f,
                    Source = "https://aml-checker.example.com/api/v1/suspicion/12345",
                    Status = Companies::AmlSuspicionStatus.Pending,
                    Type = Companies::Type.Pep,
                },
            ],
            AuthUrl = "https://id.dataleon.ai/a/123",
            Certificat = new()
            {
                ID = "cert_123",
                CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
                Filename = "certificate.pdf",
            },
            Checks =
            [
                new()
                {
                    Masked = false,
                    Message = "Name matched successfully",
                    Name = "name_match",
                    ValidateValue = true,
                    Weight = 1,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Documents =
            [
                new()
                {
                    ID = "doc_123",
                    Checks =
                    [
                        new()
                        {
                            Masked = false,
                            Message = "Name matched successfully",
                            Name = "name_match",
                            ValidateValue = true,
                            Weight = 1,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
                    DocumentType = "generic",
                    Name = "generic_doc",
                    SignedUrl = "https://cdn.example.com/doc.pdf",
                    State = "SUBMITTED",
                    Status = "approved",
                    Tables =
                    [
                        new() { Operation = [JsonSerializer.Deserialize<JsonElement>("{}")] },
                    ],
                    Values =
                    [
                        new()
                        {
                            Confidence = 0.95,
                            Name = "Full Name",
                            ValueValue = [100, 200],
                        },
                    ],
                },
            ],
            IdentityCard = new()
            {
                ID = "doc_001",
                BackDocumentSignedUrl = "https://cdn.example.com/back.jpg",
                BirthPlace = "Paris",
                Birthday = "01/01/1990",
                Country = "FR",
                EntitlementDate = "entitlement_date",
                ExpirationDate = "2030-01-01",
                FirstName = "John",
                FrontDocumentSignedUrl = "https://cdn.example.com/front.jpg",
                Gender = "M",
                IssueDate = "2020-01-01",
                LastName = "Doe",
                MrzLine1 = "P<FRADOE<<JOHN<<<<<<<<<<<<<<<<<<<",
                MrzLine2 = "1234567890FRA9001019M2301012<<<<<<<<<<<<<<04",
                MrzLine3 = null,
                Type = "passport",
            },
            Number = 42,
            Person = new()
            {
                Birthday = "01/01/1990",
                Email = "john.doe@example.com",
                FaceImageSignedUrl = "https://cdn.example.com/face.jpg",
                FirstName = "John",
                FullName = "John Doe",
                Gender = "M",
                LastName = "Doe",
                MaidenName = "Smith",
                Nationality = "FRA",
                PhoneNumber = "+33612345678",
            },
            PortalUrl = "https://portal.dataleon.ai/w/123",
            Properties =
            [
                new()
                {
                    Name = "property_name",
                    Type = "string",
                    Value = "property_value",
                },
            ],
            Risk = new()
            {
                Code = "20030",
                Reason = "Document mismatch",
                Score = 0.92f,
            },
            SourceID = "ID54410069066",
            State = "WAITING",
            Status = "rejected",
            Tags =
            [
                new()
                {
                    Key = "tag_name",
                    Private = false,
                    Type = "string",
                    Value = "tag_value",
                },
            ],
            TechnicalData = new()
            {
                ActiveAmlSuspicions = false,
                ApiVersion = 2,
                ApprovedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
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
                NotificationConfirmation = false,
                PortalSteps =
                [
                    Companies::CompanyTechnicalDataPortalStep.IdentityVerification,
                    Companies::CompanyTechnicalDataPortalStep.Selfie,
                    Companies::CompanyTechnicalDataPortalStep.FaceMatch,
                ],
                QrCode = "false",
                RawDataValue = true,
                RejectedAt = null,
                SessionDuration = 45,
                StartedAt = DateTimeOffset.Parse("2025-05-05T13:00:00Z"),
                TransferAt = DateTimeOffset.Parse("2025-07-12T14:00:00Z"),
                TransferMode = "API",
            },
            WebviewUrl = "https://id.dataleon.ai/w/123",
            WorkspaceID = "wk_123",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Individual { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AmlSuspicions);
        Assert.False(model.RawData.ContainsKey("aml_suspicions"));
        Assert.Null(model.AuthUrl);
        Assert.False(model.RawData.ContainsKey("auth_url"));
        Assert.Null(model.Certificat);
        Assert.False(model.RawData.ContainsKey("certificat"));
        Assert.Null(model.Checks);
        Assert.False(model.RawData.ContainsKey("checks"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Documents);
        Assert.False(model.RawData.ContainsKey("documents"));
        Assert.Null(model.IdentityCard);
        Assert.False(model.RawData.ContainsKey("identity_card"));
        Assert.Null(model.Number);
        Assert.False(model.RawData.ContainsKey("number"));
        Assert.Null(model.Person);
        Assert.False(model.RawData.ContainsKey("person"));
        Assert.Null(model.PortalUrl);
        Assert.False(model.RawData.ContainsKey("portal_url"));
        Assert.Null(model.Properties);
        Assert.False(model.RawData.ContainsKey("properties"));
        Assert.Null(model.Risk);
        Assert.False(model.RawData.ContainsKey("risk"));
        Assert.Null(model.SourceID);
        Assert.False(model.RawData.ContainsKey("source_id"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.TechnicalData);
        Assert.False(model.RawData.ContainsKey("technical_data"));
        Assert.Null(model.WebviewUrl);
        Assert.False(model.RawData.ContainsKey("webview_url"));
        Assert.Null(model.WorkspaceID);
        Assert.False(model.RawData.ContainsKey("workspace_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Individual { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Individual
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            AmlSuspicions = null,
            AuthUrl = null,
            Certificat = null,
            Checks = null,
            CreatedAt = null,
            Documents = null,
            IdentityCard = null,
            Number = null,
            Person = null,
            PortalUrl = null,
            Properties = null,
            Risk = null,
            SourceID = null,
            State = null,
            Status = null,
            Tags = null,
            TechnicalData = null,
            WebviewUrl = null,
            WorkspaceID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AmlSuspicions);
        Assert.False(model.RawData.ContainsKey("aml_suspicions"));
        Assert.Null(model.AuthUrl);
        Assert.False(model.RawData.ContainsKey("auth_url"));
        Assert.Null(model.Certificat);
        Assert.False(model.RawData.ContainsKey("certificat"));
        Assert.Null(model.Checks);
        Assert.False(model.RawData.ContainsKey("checks"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Documents);
        Assert.False(model.RawData.ContainsKey("documents"));
        Assert.Null(model.IdentityCard);
        Assert.False(model.RawData.ContainsKey("identity_card"));
        Assert.Null(model.Number);
        Assert.False(model.RawData.ContainsKey("number"));
        Assert.Null(model.Person);
        Assert.False(model.RawData.ContainsKey("person"));
        Assert.Null(model.PortalUrl);
        Assert.False(model.RawData.ContainsKey("portal_url"));
        Assert.Null(model.Properties);
        Assert.False(model.RawData.ContainsKey("properties"));
        Assert.Null(model.Risk);
        Assert.False(model.RawData.ContainsKey("risk"));
        Assert.Null(model.SourceID);
        Assert.False(model.RawData.ContainsKey("source_id"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.TechnicalData);
        Assert.False(model.RawData.ContainsKey("technical_data"));
        Assert.Null(model.WebviewUrl);
        Assert.False(model.RawData.ContainsKey("webview_url"));
        Assert.Null(model.WorkspaceID);
        Assert.False(model.RawData.ContainsKey("workspace_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Individual
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            AmlSuspicions = null,
            AuthUrl = null,
            Certificat = null,
            Checks = null,
            CreatedAt = null,
            Documents = null,
            IdentityCard = null,
            Number = null,
            Person = null,
            PortalUrl = null,
            Properties = null,
            Risk = null,
            SourceID = null,
            State = null,
            Status = null,
            Tags = null,
            TechnicalData = null,
            WebviewUrl = null,
            WorkspaceID = null,
        };

        model.Validate();
    }
}

public class IdentityCardTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IdentityCard
        {
            ID = "doc_001",
            BackDocumentSignedUrl = "https://cdn.example.com/back.jpg",
            BirthPlace = "Paris",
            Birthday = "01/01/1990",
            Country = "FR",
            EntitlementDate = "entitlement_date",
            ExpirationDate = "2030-01-01",
            FirstName = "John",
            FrontDocumentSignedUrl = "https://cdn.example.com/front.jpg",
            Gender = "M",
            IssueDate = "2020-01-01",
            LastName = "Doe",
            MrzLine1 = "P<FRADOE<<JOHN<<<<<<<<<<<<<<<<<<<",
            MrzLine2 = "1234567890FRA9001019M2301012<<<<<<<<<<<<<<04",
            MrzLine3 = null,
            Type = "passport",
        };

        string expectedID = "doc_001";
        string expectedBackDocumentSignedUrl = "https://cdn.example.com/back.jpg";
        string expectedBirthPlace = "Paris";
        string expectedBirthday = "01/01/1990";
        string expectedCountry = "FR";
        string expectedEntitlementDate = "entitlement_date";
        string expectedExpirationDate = "2030-01-01";
        string expectedFirstName = "John";
        string expectedFrontDocumentSignedUrl = "https://cdn.example.com/front.jpg";
        string expectedGender = "M";
        string expectedIssueDate = "2020-01-01";
        string expectedLastName = "Doe";
        string expectedMrzLine1 = "P<FRADOE<<JOHN<<<<<<<<<<<<<<<<<<<";
        string expectedMrzLine2 = "1234567890FRA9001019M2301012<<<<<<<<<<<<<<04";
        string expectedType = "passport";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBackDocumentSignedUrl, model.BackDocumentSignedUrl);
        Assert.Equal(expectedBirthPlace, model.BirthPlace);
        Assert.Equal(expectedBirthday, model.Birthday);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedEntitlementDate, model.EntitlementDate);
        Assert.Equal(expectedExpirationDate, model.ExpirationDate);
        Assert.Equal(expectedFirstName, model.FirstName);
        Assert.Equal(expectedFrontDocumentSignedUrl, model.FrontDocumentSignedUrl);
        Assert.Equal(expectedGender, model.Gender);
        Assert.Equal(expectedIssueDate, model.IssueDate);
        Assert.Equal(expectedLastName, model.LastName);
        Assert.Equal(expectedMrzLine1, model.MrzLine1);
        Assert.Equal(expectedMrzLine2, model.MrzLine2);
        Assert.Null(model.MrzLine3);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IdentityCard
        {
            ID = "doc_001",
            BackDocumentSignedUrl = "https://cdn.example.com/back.jpg",
            BirthPlace = "Paris",
            Birthday = "01/01/1990",
            Country = "FR",
            EntitlementDate = "entitlement_date",
            ExpirationDate = "2030-01-01",
            FirstName = "John",
            FrontDocumentSignedUrl = "https://cdn.example.com/front.jpg",
            Gender = "M",
            IssueDate = "2020-01-01",
            LastName = "Doe",
            MrzLine1 = "P<FRADOE<<JOHN<<<<<<<<<<<<<<<<<<<",
            MrzLine2 = "1234567890FRA9001019M2301012<<<<<<<<<<<<<<04",
            MrzLine3 = null,
            Type = "passport",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<IdentityCard>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IdentityCard
        {
            ID = "doc_001",
            BackDocumentSignedUrl = "https://cdn.example.com/back.jpg",
            BirthPlace = "Paris",
            Birthday = "01/01/1990",
            Country = "FR",
            EntitlementDate = "entitlement_date",
            ExpirationDate = "2030-01-01",
            FirstName = "John",
            FrontDocumentSignedUrl = "https://cdn.example.com/front.jpg",
            Gender = "M",
            IssueDate = "2020-01-01",
            LastName = "Doe",
            MrzLine1 = "P<FRADOE<<JOHN<<<<<<<<<<<<<<<<<<<",
            MrzLine2 = "1234567890FRA9001019M2301012<<<<<<<<<<<<<<04",
            MrzLine3 = null,
            Type = "passport",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<IdentityCard>(element);
        Assert.NotNull(deserialized);

        string expectedID = "doc_001";
        string expectedBackDocumentSignedUrl = "https://cdn.example.com/back.jpg";
        string expectedBirthPlace = "Paris";
        string expectedBirthday = "01/01/1990";
        string expectedCountry = "FR";
        string expectedEntitlementDate = "entitlement_date";
        string expectedExpirationDate = "2030-01-01";
        string expectedFirstName = "John";
        string expectedFrontDocumentSignedUrl = "https://cdn.example.com/front.jpg";
        string expectedGender = "M";
        string expectedIssueDate = "2020-01-01";
        string expectedLastName = "Doe";
        string expectedMrzLine1 = "P<FRADOE<<JOHN<<<<<<<<<<<<<<<<<<<";
        string expectedMrzLine2 = "1234567890FRA9001019M2301012<<<<<<<<<<<<<<04";
        string expectedType = "passport";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBackDocumentSignedUrl, deserialized.BackDocumentSignedUrl);
        Assert.Equal(expectedBirthPlace, deserialized.BirthPlace);
        Assert.Equal(expectedBirthday, deserialized.Birthday);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedEntitlementDate, deserialized.EntitlementDate);
        Assert.Equal(expectedExpirationDate, deserialized.ExpirationDate);
        Assert.Equal(expectedFirstName, deserialized.FirstName);
        Assert.Equal(expectedFrontDocumentSignedUrl, deserialized.FrontDocumentSignedUrl);
        Assert.Equal(expectedGender, deserialized.Gender);
        Assert.Equal(expectedIssueDate, deserialized.IssueDate);
        Assert.Equal(expectedLastName, deserialized.LastName);
        Assert.Equal(expectedMrzLine1, deserialized.MrzLine1);
        Assert.Equal(expectedMrzLine2, deserialized.MrzLine2);
        Assert.Null(deserialized.MrzLine3);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IdentityCard
        {
            ID = "doc_001",
            BackDocumentSignedUrl = "https://cdn.example.com/back.jpg",
            BirthPlace = "Paris",
            Birthday = "01/01/1990",
            Country = "FR",
            EntitlementDate = "entitlement_date",
            ExpirationDate = "2030-01-01",
            FirstName = "John",
            FrontDocumentSignedUrl = "https://cdn.example.com/front.jpg",
            Gender = "M",
            IssueDate = "2020-01-01",
            LastName = "Doe",
            MrzLine1 = "P<FRADOE<<JOHN<<<<<<<<<<<<<<<<<<<",
            MrzLine2 = "1234567890FRA9001019M2301012<<<<<<<<<<<<<<04",
            MrzLine3 = null,
            Type = "passport",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new IdentityCard { MrzLine3 = null };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.BackDocumentSignedUrl);
        Assert.False(model.RawData.ContainsKey("back_document_signed_url"));
        Assert.Null(model.BirthPlace);
        Assert.False(model.RawData.ContainsKey("birth_place"));
        Assert.Null(model.Birthday);
        Assert.False(model.RawData.ContainsKey("birthday"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.EntitlementDate);
        Assert.False(model.RawData.ContainsKey("entitlement_date"));
        Assert.Null(model.ExpirationDate);
        Assert.False(model.RawData.ContainsKey("expiration_date"));
        Assert.Null(model.FirstName);
        Assert.False(model.RawData.ContainsKey("first_name"));
        Assert.Null(model.FrontDocumentSignedUrl);
        Assert.False(model.RawData.ContainsKey("front_document_signed_url"));
        Assert.Null(model.Gender);
        Assert.False(model.RawData.ContainsKey("gender"));
        Assert.Null(model.IssueDate);
        Assert.False(model.RawData.ContainsKey("issue_date"));
        Assert.Null(model.LastName);
        Assert.False(model.RawData.ContainsKey("last_name"));
        Assert.Null(model.MrzLine1);
        Assert.False(model.RawData.ContainsKey("mrz_line_1"));
        Assert.Null(model.MrzLine2);
        Assert.False(model.RawData.ContainsKey("mrz_line_2"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new IdentityCard { MrzLine3 = null };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new IdentityCard
        {
            MrzLine3 = null,

            // Null should be interpreted as omitted for these properties
            ID = null,
            BackDocumentSignedUrl = null,
            BirthPlace = null,
            Birthday = null,
            Country = null,
            EntitlementDate = null,
            ExpirationDate = null,
            FirstName = null,
            FrontDocumentSignedUrl = null,
            Gender = null,
            IssueDate = null,
            LastName = null,
            MrzLine1 = null,
            MrzLine2 = null,
            Type = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.BackDocumentSignedUrl);
        Assert.False(model.RawData.ContainsKey("back_document_signed_url"));
        Assert.Null(model.BirthPlace);
        Assert.False(model.RawData.ContainsKey("birth_place"));
        Assert.Null(model.Birthday);
        Assert.False(model.RawData.ContainsKey("birthday"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.EntitlementDate);
        Assert.False(model.RawData.ContainsKey("entitlement_date"));
        Assert.Null(model.ExpirationDate);
        Assert.False(model.RawData.ContainsKey("expiration_date"));
        Assert.Null(model.FirstName);
        Assert.False(model.RawData.ContainsKey("first_name"));
        Assert.Null(model.FrontDocumentSignedUrl);
        Assert.False(model.RawData.ContainsKey("front_document_signed_url"));
        Assert.Null(model.Gender);
        Assert.False(model.RawData.ContainsKey("gender"));
        Assert.Null(model.IssueDate);
        Assert.False(model.RawData.ContainsKey("issue_date"));
        Assert.Null(model.LastName);
        Assert.False(model.RawData.ContainsKey("last_name"));
        Assert.Null(model.MrzLine1);
        Assert.False(model.RawData.ContainsKey("mrz_line_1"));
        Assert.Null(model.MrzLine2);
        Assert.False(model.RawData.ContainsKey("mrz_line_2"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new IdentityCard
        {
            MrzLine3 = null,

            // Null should be interpreted as omitted for these properties
            ID = null,
            BackDocumentSignedUrl = null,
            BirthPlace = null,
            Birthday = null,
            Country = null,
            EntitlementDate = null,
            ExpirationDate = null,
            FirstName = null,
            FrontDocumentSignedUrl = null,
            Gender = null,
            IssueDate = null,
            LastName = null,
            MrzLine1 = null,
            MrzLine2 = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new IdentityCard
        {
            ID = "doc_001",
            BackDocumentSignedUrl = "https://cdn.example.com/back.jpg",
            BirthPlace = "Paris",
            Birthday = "01/01/1990",
            Country = "FR",
            EntitlementDate = "entitlement_date",
            ExpirationDate = "2030-01-01",
            FirstName = "John",
            FrontDocumentSignedUrl = "https://cdn.example.com/front.jpg",
            Gender = "M",
            IssueDate = "2020-01-01",
            LastName = "Doe",
            MrzLine1 = "P<FRADOE<<JOHN<<<<<<<<<<<<<<<<<<<",
            MrzLine2 = "1234567890FRA9001019M2301012<<<<<<<<<<<<<<04",
            Type = "passport",
        };

        Assert.Null(model.MrzLine3);
        Assert.False(model.RawData.ContainsKey("mrz_line_3"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new IdentityCard
        {
            ID = "doc_001",
            BackDocumentSignedUrl = "https://cdn.example.com/back.jpg",
            BirthPlace = "Paris",
            Birthday = "01/01/1990",
            Country = "FR",
            EntitlementDate = "entitlement_date",
            ExpirationDate = "2030-01-01",
            FirstName = "John",
            FrontDocumentSignedUrl = "https://cdn.example.com/front.jpg",
            Gender = "M",
            IssueDate = "2020-01-01",
            LastName = "Doe",
            MrzLine1 = "P<FRADOE<<JOHN<<<<<<<<<<<<<<<<<<<",
            MrzLine2 = "1234567890FRA9001019M2301012<<<<<<<<<<<<<<04",
            Type = "passport",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new IdentityCard
        {
            ID = "doc_001",
            BackDocumentSignedUrl = "https://cdn.example.com/back.jpg",
            BirthPlace = "Paris",
            Birthday = "01/01/1990",
            Country = "FR",
            EntitlementDate = "entitlement_date",
            ExpirationDate = "2030-01-01",
            FirstName = "John",
            FrontDocumentSignedUrl = "https://cdn.example.com/front.jpg",
            Gender = "M",
            IssueDate = "2020-01-01",
            LastName = "Doe",
            MrzLine1 = "P<FRADOE<<JOHN<<<<<<<<<<<<<<<<<<<",
            MrzLine2 = "1234567890FRA9001019M2301012<<<<<<<<<<<<<<04",
            Type = "passport",

            MrzLine3 = null,
        };

        Assert.Null(model.MrzLine3);
        Assert.True(model.RawData.ContainsKey("mrz_line_3"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new IdentityCard
        {
            ID = "doc_001",
            BackDocumentSignedUrl = "https://cdn.example.com/back.jpg",
            BirthPlace = "Paris",
            Birthday = "01/01/1990",
            Country = "FR",
            EntitlementDate = "entitlement_date",
            ExpirationDate = "2030-01-01",
            FirstName = "John",
            FrontDocumentSignedUrl = "https://cdn.example.com/front.jpg",
            Gender = "M",
            IssueDate = "2020-01-01",
            LastName = "Doe",
            MrzLine1 = "P<FRADOE<<JOHN<<<<<<<<<<<<<<<<<<<",
            MrzLine2 = "1234567890FRA9001019M2301012<<<<<<<<<<<<<<04",
            Type = "passport",

            MrzLine3 = null,
        };

        model.Validate();
    }
}

public class IndividualPersonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IndividualPerson
        {
            Birthday = "01/01/1990",
            Email = "john.doe@example.com",
            FaceImageSignedUrl = "https://cdn.example.com/face.jpg",
            FirstName = "John",
            FullName = "John Doe",
            Gender = "M",
            LastName = "Doe",
            MaidenName = "Smith",
            Nationality = "FRA",
            PhoneNumber = "+33612345678",
        };

        string expectedBirthday = "01/01/1990";
        string expectedEmail = "john.doe@example.com";
        string expectedFaceImageSignedUrl = "https://cdn.example.com/face.jpg";
        string expectedFirstName = "John";
        string expectedFullName = "John Doe";
        string expectedGender = "M";
        string expectedLastName = "Doe";
        string expectedMaidenName = "Smith";
        string expectedNationality = "FRA";
        string expectedPhoneNumber = "+33612345678";

        Assert.Equal(expectedBirthday, model.Birthday);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedFaceImageSignedUrl, model.FaceImageSignedUrl);
        Assert.Equal(expectedFirstName, model.FirstName);
        Assert.Equal(expectedFullName, model.FullName);
        Assert.Equal(expectedGender, model.Gender);
        Assert.Equal(expectedLastName, model.LastName);
        Assert.Equal(expectedMaidenName, model.MaidenName);
        Assert.Equal(expectedNationality, model.Nationality);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IndividualPerson
        {
            Birthday = "01/01/1990",
            Email = "john.doe@example.com",
            FaceImageSignedUrl = "https://cdn.example.com/face.jpg",
            FirstName = "John",
            FullName = "John Doe",
            Gender = "M",
            LastName = "Doe",
            MaidenName = "Smith",
            Nationality = "FRA",
            PhoneNumber = "+33612345678",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<IndividualPerson>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IndividualPerson
        {
            Birthday = "01/01/1990",
            Email = "john.doe@example.com",
            FaceImageSignedUrl = "https://cdn.example.com/face.jpg",
            FirstName = "John",
            FullName = "John Doe",
            Gender = "M",
            LastName = "Doe",
            MaidenName = "Smith",
            Nationality = "FRA",
            PhoneNumber = "+33612345678",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<IndividualPerson>(element);
        Assert.NotNull(deserialized);

        string expectedBirthday = "01/01/1990";
        string expectedEmail = "john.doe@example.com";
        string expectedFaceImageSignedUrl = "https://cdn.example.com/face.jpg";
        string expectedFirstName = "John";
        string expectedFullName = "John Doe";
        string expectedGender = "M";
        string expectedLastName = "Doe";
        string expectedMaidenName = "Smith";
        string expectedNationality = "FRA";
        string expectedPhoneNumber = "+33612345678";

        Assert.Equal(expectedBirthday, deserialized.Birthday);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedFaceImageSignedUrl, deserialized.FaceImageSignedUrl);
        Assert.Equal(expectedFirstName, deserialized.FirstName);
        Assert.Equal(expectedFullName, deserialized.FullName);
        Assert.Equal(expectedGender, deserialized.Gender);
        Assert.Equal(expectedLastName, deserialized.LastName);
        Assert.Equal(expectedMaidenName, deserialized.MaidenName);
        Assert.Equal(expectedNationality, deserialized.Nationality);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IndividualPerson
        {
            Birthday = "01/01/1990",
            Email = "john.doe@example.com",
            FaceImageSignedUrl = "https://cdn.example.com/face.jpg",
            FirstName = "John",
            FullName = "John Doe",
            Gender = "M",
            LastName = "Doe",
            MaidenName = "Smith",
            Nationality = "FRA",
            PhoneNumber = "+33612345678",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new IndividualPerson { };

        Assert.Null(model.Birthday);
        Assert.False(model.RawData.ContainsKey("birthday"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.FaceImageSignedUrl);
        Assert.False(model.RawData.ContainsKey("face_image_signed_url"));
        Assert.Null(model.FirstName);
        Assert.False(model.RawData.ContainsKey("first_name"));
        Assert.Null(model.FullName);
        Assert.False(model.RawData.ContainsKey("full_name"));
        Assert.Null(model.Gender);
        Assert.False(model.RawData.ContainsKey("gender"));
        Assert.Null(model.LastName);
        Assert.False(model.RawData.ContainsKey("last_name"));
        Assert.Null(model.MaidenName);
        Assert.False(model.RawData.ContainsKey("maiden_name"));
        Assert.Null(model.Nationality);
        Assert.False(model.RawData.ContainsKey("nationality"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new IndividualPerson { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new IndividualPerson
        {
            // Null should be interpreted as omitted for these properties
            Birthday = null,
            Email = null,
            FaceImageSignedUrl = null,
            FirstName = null,
            FullName = null,
            Gender = null,
            LastName = null,
            MaidenName = null,
            Nationality = null,
            PhoneNumber = null,
        };

        Assert.Null(model.Birthday);
        Assert.False(model.RawData.ContainsKey("birthday"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.FaceImageSignedUrl);
        Assert.False(model.RawData.ContainsKey("face_image_signed_url"));
        Assert.Null(model.FirstName);
        Assert.False(model.RawData.ContainsKey("first_name"));
        Assert.Null(model.FullName);
        Assert.False(model.RawData.ContainsKey("full_name"));
        Assert.Null(model.Gender);
        Assert.False(model.RawData.ContainsKey("gender"));
        Assert.Null(model.LastName);
        Assert.False(model.RawData.ContainsKey("last_name"));
        Assert.Null(model.MaidenName);
        Assert.False(model.RawData.ContainsKey("maiden_name"));
        Assert.Null(model.Nationality);
        Assert.False(model.RawData.ContainsKey("nationality"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new IndividualPerson
        {
            // Null should be interpreted as omitted for these properties
            Birthday = null,
            Email = null,
            FaceImageSignedUrl = null,
            FirstName = null,
            FullName = null,
            Gender = null,
            LastName = null,
            MaidenName = null,
            Nationality = null,
            PhoneNumber = null,
        };

        model.Validate();
    }
}

public class TagTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tag
        {
            Key = "tag_name",
            Private = false,
            Type = "string",
            Value = "tag_value",
        };

        string expectedKey = "tag_name";
        bool expectedPrivate = false;
        string expectedType = "string";
        string expectedValue = "tag_value";

        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedPrivate, model.Private);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Tag
        {
            Key = "tag_name",
            Private = false,
            Type = "string",
            Value = "tag_value",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Tag>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Tag
        {
            Key = "tag_name",
            Private = false,
            Type = "string",
            Value = "tag_value",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Tag>(element);
        Assert.NotNull(deserialized);

        string expectedKey = "tag_name";
        bool expectedPrivate = false;
        string expectedType = "string";
        string expectedValue = "tag_value";

        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedPrivate, deserialized.Private);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Tag
        {
            Key = "tag_name",
            Private = false,
            Type = "string",
            Value = "tag_value",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Tag { };

        Assert.Null(model.Key);
        Assert.False(model.RawData.ContainsKey("key"));
        Assert.Null(model.Private);
        Assert.False(model.RawData.ContainsKey("private"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Tag { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Tag
        {
            // Null should be interpreted as omitted for these properties
            Key = null,
            Private = null,
            Type = null,
            Value = null,
        };

        Assert.Null(model.Key);
        Assert.False(model.RawData.ContainsKey("key"));
        Assert.Null(model.Private);
        Assert.False(model.RawData.ContainsKey("private"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Tag
        {
            // Null should be interpreted as omitted for these properties
            Key = null,
            Private = null,
            Type = null,
            Value = null,
        };

        model.Validate();
    }
}
