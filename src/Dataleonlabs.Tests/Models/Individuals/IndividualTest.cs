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
                    Score = 0.85,
                    Source = "https://aml-checker.example.com/api/v1/suspicion/12345",
                    Status = Companies::AmlSuspicionStatus.Pending,
                    Type = Companies::Type.Pep,
                },
            ],
            AuthURL = "https://id.dataleon.ai/a/123",
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
                    Validate1 = true,
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
                            Validate1 = true,
                            Weight = 1,
                        },
                    ],
                    CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
                    DocumentType = "generic",
                    Name = "generic_doc",
                    SignedURL = "https://cdn.example.com/doc.pdf",
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
                            Value1 = [100, 200],
                        },
                    ],
                },
            ],
            IdentityCard = new()
            {
                ID = "doc_001",
                BackDocumentSignedURL = "https://cdn.example.com/back.jpg",
                BirthPlace = "Paris",
                Birthday = "01/01/1990",
                Country = "FR",
                ExpirationDate = "2030-01-01",
                FirstName = "John",
                FrontDocumentSignedURL = "https://cdn.example.com/front.jpg",
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
                FaceImageSignedURL = "https://cdn.example.com/face.jpg",
                FirstName = "John",
                FullName = "John Doe",
                Gender = "M",
                LastName = "Doe",
                MaidenName = "Smith",
                Nationality = "FRA",
                PhoneNumber = "+33612345678",
            },
            PortalURL = "https://portal.dataleon.ai/w/123",
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
                Score = 0.92,
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
                    Companies::PortalStep1.IdentityVerification,
                    Companies::PortalStep1.Selfie,
                    Companies::PortalStep1.FaceMatch,
                ],
                QrCode = "false",
                RawData1 = true,
                RejectedAt = null,
                SessionDuration = 45,
                StartedAt = DateTimeOffset.Parse("2025-05-05T13:00:00Z"),
                TransferAt = DateTimeOffset.Parse("2025-07-12T14:00:00Z"),
                TransferMode = "API",
            },
            WebviewURL = "https://id.dataleon.ai/w/123",
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
                Score = 0.85,
                Source = "https://aml-checker.example.com/api/v1/suspicion/12345",
                Status = Companies::AmlSuspicionStatus.Pending,
                Type = Companies::Type.Pep,
            },
        ];
        string expectedAuthURL = "https://id.dataleon.ai/a/123";
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
                Validate1 = true,
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
                        Validate1 = true,
                        Weight = 1,
                    },
                ],
                CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
                DocumentType = "generic",
                Name = "generic_doc",
                SignedURL = "https://cdn.example.com/doc.pdf",
                State = "SUBMITTED",
                Status = "approved",
                Tables = [new() { Operation = [JsonSerializer.Deserialize<JsonElement>("{}")] }],
                Values =
                [
                    new()
                    {
                        Confidence = 0.95,
                        Name = "Full Name",
                        Value1 = [100, 200],
                    },
                ],
            },
        ];
        IdentityCard expectedIdentityCard = new()
        {
            ID = "doc_001",
            BackDocumentSignedURL = "https://cdn.example.com/back.jpg",
            BirthPlace = "Paris",
            Birthday = "01/01/1990",
            Country = "FR",
            ExpirationDate = "2030-01-01",
            FirstName = "John",
            FrontDocumentSignedURL = "https://cdn.example.com/front.jpg",
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
            FaceImageSignedURL = "https://cdn.example.com/face.jpg",
            FirstName = "John",
            FullName = "John Doe",
            Gender = "M",
            LastName = "Doe",
            MaidenName = "Smith",
            Nationality = "FRA",
            PhoneNumber = "+33612345678",
        };
        string expectedPortalURL = "https://portal.dataleon.ai/w/123";
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
            Score = 0.92,
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
                Companies::PortalStep1.IdentityVerification,
                Companies::PortalStep1.Selfie,
                Companies::PortalStep1.FaceMatch,
            ],
            QrCode = "false",
            RawData1 = true,
            RejectedAt = null,
            SessionDuration = 45,
            StartedAt = DateTimeOffset.Parse("2025-05-05T13:00:00Z"),
            TransferAt = DateTimeOffset.Parse("2025-07-12T14:00:00Z"),
            TransferMode = "API",
        };
        string expectedWebviewURL = "https://id.dataleon.ai/w/123";
        string expectedWorkspaceID = "wk_123";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmlSuspicions.Count, model.AmlSuspicions.Count);
        for (int i = 0; i < expectedAmlSuspicions.Count; i++)
        {
            Assert.Equal(expectedAmlSuspicions[i], model.AmlSuspicions[i]);
        }
        Assert.Equal(expectedAuthURL, model.AuthURL);
        Assert.Equal(expectedCertificat, model.Certificat);
        Assert.Equal(expectedChecks.Count, model.Checks.Count);
        for (int i = 0; i < expectedChecks.Count; i++)
        {
            Assert.Equal(expectedChecks[i], model.Checks[i]);
        }
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDocuments.Count, model.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], model.Documents[i]);
        }
        Assert.Equal(expectedIdentityCard, model.IdentityCard);
        Assert.Equal(expectedNumber, model.Number);
        Assert.Equal(expectedPerson, model.Person);
        Assert.Equal(expectedPortalURL, model.PortalURL);
        Assert.Equal(expectedProperties.Count, model.Properties.Count);
        for (int i = 0; i < expectedProperties.Count; i++)
        {
            Assert.Equal(expectedProperties[i], model.Properties[i]);
        }
        Assert.Equal(expectedRisk, model.Risk);
        Assert.Equal(expectedSourceID, model.SourceID);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedTechnicalData, model.TechnicalData);
        Assert.Equal(expectedWebviewURL, model.WebviewURL);
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
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
            BackDocumentSignedURL = "https://cdn.example.com/back.jpg",
            BirthPlace = "Paris",
            Birthday = "01/01/1990",
            Country = "FR",
            ExpirationDate = "2030-01-01",
            FirstName = "John",
            FrontDocumentSignedURL = "https://cdn.example.com/front.jpg",
            Gender = "M",
            IssueDate = "2020-01-01",
            LastName = "Doe",
            MrzLine1 = "P<FRADOE<<JOHN<<<<<<<<<<<<<<<<<<<",
            MrzLine2 = "1234567890FRA9001019M2301012<<<<<<<<<<<<<<04",
            MrzLine3 = null,
            Type = "passport",
        };

        string expectedID = "doc_001";
        string expectedBackDocumentSignedURL = "https://cdn.example.com/back.jpg";
        string expectedBirthPlace = "Paris";
        string expectedBirthday = "01/01/1990";
        string expectedCountry = "FR";
        string expectedExpirationDate = "2030-01-01";
        string expectedFirstName = "John";
        string expectedFrontDocumentSignedURL = "https://cdn.example.com/front.jpg";
        string expectedGender = "M";
        string expectedIssueDate = "2020-01-01";
        string expectedLastName = "Doe";
        string expectedMrzLine1 = "P<FRADOE<<JOHN<<<<<<<<<<<<<<<<<<<";
        string expectedMrzLine2 = "1234567890FRA9001019M2301012<<<<<<<<<<<<<<04";
        string expectedMrzLine3 = null;
        string expectedType = "passport";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBackDocumentSignedURL, model.BackDocumentSignedURL);
        Assert.Equal(expectedBirthPlace, model.BirthPlace);
        Assert.Equal(expectedBirthday, model.Birthday);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedExpirationDate, model.ExpirationDate);
        Assert.Equal(expectedFirstName, model.FirstName);
        Assert.Equal(expectedFrontDocumentSignedURL, model.FrontDocumentSignedURL);
        Assert.Equal(expectedGender, model.Gender);
        Assert.Equal(expectedIssueDate, model.IssueDate);
        Assert.Equal(expectedLastName, model.LastName);
        Assert.Equal(expectedMrzLine1, model.MrzLine1);
        Assert.Equal(expectedMrzLine2, model.MrzLine2);
        Assert.Equal(expectedMrzLine3, model.MrzLine3);
        Assert.Equal(expectedType, model.Type);
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
            FaceImageSignedURL = "https://cdn.example.com/face.jpg",
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
        string expectedFaceImageSignedURL = "https://cdn.example.com/face.jpg";
        string expectedFirstName = "John";
        string expectedFullName = "John Doe";
        string expectedGender = "M";
        string expectedLastName = "Doe";
        string expectedMaidenName = "Smith";
        string expectedNationality = "FRA";
        string expectedPhoneNumber = "+33612345678";

        Assert.Equal(expectedBirthday, model.Birthday);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedFaceImageSignedURL, model.FaceImageSignedURL);
        Assert.Equal(expectedFirstName, model.FirstName);
        Assert.Equal(expectedFullName, model.FullName);
        Assert.Equal(expectedGender, model.Gender);
        Assert.Equal(expectedLastName, model.LastName);
        Assert.Equal(expectedMaidenName, model.MaidenName);
        Assert.Equal(expectedNationality, model.Nationality);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
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
}
