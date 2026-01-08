using System;
using System.Collections.Generic;
using System.Text.Json;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;
using Dataleonlabs.Models.Companies.Documents;
using Companies = Dataleonlabs.Models.Companies;

namespace Dataleonlabs.Tests.Models.Companies;

public class CompanyCompanyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Companies::CompanyCompany
        {
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
            Company = new()
            {
                Address = "123 Rue de Paris, 75001 Paris, France",
                ClosureDate = "2025-12-31",
                CommercialName = "ACME",
                Contact = new()
                {
                    Department = "Finance",
                    Email = "alice.martin@example.com",
                    FirstName = "Alice",
                    LastName = "Martin",
                    PhoneNumber = "+33 1 23 45 67 89",
                },
                Country = "FR",
                Email = "contact@acme.com",
                Employees = 42,
                EmployerIdentificationNumber = "EIN987654321",
                InsolvencyExists = false,
                InsolvencyOngoing = false,
                LegalForm = "LLC",
                Name = "ACME Corp",
                PhoneNumber = "+33 1 23 45 67 89",
                RegistrationDate = "2010-05-20",
                RegistrationID = "123456789",
                ShareCapital = "100000 EUR",
                Status = "active",
                TaxIdentificationNumber = "FR123456789",
                Type = "main",
                WebsiteUrl = "https://www.acme.com",
            },
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
            Members =
            [
                new()
                {
                    ID = "123e4567-e89b-12d3-a456-426614174000",
                    Address = "456 Avenue de Lyon, 69000 Lyon, France",
                    Birthday = DateTimeOffset.Parse("1980-06-15T00:00:00.000000+00:00"),
                    Birthplace = "Paris",
                    Country = "FR",
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
                                new()
                                {
                                    Operation = [JsonSerializer.Deserialize<JsonElement>("{}")],
                                },
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
                    Email = "john.doe@example.com",
                    FirstName = "John",
                    IsBeneficialOwner = true,
                    IsDelegator = false,
                    LastName = "Doe",
                    LivenessVerification = true,
                    Name = "ACME Corp",
                    OwnershipPercentage = 50,
                    PhoneNumber = "+33 1 23 45 67 89",
                    PostalCode = "69000",
                    RegistrationID = "987654321",
                    Relation = "shareholder",
                    Roles = "legal_representative",
                    Source = Companies::Source.User,
                    State = "PROCESSED",
                    Status = "approved",
                    Type = Companies::MemberType.Person,
                    WorkspaceID = "wk_123",
                },
            ],
            PortalUrl = "https://portal.dataleon.ai/e/123",
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
            SourceID = "src-001",
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
            WebviewUrl = "https://id.dataleon.ai/e/123",
        };

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
        Companies::CompanyCompanyCompany expectedCompany = new()
        {
            Address = "123 Rue de Paris, 75001 Paris, France",
            ClosureDate = "2025-12-31",
            CommercialName = "ACME",
            Contact = new()
            {
                Department = "Finance",
                Email = "alice.martin@example.com",
                FirstName = "Alice",
                LastName = "Martin",
                PhoneNumber = "+33 1 23 45 67 89",
            },
            Country = "FR",
            Email = "contact@acme.com",
            Employees = 42,
            EmployerIdentificationNumber = "EIN987654321",
            InsolvencyExists = false,
            InsolvencyOngoing = false,
            LegalForm = "LLC",
            Name = "ACME Corp",
            PhoneNumber = "+33 1 23 45 67 89",
            RegistrationDate = "2010-05-20",
            RegistrationID = "123456789",
            ShareCapital = "100000 EUR",
            Status = "active",
            TaxIdentificationNumber = "FR123456789",
            Type = "main",
            WebsiteUrl = "https://www.acme.com",
        };
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
        List<Companies::Member> expectedMembers =
        [
            new()
            {
                ID = "123e4567-e89b-12d3-a456-426614174000",
                Address = "456 Avenue de Lyon, 69000 Lyon, France",
                Birthday = DateTimeOffset.Parse("1980-06-15T00:00:00.000000+00:00"),
                Birthplace = "Paris",
                Country = "FR",
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
                Email = "john.doe@example.com",
                FirstName = "John",
                IsBeneficialOwner = true,
                IsDelegator = false,
                LastName = "Doe",
                LivenessVerification = true,
                Name = "ACME Corp",
                OwnershipPercentage = 50,
                PhoneNumber = "+33 1 23 45 67 89",
                PostalCode = "69000",
                RegistrationID = "987654321",
                Relation = "shareholder",
                Roles = "legal_representative",
                Source = Companies::Source.User,
                State = "PROCESSED",
                Status = "approved",
                Type = Companies::MemberType.Person,
                WorkspaceID = "wk_123",
            },
        ];
        string expectedPortalUrl = "https://portal.dataleon.ai/e/123";
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
        string expectedSourceID = "src-001";
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
        string expectedWebviewUrl = "https://id.dataleon.ai/e/123";

        Assert.NotNull(model.AmlSuspicions);
        Assert.Equal(expectedAmlSuspicions.Count, model.AmlSuspicions.Count);
        for (int i = 0; i < expectedAmlSuspicions.Count; i++)
        {
            Assert.Equal(expectedAmlSuspicions[i], model.AmlSuspicions[i]);
        }
        Assert.Equal(expectedCertificat, model.Certificat);
        Assert.NotNull(model.Checks);
        Assert.Equal(expectedChecks.Count, model.Checks.Count);
        for (int i = 0; i < expectedChecks.Count; i++)
        {
            Assert.Equal(expectedChecks[i], model.Checks[i]);
        }
        Assert.Equal(expectedCompany, model.Company);
        Assert.NotNull(model.Documents);
        Assert.Equal(expectedDocuments.Count, model.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], model.Documents[i]);
        }
        Assert.NotNull(model.Members);
        Assert.Equal(expectedMembers.Count, model.Members.Count);
        for (int i = 0; i < expectedMembers.Count; i++)
        {
            Assert.Equal(expectedMembers[i], model.Members[i]);
        }
        Assert.Equal(expectedPortalUrl, model.PortalUrl);
        Assert.NotNull(model.Properties);
        Assert.Equal(expectedProperties.Count, model.Properties.Count);
        for (int i = 0; i < expectedProperties.Count; i++)
        {
            Assert.Equal(expectedProperties[i], model.Properties[i]);
        }
        Assert.Equal(expectedRisk, model.Risk);
        Assert.Equal(expectedSourceID, model.SourceID);
        Assert.Equal(expectedTechnicalData, model.TechnicalData);
        Assert.Equal(expectedWebviewUrl, model.WebviewUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Companies::CompanyCompany
        {
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
            Company = new()
            {
                Address = "123 Rue de Paris, 75001 Paris, France",
                ClosureDate = "2025-12-31",
                CommercialName = "ACME",
                Contact = new()
                {
                    Department = "Finance",
                    Email = "alice.martin@example.com",
                    FirstName = "Alice",
                    LastName = "Martin",
                    PhoneNumber = "+33 1 23 45 67 89",
                },
                Country = "FR",
                Email = "contact@acme.com",
                Employees = 42,
                EmployerIdentificationNumber = "EIN987654321",
                InsolvencyExists = false,
                InsolvencyOngoing = false,
                LegalForm = "LLC",
                Name = "ACME Corp",
                PhoneNumber = "+33 1 23 45 67 89",
                RegistrationDate = "2010-05-20",
                RegistrationID = "123456789",
                ShareCapital = "100000 EUR",
                Status = "active",
                TaxIdentificationNumber = "FR123456789",
                Type = "main",
                WebsiteUrl = "https://www.acme.com",
            },
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
            Members =
            [
                new()
                {
                    ID = "123e4567-e89b-12d3-a456-426614174000",
                    Address = "456 Avenue de Lyon, 69000 Lyon, France",
                    Birthday = DateTimeOffset.Parse("1980-06-15T00:00:00.000000+00:00"),
                    Birthplace = "Paris",
                    Country = "FR",
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
                                new()
                                {
                                    Operation = [JsonSerializer.Deserialize<JsonElement>("{}")],
                                },
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
                    Email = "john.doe@example.com",
                    FirstName = "John",
                    IsBeneficialOwner = true,
                    IsDelegator = false,
                    LastName = "Doe",
                    LivenessVerification = true,
                    Name = "ACME Corp",
                    OwnershipPercentage = 50,
                    PhoneNumber = "+33 1 23 45 67 89",
                    PostalCode = "69000",
                    RegistrationID = "987654321",
                    Relation = "shareholder",
                    Roles = "legal_representative",
                    Source = Companies::Source.User,
                    State = "PROCESSED",
                    Status = "approved",
                    Type = Companies::MemberType.Person,
                    WorkspaceID = "wk_123",
                },
            ],
            PortalUrl = "https://portal.dataleon.ai/e/123",
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
            SourceID = "src-001",
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
            WebviewUrl = "https://id.dataleon.ai/e/123",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Companies::CompanyCompany>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Companies::CompanyCompany
        {
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
            Company = new()
            {
                Address = "123 Rue de Paris, 75001 Paris, France",
                ClosureDate = "2025-12-31",
                CommercialName = "ACME",
                Contact = new()
                {
                    Department = "Finance",
                    Email = "alice.martin@example.com",
                    FirstName = "Alice",
                    LastName = "Martin",
                    PhoneNumber = "+33 1 23 45 67 89",
                },
                Country = "FR",
                Email = "contact@acme.com",
                Employees = 42,
                EmployerIdentificationNumber = "EIN987654321",
                InsolvencyExists = false,
                InsolvencyOngoing = false,
                LegalForm = "LLC",
                Name = "ACME Corp",
                PhoneNumber = "+33 1 23 45 67 89",
                RegistrationDate = "2010-05-20",
                RegistrationID = "123456789",
                ShareCapital = "100000 EUR",
                Status = "active",
                TaxIdentificationNumber = "FR123456789",
                Type = "main",
                WebsiteUrl = "https://www.acme.com",
            },
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
            Members =
            [
                new()
                {
                    ID = "123e4567-e89b-12d3-a456-426614174000",
                    Address = "456 Avenue de Lyon, 69000 Lyon, France",
                    Birthday = DateTimeOffset.Parse("1980-06-15T00:00:00.000000+00:00"),
                    Birthplace = "Paris",
                    Country = "FR",
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
                                new()
                                {
                                    Operation = [JsonSerializer.Deserialize<JsonElement>("{}")],
                                },
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
                    Email = "john.doe@example.com",
                    FirstName = "John",
                    IsBeneficialOwner = true,
                    IsDelegator = false,
                    LastName = "Doe",
                    LivenessVerification = true,
                    Name = "ACME Corp",
                    OwnershipPercentage = 50,
                    PhoneNumber = "+33 1 23 45 67 89",
                    PostalCode = "69000",
                    RegistrationID = "987654321",
                    Relation = "shareholder",
                    Roles = "legal_representative",
                    Source = Companies::Source.User,
                    State = "PROCESSED",
                    Status = "approved",
                    Type = Companies::MemberType.Person,
                    WorkspaceID = "wk_123",
                },
            ],
            PortalUrl = "https://portal.dataleon.ai/e/123",
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
            SourceID = "src-001",
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
            WebviewUrl = "https://id.dataleon.ai/e/123",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Companies::CompanyCompany>(element);
        Assert.NotNull(deserialized);

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
        Companies::CompanyCompanyCompany expectedCompany = new()
        {
            Address = "123 Rue de Paris, 75001 Paris, France",
            ClosureDate = "2025-12-31",
            CommercialName = "ACME",
            Contact = new()
            {
                Department = "Finance",
                Email = "alice.martin@example.com",
                FirstName = "Alice",
                LastName = "Martin",
                PhoneNumber = "+33 1 23 45 67 89",
            },
            Country = "FR",
            Email = "contact@acme.com",
            Employees = 42,
            EmployerIdentificationNumber = "EIN987654321",
            InsolvencyExists = false,
            InsolvencyOngoing = false,
            LegalForm = "LLC",
            Name = "ACME Corp",
            PhoneNumber = "+33 1 23 45 67 89",
            RegistrationDate = "2010-05-20",
            RegistrationID = "123456789",
            ShareCapital = "100000 EUR",
            Status = "active",
            TaxIdentificationNumber = "FR123456789",
            Type = "main",
            WebsiteUrl = "https://www.acme.com",
        };
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
        List<Companies::Member> expectedMembers =
        [
            new()
            {
                ID = "123e4567-e89b-12d3-a456-426614174000",
                Address = "456 Avenue de Lyon, 69000 Lyon, France",
                Birthday = DateTimeOffset.Parse("1980-06-15T00:00:00.000000+00:00"),
                Birthplace = "Paris",
                Country = "FR",
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
                Email = "john.doe@example.com",
                FirstName = "John",
                IsBeneficialOwner = true,
                IsDelegator = false,
                LastName = "Doe",
                LivenessVerification = true,
                Name = "ACME Corp",
                OwnershipPercentage = 50,
                PhoneNumber = "+33 1 23 45 67 89",
                PostalCode = "69000",
                RegistrationID = "987654321",
                Relation = "shareholder",
                Roles = "legal_representative",
                Source = Companies::Source.User,
                State = "PROCESSED",
                Status = "approved",
                Type = Companies::MemberType.Person,
                WorkspaceID = "wk_123",
            },
        ];
        string expectedPortalUrl = "https://portal.dataleon.ai/e/123";
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
        string expectedSourceID = "src-001";
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
        string expectedWebviewUrl = "https://id.dataleon.ai/e/123";

        Assert.NotNull(deserialized.AmlSuspicions);
        Assert.Equal(expectedAmlSuspicions.Count, deserialized.AmlSuspicions.Count);
        for (int i = 0; i < expectedAmlSuspicions.Count; i++)
        {
            Assert.Equal(expectedAmlSuspicions[i], deserialized.AmlSuspicions[i]);
        }
        Assert.Equal(expectedCertificat, deserialized.Certificat);
        Assert.NotNull(deserialized.Checks);
        Assert.Equal(expectedChecks.Count, deserialized.Checks.Count);
        for (int i = 0; i < expectedChecks.Count; i++)
        {
            Assert.Equal(expectedChecks[i], deserialized.Checks[i]);
        }
        Assert.Equal(expectedCompany, deserialized.Company);
        Assert.NotNull(deserialized.Documents);
        Assert.Equal(expectedDocuments.Count, deserialized.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], deserialized.Documents[i]);
        }
        Assert.NotNull(deserialized.Members);
        Assert.Equal(expectedMembers.Count, deserialized.Members.Count);
        for (int i = 0; i < expectedMembers.Count; i++)
        {
            Assert.Equal(expectedMembers[i], deserialized.Members[i]);
        }
        Assert.Equal(expectedPortalUrl, deserialized.PortalUrl);
        Assert.NotNull(deserialized.Properties);
        Assert.Equal(expectedProperties.Count, deserialized.Properties.Count);
        for (int i = 0; i < expectedProperties.Count; i++)
        {
            Assert.Equal(expectedProperties[i], deserialized.Properties[i]);
        }
        Assert.Equal(expectedRisk, deserialized.Risk);
        Assert.Equal(expectedSourceID, deserialized.SourceID);
        Assert.Equal(expectedTechnicalData, deserialized.TechnicalData);
        Assert.Equal(expectedWebviewUrl, deserialized.WebviewUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Companies::CompanyCompany
        {
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
            Company = new()
            {
                Address = "123 Rue de Paris, 75001 Paris, France",
                ClosureDate = "2025-12-31",
                CommercialName = "ACME",
                Contact = new()
                {
                    Department = "Finance",
                    Email = "alice.martin@example.com",
                    FirstName = "Alice",
                    LastName = "Martin",
                    PhoneNumber = "+33 1 23 45 67 89",
                },
                Country = "FR",
                Email = "contact@acme.com",
                Employees = 42,
                EmployerIdentificationNumber = "EIN987654321",
                InsolvencyExists = false,
                InsolvencyOngoing = false,
                LegalForm = "LLC",
                Name = "ACME Corp",
                PhoneNumber = "+33 1 23 45 67 89",
                RegistrationDate = "2010-05-20",
                RegistrationID = "123456789",
                ShareCapital = "100000 EUR",
                Status = "active",
                TaxIdentificationNumber = "FR123456789",
                Type = "main",
                WebsiteUrl = "https://www.acme.com",
            },
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
            Members =
            [
                new()
                {
                    ID = "123e4567-e89b-12d3-a456-426614174000",
                    Address = "456 Avenue de Lyon, 69000 Lyon, France",
                    Birthday = DateTimeOffset.Parse("1980-06-15T00:00:00.000000+00:00"),
                    Birthplace = "Paris",
                    Country = "FR",
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
                                new()
                                {
                                    Operation = [JsonSerializer.Deserialize<JsonElement>("{}")],
                                },
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
                    Email = "john.doe@example.com",
                    FirstName = "John",
                    IsBeneficialOwner = true,
                    IsDelegator = false,
                    LastName = "Doe",
                    LivenessVerification = true,
                    Name = "ACME Corp",
                    OwnershipPercentage = 50,
                    PhoneNumber = "+33 1 23 45 67 89",
                    PostalCode = "69000",
                    RegistrationID = "987654321",
                    Relation = "shareholder",
                    Roles = "legal_representative",
                    Source = Companies::Source.User,
                    State = "PROCESSED",
                    Status = "approved",
                    Type = Companies::MemberType.Person,
                    WorkspaceID = "wk_123",
                },
            ],
            PortalUrl = "https://portal.dataleon.ai/e/123",
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
            SourceID = "src-001",
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
            WebviewUrl = "https://id.dataleon.ai/e/123",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Companies::CompanyCompany { };

        Assert.Null(model.AmlSuspicions);
        Assert.False(model.RawData.ContainsKey("aml_suspicions"));
        Assert.Null(model.Certificat);
        Assert.False(model.RawData.ContainsKey("certificat"));
        Assert.Null(model.Checks);
        Assert.False(model.RawData.ContainsKey("checks"));
        Assert.Null(model.Company);
        Assert.False(model.RawData.ContainsKey("company"));
        Assert.Null(model.Documents);
        Assert.False(model.RawData.ContainsKey("documents"));
        Assert.Null(model.Members);
        Assert.False(model.RawData.ContainsKey("members"));
        Assert.Null(model.PortalUrl);
        Assert.False(model.RawData.ContainsKey("portal_url"));
        Assert.Null(model.Properties);
        Assert.False(model.RawData.ContainsKey("properties"));
        Assert.Null(model.Risk);
        Assert.False(model.RawData.ContainsKey("risk"));
        Assert.Null(model.SourceID);
        Assert.False(model.RawData.ContainsKey("source_id"));
        Assert.Null(model.TechnicalData);
        Assert.False(model.RawData.ContainsKey("technical_data"));
        Assert.Null(model.WebviewUrl);
        Assert.False(model.RawData.ContainsKey("webview_url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Companies::CompanyCompany { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Companies::CompanyCompany
        {
            // Null should be interpreted as omitted for these properties
            AmlSuspicions = null,
            Certificat = null,
            Checks = null,
            Company = null,
            Documents = null,
            Members = null,
            PortalUrl = null,
            Properties = null,
            Risk = null,
            SourceID = null,
            TechnicalData = null,
            WebviewUrl = null,
        };

        Assert.Null(model.AmlSuspicions);
        Assert.False(model.RawData.ContainsKey("aml_suspicions"));
        Assert.Null(model.Certificat);
        Assert.False(model.RawData.ContainsKey("certificat"));
        Assert.Null(model.Checks);
        Assert.False(model.RawData.ContainsKey("checks"));
        Assert.Null(model.Company);
        Assert.False(model.RawData.ContainsKey("company"));
        Assert.Null(model.Documents);
        Assert.False(model.RawData.ContainsKey("documents"));
        Assert.Null(model.Members);
        Assert.False(model.RawData.ContainsKey("members"));
        Assert.Null(model.PortalUrl);
        Assert.False(model.RawData.ContainsKey("portal_url"));
        Assert.Null(model.Properties);
        Assert.False(model.RawData.ContainsKey("properties"));
        Assert.Null(model.Risk);
        Assert.False(model.RawData.ContainsKey("risk"));
        Assert.Null(model.SourceID);
        Assert.False(model.RawData.ContainsKey("source_id"));
        Assert.Null(model.TechnicalData);
        Assert.False(model.RawData.ContainsKey("technical_data"));
        Assert.Null(model.WebviewUrl);
        Assert.False(model.RawData.ContainsKey("webview_url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Companies::CompanyCompany
        {
            // Null should be interpreted as omitted for these properties
            AmlSuspicions = null,
            Certificat = null,
            Checks = null,
            Company = null,
            Documents = null,
            Members = null,
            PortalUrl = null,
            Properties = null,
            Risk = null,
            SourceID = null,
            TechnicalData = null,
            WebviewUrl = null,
        };

        model.Validate();
    }
}

public class CompanyCompanyCompanyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Companies::CompanyCompanyCompany
        {
            Address = "123 Rue de Paris, 75001 Paris, France",
            ClosureDate = "2025-12-31",
            CommercialName = "ACME",
            Contact = new()
            {
                Department = "Finance",
                Email = "alice.martin@example.com",
                FirstName = "Alice",
                LastName = "Martin",
                PhoneNumber = "+33 1 23 45 67 89",
            },
            Country = "FR",
            Email = "contact@acme.com",
            Employees = 42,
            EmployerIdentificationNumber = "EIN987654321",
            InsolvencyExists = false,
            InsolvencyOngoing = false,
            LegalForm = "LLC",
            Name = "ACME Corp",
            PhoneNumber = "+33 1 23 45 67 89",
            RegistrationDate = "2010-05-20",
            RegistrationID = "123456789",
            ShareCapital = "100000 EUR",
            Status = "active",
            TaxIdentificationNumber = "FR123456789",
            Type = "main",
            WebsiteUrl = "https://www.acme.com",
        };

        string expectedAddress = "123 Rue de Paris, 75001 Paris, France";
        string expectedClosureDate = "2025-12-31";
        string expectedCommercialName = "ACME";
        Companies::Contact expectedContact = new()
        {
            Department = "Finance",
            Email = "alice.martin@example.com",
            FirstName = "Alice",
            LastName = "Martin",
            PhoneNumber = "+33 1 23 45 67 89",
        };
        string expectedCountry = "FR";
        string expectedEmail = "contact@acme.com";
        long expectedEmployees = 42;
        string expectedEmployerIdentificationNumber = "EIN987654321";
        bool expectedInsolvencyExists = false;
        bool expectedInsolvencyOngoing = false;
        string expectedLegalForm = "LLC";
        string expectedName = "ACME Corp";
        string expectedPhoneNumber = "+33 1 23 45 67 89";
        string expectedRegistrationDate = "2010-05-20";
        string expectedRegistrationID = "123456789";
        string expectedShareCapital = "100000 EUR";
        string expectedStatus = "active";
        string expectedTaxIdentificationNumber = "FR123456789";
        string expectedType = "main";
        string expectedWebsiteUrl = "https://www.acme.com";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedClosureDate, model.ClosureDate);
        Assert.Equal(expectedCommercialName, model.CommercialName);
        Assert.Equal(expectedContact, model.Contact);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedEmployees, model.Employees);
        Assert.Equal(expectedEmployerIdentificationNumber, model.EmployerIdentificationNumber);
        Assert.Equal(expectedInsolvencyExists, model.InsolvencyExists);
        Assert.Equal(expectedInsolvencyOngoing, model.InsolvencyOngoing);
        Assert.Equal(expectedLegalForm, model.LegalForm);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedRegistrationDate, model.RegistrationDate);
        Assert.Equal(expectedRegistrationID, model.RegistrationID);
        Assert.Equal(expectedShareCapital, model.ShareCapital);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTaxIdentificationNumber, model.TaxIdentificationNumber);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedWebsiteUrl, model.WebsiteUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Companies::CompanyCompanyCompany
        {
            Address = "123 Rue de Paris, 75001 Paris, France",
            ClosureDate = "2025-12-31",
            CommercialName = "ACME",
            Contact = new()
            {
                Department = "Finance",
                Email = "alice.martin@example.com",
                FirstName = "Alice",
                LastName = "Martin",
                PhoneNumber = "+33 1 23 45 67 89",
            },
            Country = "FR",
            Email = "contact@acme.com",
            Employees = 42,
            EmployerIdentificationNumber = "EIN987654321",
            InsolvencyExists = false,
            InsolvencyOngoing = false,
            LegalForm = "LLC",
            Name = "ACME Corp",
            PhoneNumber = "+33 1 23 45 67 89",
            RegistrationDate = "2010-05-20",
            RegistrationID = "123456789",
            ShareCapital = "100000 EUR",
            Status = "active",
            TaxIdentificationNumber = "FR123456789",
            Type = "main",
            WebsiteUrl = "https://www.acme.com",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Companies::CompanyCompanyCompany>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Companies::CompanyCompanyCompany
        {
            Address = "123 Rue de Paris, 75001 Paris, France",
            ClosureDate = "2025-12-31",
            CommercialName = "ACME",
            Contact = new()
            {
                Department = "Finance",
                Email = "alice.martin@example.com",
                FirstName = "Alice",
                LastName = "Martin",
                PhoneNumber = "+33 1 23 45 67 89",
            },
            Country = "FR",
            Email = "contact@acme.com",
            Employees = 42,
            EmployerIdentificationNumber = "EIN987654321",
            InsolvencyExists = false,
            InsolvencyOngoing = false,
            LegalForm = "LLC",
            Name = "ACME Corp",
            PhoneNumber = "+33 1 23 45 67 89",
            RegistrationDate = "2010-05-20",
            RegistrationID = "123456789",
            ShareCapital = "100000 EUR",
            Status = "active",
            TaxIdentificationNumber = "FR123456789",
            Type = "main",
            WebsiteUrl = "https://www.acme.com",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Companies::CompanyCompanyCompany>(element);
        Assert.NotNull(deserialized);

        string expectedAddress = "123 Rue de Paris, 75001 Paris, France";
        string expectedClosureDate = "2025-12-31";
        string expectedCommercialName = "ACME";
        Companies::Contact expectedContact = new()
        {
            Department = "Finance",
            Email = "alice.martin@example.com",
            FirstName = "Alice",
            LastName = "Martin",
            PhoneNumber = "+33 1 23 45 67 89",
        };
        string expectedCountry = "FR";
        string expectedEmail = "contact@acme.com";
        long expectedEmployees = 42;
        string expectedEmployerIdentificationNumber = "EIN987654321";
        bool expectedInsolvencyExists = false;
        bool expectedInsolvencyOngoing = false;
        string expectedLegalForm = "LLC";
        string expectedName = "ACME Corp";
        string expectedPhoneNumber = "+33 1 23 45 67 89";
        string expectedRegistrationDate = "2010-05-20";
        string expectedRegistrationID = "123456789";
        string expectedShareCapital = "100000 EUR";
        string expectedStatus = "active";
        string expectedTaxIdentificationNumber = "FR123456789";
        string expectedType = "main";
        string expectedWebsiteUrl = "https://www.acme.com";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedClosureDate, deserialized.ClosureDate);
        Assert.Equal(expectedCommercialName, deserialized.CommercialName);
        Assert.Equal(expectedContact, deserialized.Contact);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedEmployees, deserialized.Employees);
        Assert.Equal(
            expectedEmployerIdentificationNumber,
            deserialized.EmployerIdentificationNumber
        );
        Assert.Equal(expectedInsolvencyExists, deserialized.InsolvencyExists);
        Assert.Equal(expectedInsolvencyOngoing, deserialized.InsolvencyOngoing);
        Assert.Equal(expectedLegalForm, deserialized.LegalForm);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedRegistrationDate, deserialized.RegistrationDate);
        Assert.Equal(expectedRegistrationID, deserialized.RegistrationID);
        Assert.Equal(expectedShareCapital, deserialized.ShareCapital);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTaxIdentificationNumber, deserialized.TaxIdentificationNumber);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedWebsiteUrl, deserialized.WebsiteUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Companies::CompanyCompanyCompany
        {
            Address = "123 Rue de Paris, 75001 Paris, France",
            ClosureDate = "2025-12-31",
            CommercialName = "ACME",
            Contact = new()
            {
                Department = "Finance",
                Email = "alice.martin@example.com",
                FirstName = "Alice",
                LastName = "Martin",
                PhoneNumber = "+33 1 23 45 67 89",
            },
            Country = "FR",
            Email = "contact@acme.com",
            Employees = 42,
            EmployerIdentificationNumber = "EIN987654321",
            InsolvencyExists = false,
            InsolvencyOngoing = false,
            LegalForm = "LLC",
            Name = "ACME Corp",
            PhoneNumber = "+33 1 23 45 67 89",
            RegistrationDate = "2010-05-20",
            RegistrationID = "123456789",
            ShareCapital = "100000 EUR",
            Status = "active",
            TaxIdentificationNumber = "FR123456789",
            Type = "main",
            WebsiteUrl = "https://www.acme.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Companies::CompanyCompanyCompany { };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.ClosureDate);
        Assert.False(model.RawData.ContainsKey("closure_date"));
        Assert.Null(model.CommercialName);
        Assert.False(model.RawData.ContainsKey("commercial_name"));
        Assert.Null(model.Contact);
        Assert.False(model.RawData.ContainsKey("contact"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Employees);
        Assert.False(model.RawData.ContainsKey("employees"));
        Assert.Null(model.EmployerIdentificationNumber);
        Assert.False(model.RawData.ContainsKey("employer_identification_number"));
        Assert.Null(model.InsolvencyExists);
        Assert.False(model.RawData.ContainsKey("insolvency_exists"));
        Assert.Null(model.InsolvencyOngoing);
        Assert.False(model.RawData.ContainsKey("insolvency_ongoing"));
        Assert.Null(model.LegalForm);
        Assert.False(model.RawData.ContainsKey("legal_form"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
        Assert.Null(model.RegistrationDate);
        Assert.False(model.RawData.ContainsKey("registration_date"));
        Assert.Null(model.RegistrationID);
        Assert.False(model.RawData.ContainsKey("registration_id"));
        Assert.Null(model.ShareCapital);
        Assert.False(model.RawData.ContainsKey("share_capital"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.TaxIdentificationNumber);
        Assert.False(model.RawData.ContainsKey("tax_identification_number"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.WebsiteUrl);
        Assert.False(model.RawData.ContainsKey("website_url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Companies::CompanyCompanyCompany { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Companies::CompanyCompanyCompany
        {
            // Null should be interpreted as omitted for these properties
            Address = null,
            ClosureDate = null,
            CommercialName = null,
            Contact = null,
            Country = null,
            Email = null,
            Employees = null,
            EmployerIdentificationNumber = null,
            InsolvencyExists = null,
            InsolvencyOngoing = null,
            LegalForm = null,
            Name = null,
            PhoneNumber = null,
            RegistrationDate = null,
            RegistrationID = null,
            ShareCapital = null,
            Status = null,
            TaxIdentificationNumber = null,
            Type = null,
            WebsiteUrl = null,
        };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.ClosureDate);
        Assert.False(model.RawData.ContainsKey("closure_date"));
        Assert.Null(model.CommercialName);
        Assert.False(model.RawData.ContainsKey("commercial_name"));
        Assert.Null(model.Contact);
        Assert.False(model.RawData.ContainsKey("contact"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Employees);
        Assert.False(model.RawData.ContainsKey("employees"));
        Assert.Null(model.EmployerIdentificationNumber);
        Assert.False(model.RawData.ContainsKey("employer_identification_number"));
        Assert.Null(model.InsolvencyExists);
        Assert.False(model.RawData.ContainsKey("insolvency_exists"));
        Assert.Null(model.InsolvencyOngoing);
        Assert.False(model.RawData.ContainsKey("insolvency_ongoing"));
        Assert.Null(model.LegalForm);
        Assert.False(model.RawData.ContainsKey("legal_form"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
        Assert.Null(model.RegistrationDate);
        Assert.False(model.RawData.ContainsKey("registration_date"));
        Assert.Null(model.RegistrationID);
        Assert.False(model.RawData.ContainsKey("registration_id"));
        Assert.Null(model.ShareCapital);
        Assert.False(model.RawData.ContainsKey("share_capital"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.TaxIdentificationNumber);
        Assert.False(model.RawData.ContainsKey("tax_identification_number"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.WebsiteUrl);
        Assert.False(model.RawData.ContainsKey("website_url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Companies::CompanyCompanyCompany
        {
            // Null should be interpreted as omitted for these properties
            Address = null,
            ClosureDate = null,
            CommercialName = null,
            Contact = null,
            Country = null,
            Email = null,
            Employees = null,
            EmployerIdentificationNumber = null,
            InsolvencyExists = null,
            InsolvencyOngoing = null,
            LegalForm = null,
            Name = null,
            PhoneNumber = null,
            RegistrationDate = null,
            RegistrationID = null,
            ShareCapital = null,
            Status = null,
            TaxIdentificationNumber = null,
            Type = null,
            WebsiteUrl = null,
        };

        model.Validate();
    }
}

public class ContactTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Companies::Contact
        {
            Department = "Finance",
            Email = "alice.martin@example.com",
            FirstName = "Alice",
            LastName = "Martin",
            PhoneNumber = "+33 1 23 45 67 89",
        };

        string expectedDepartment = "Finance";
        string expectedEmail = "alice.martin@example.com";
        string expectedFirstName = "Alice";
        string expectedLastName = "Martin";
        string expectedPhoneNumber = "+33 1 23 45 67 89";

        Assert.Equal(expectedDepartment, model.Department);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedFirstName, model.FirstName);
        Assert.Equal(expectedLastName, model.LastName);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Companies::Contact
        {
            Department = "Finance",
            Email = "alice.martin@example.com",
            FirstName = "Alice",
            LastName = "Martin",
            PhoneNumber = "+33 1 23 45 67 89",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Companies::Contact>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Companies::Contact
        {
            Department = "Finance",
            Email = "alice.martin@example.com",
            FirstName = "Alice",
            LastName = "Martin",
            PhoneNumber = "+33 1 23 45 67 89",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Companies::Contact>(element);
        Assert.NotNull(deserialized);

        string expectedDepartment = "Finance";
        string expectedEmail = "alice.martin@example.com";
        string expectedFirstName = "Alice";
        string expectedLastName = "Martin";
        string expectedPhoneNumber = "+33 1 23 45 67 89";

        Assert.Equal(expectedDepartment, deserialized.Department);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedFirstName, deserialized.FirstName);
        Assert.Equal(expectedLastName, deserialized.LastName);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Companies::Contact
        {
            Department = "Finance",
            Email = "alice.martin@example.com",
            FirstName = "Alice",
            LastName = "Martin",
            PhoneNumber = "+33 1 23 45 67 89",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Companies::Contact { };

        Assert.Null(model.Department);
        Assert.False(model.RawData.ContainsKey("department"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.FirstName);
        Assert.False(model.RawData.ContainsKey("first_name"));
        Assert.Null(model.LastName);
        Assert.False(model.RawData.ContainsKey("last_name"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Companies::Contact { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Companies::Contact
        {
            // Null should be interpreted as omitted for these properties
            Department = null,
            Email = null,
            FirstName = null,
            LastName = null,
            PhoneNumber = null,
        };

        Assert.Null(model.Department);
        Assert.False(model.RawData.ContainsKey("department"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.FirstName);
        Assert.False(model.RawData.ContainsKey("first_name"));
        Assert.Null(model.LastName);
        Assert.False(model.RawData.ContainsKey("last_name"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Companies::Contact
        {
            // Null should be interpreted as omitted for these properties
            Department = null,
            Email = null,
            FirstName = null,
            LastName = null,
            PhoneNumber = null,
        };

        model.Validate();
    }
}

public class MemberTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Companies::Member
        {
            ID = "123e4567-e89b-12d3-a456-426614174000",
            Address = "456 Avenue de Lyon, 69000 Lyon, France",
            Birthday = DateTimeOffset.Parse("1980-06-15T00:00:00.000000+00:00"),
            Birthplace = "Paris",
            Country = "FR",
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
            Email = "john.doe@example.com",
            FirstName = "John",
            IsBeneficialOwner = true,
            IsDelegator = false,
            LastName = "Doe",
            LivenessVerification = true,
            Name = "ACME Corp",
            OwnershipPercentage = 50,
            PhoneNumber = "+33 1 23 45 67 89",
            PostalCode = "69000",
            RegistrationID = "987654321",
            Relation = "shareholder",
            Roles = "legal_representative",
            Source = Companies::Source.User,
            State = "PROCESSED",
            Status = "approved",
            Type = Companies::MemberType.Person,
            WorkspaceID = "wk_123",
        };

        string expectedID = "123e4567-e89b-12d3-a456-426614174000";
        string expectedAddress = "456 Avenue de Lyon, 69000 Lyon, France";
        DateTimeOffset expectedBirthday = DateTimeOffset.Parse("1980-06-15T00:00:00.000000+00:00");
        string expectedBirthplace = "Paris";
        string expectedCountry = "FR";
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
        string expectedEmail = "john.doe@example.com";
        string expectedFirstName = "John";
        bool expectedIsBeneficialOwner = true;
        bool expectedIsDelegator = false;
        string expectedLastName = "Doe";
        bool expectedLivenessVerification = true;
        string expectedName = "ACME Corp";
        long expectedOwnershipPercentage = 50;
        string expectedPhoneNumber = "+33 1 23 45 67 89";
        string expectedPostalCode = "69000";
        string expectedRegistrationID = "987654321";
        string expectedRelation = "shareholder";
        string expectedRoles = "legal_representative";
        ApiEnum<string, Companies::Source> expectedSource = Companies::Source.User;
        string expectedState = "PROCESSED";
        string expectedStatus = "approved";
        ApiEnum<string, Companies::MemberType> expectedType = Companies::MemberType.Person;
        string expectedWorkspaceID = "wk_123";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedBirthday, model.Birthday);
        Assert.Equal(expectedBirthplace, model.Birthplace);
        Assert.Equal(expectedCountry, model.Country);
        Assert.NotNull(model.Documents);
        Assert.Equal(expectedDocuments.Count, model.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], model.Documents[i]);
        }
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedFirstName, model.FirstName);
        Assert.Equal(expectedIsBeneficialOwner, model.IsBeneficialOwner);
        Assert.Equal(expectedIsDelegator, model.IsDelegator);
        Assert.Equal(expectedLastName, model.LastName);
        Assert.Equal(expectedLivenessVerification, model.LivenessVerification);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOwnershipPercentage, model.OwnershipPercentage);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedRegistrationID, model.RegistrationID);
        Assert.Equal(expectedRelation, model.Relation);
        Assert.Equal(expectedRoles, model.Roles);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Companies::Member
        {
            ID = "123e4567-e89b-12d3-a456-426614174000",
            Address = "456 Avenue de Lyon, 69000 Lyon, France",
            Birthday = DateTimeOffset.Parse("1980-06-15T00:00:00.000000+00:00"),
            Birthplace = "Paris",
            Country = "FR",
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
            Email = "john.doe@example.com",
            FirstName = "John",
            IsBeneficialOwner = true,
            IsDelegator = false,
            LastName = "Doe",
            LivenessVerification = true,
            Name = "ACME Corp",
            OwnershipPercentage = 50,
            PhoneNumber = "+33 1 23 45 67 89",
            PostalCode = "69000",
            RegistrationID = "987654321",
            Relation = "shareholder",
            Roles = "legal_representative",
            Source = Companies::Source.User,
            State = "PROCESSED",
            Status = "approved",
            Type = Companies::MemberType.Person,
            WorkspaceID = "wk_123",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Companies::Member>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Companies::Member
        {
            ID = "123e4567-e89b-12d3-a456-426614174000",
            Address = "456 Avenue de Lyon, 69000 Lyon, France",
            Birthday = DateTimeOffset.Parse("1980-06-15T00:00:00.000000+00:00"),
            Birthplace = "Paris",
            Country = "FR",
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
            Email = "john.doe@example.com",
            FirstName = "John",
            IsBeneficialOwner = true,
            IsDelegator = false,
            LastName = "Doe",
            LivenessVerification = true,
            Name = "ACME Corp",
            OwnershipPercentage = 50,
            PhoneNumber = "+33 1 23 45 67 89",
            PostalCode = "69000",
            RegistrationID = "987654321",
            Relation = "shareholder",
            Roles = "legal_representative",
            Source = Companies::Source.User,
            State = "PROCESSED",
            Status = "approved",
            Type = Companies::MemberType.Person,
            WorkspaceID = "wk_123",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Companies::Member>(element);
        Assert.NotNull(deserialized);

        string expectedID = "123e4567-e89b-12d3-a456-426614174000";
        string expectedAddress = "456 Avenue de Lyon, 69000 Lyon, France";
        DateTimeOffset expectedBirthday = DateTimeOffset.Parse("1980-06-15T00:00:00.000000+00:00");
        string expectedBirthplace = "Paris";
        string expectedCountry = "FR";
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
        string expectedEmail = "john.doe@example.com";
        string expectedFirstName = "John";
        bool expectedIsBeneficialOwner = true;
        bool expectedIsDelegator = false;
        string expectedLastName = "Doe";
        bool expectedLivenessVerification = true;
        string expectedName = "ACME Corp";
        long expectedOwnershipPercentage = 50;
        string expectedPhoneNumber = "+33 1 23 45 67 89";
        string expectedPostalCode = "69000";
        string expectedRegistrationID = "987654321";
        string expectedRelation = "shareholder";
        string expectedRoles = "legal_representative";
        ApiEnum<string, Companies::Source> expectedSource = Companies::Source.User;
        string expectedState = "PROCESSED";
        string expectedStatus = "approved";
        ApiEnum<string, Companies::MemberType> expectedType = Companies::MemberType.Person;
        string expectedWorkspaceID = "wk_123";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedBirthday, deserialized.Birthday);
        Assert.Equal(expectedBirthplace, deserialized.Birthplace);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.NotNull(deserialized.Documents);
        Assert.Equal(expectedDocuments.Count, deserialized.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], deserialized.Documents[i]);
        }
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedFirstName, deserialized.FirstName);
        Assert.Equal(expectedIsBeneficialOwner, deserialized.IsBeneficialOwner);
        Assert.Equal(expectedIsDelegator, deserialized.IsDelegator);
        Assert.Equal(expectedLastName, deserialized.LastName);
        Assert.Equal(expectedLivenessVerification, deserialized.LivenessVerification);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOwnershipPercentage, deserialized.OwnershipPercentage);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedRegistrationID, deserialized.RegistrationID);
        Assert.Equal(expectedRelation, deserialized.Relation);
        Assert.Equal(expectedRoles, deserialized.Roles);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Companies::Member
        {
            ID = "123e4567-e89b-12d3-a456-426614174000",
            Address = "456 Avenue de Lyon, 69000 Lyon, France",
            Birthday = DateTimeOffset.Parse("1980-06-15T00:00:00.000000+00:00"),
            Birthplace = "Paris",
            Country = "FR",
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
            Email = "john.doe@example.com",
            FirstName = "John",
            IsBeneficialOwner = true,
            IsDelegator = false,
            LastName = "Doe",
            LivenessVerification = true,
            Name = "ACME Corp",
            OwnershipPercentage = 50,
            PhoneNumber = "+33 1 23 45 67 89",
            PostalCode = "69000",
            RegistrationID = "987654321",
            Relation = "shareholder",
            Roles = "legal_representative",
            Source = Companies::Source.User,
            State = "PROCESSED",
            Status = "approved",
            Type = Companies::MemberType.Person,
            WorkspaceID = "wk_123",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Companies::Member { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.Birthday);
        Assert.False(model.RawData.ContainsKey("birthday"));
        Assert.Null(model.Birthplace);
        Assert.False(model.RawData.ContainsKey("birthplace"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Documents);
        Assert.False(model.RawData.ContainsKey("documents"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.FirstName);
        Assert.False(model.RawData.ContainsKey("first_name"));
        Assert.Null(model.IsBeneficialOwner);
        Assert.False(model.RawData.ContainsKey("is_beneficial_owner"));
        Assert.Null(model.IsDelegator);
        Assert.False(model.RawData.ContainsKey("is_delegator"));
        Assert.Null(model.LastName);
        Assert.False(model.RawData.ContainsKey("last_name"));
        Assert.Null(model.LivenessVerification);
        Assert.False(model.RawData.ContainsKey("liveness_verification"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.OwnershipPercentage);
        Assert.False(model.RawData.ContainsKey("ownership_percentage"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postal_code"));
        Assert.Null(model.RegistrationID);
        Assert.False(model.RawData.ContainsKey("registration_id"));
        Assert.Null(model.Relation);
        Assert.False(model.RawData.ContainsKey("relation"));
        Assert.Null(model.Roles);
        Assert.False(model.RawData.ContainsKey("roles"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.WorkspaceID);
        Assert.False(model.RawData.ContainsKey("workspace_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Companies::Member { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Companies::Member
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Address = null,
            Birthday = null,
            Birthplace = null,
            Country = null,
            Documents = null,
            Email = null,
            FirstName = null,
            IsBeneficialOwner = null,
            IsDelegator = null,
            LastName = null,
            LivenessVerification = null,
            Name = null,
            OwnershipPercentage = null,
            PhoneNumber = null,
            PostalCode = null,
            RegistrationID = null,
            Relation = null,
            Roles = null,
            Source = null,
            State = null,
            Status = null,
            Type = null,
            WorkspaceID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.Birthday);
        Assert.False(model.RawData.ContainsKey("birthday"));
        Assert.Null(model.Birthplace);
        Assert.False(model.RawData.ContainsKey("birthplace"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Documents);
        Assert.False(model.RawData.ContainsKey("documents"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.FirstName);
        Assert.False(model.RawData.ContainsKey("first_name"));
        Assert.Null(model.IsBeneficialOwner);
        Assert.False(model.RawData.ContainsKey("is_beneficial_owner"));
        Assert.Null(model.IsDelegator);
        Assert.False(model.RawData.ContainsKey("is_delegator"));
        Assert.Null(model.LastName);
        Assert.False(model.RawData.ContainsKey("last_name"));
        Assert.Null(model.LivenessVerification);
        Assert.False(model.RawData.ContainsKey("liveness_verification"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.OwnershipPercentage);
        Assert.False(model.RawData.ContainsKey("ownership_percentage"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postal_code"));
        Assert.Null(model.RegistrationID);
        Assert.False(model.RawData.ContainsKey("registration_id"));
        Assert.Null(model.Relation);
        Assert.False(model.RawData.ContainsKey("relation"));
        Assert.Null(model.Roles);
        Assert.False(model.RawData.ContainsKey("roles"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.WorkspaceID);
        Assert.False(model.RawData.ContainsKey("workspace_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Companies::Member
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Address = null,
            Birthday = null,
            Birthplace = null,
            Country = null,
            Documents = null,
            Email = null,
            FirstName = null,
            IsBeneficialOwner = null,
            IsDelegator = null,
            LastName = null,
            LivenessVerification = null,
            Name = null,
            OwnershipPercentage = null,
            PhoneNumber = null,
            PostalCode = null,
            RegistrationID = null,
            Relation = null,
            Roles = null,
            Source = null,
            State = null,
            Status = null,
            Type = null,
            WorkspaceID = null,
        };

        model.Validate();
    }
}

public class SourceTest : TestBase
{
    [Theory]
    [InlineData(Companies::Source.Gouve)]
    [InlineData(Companies::Source.User)]
    [InlineData(Companies::Source.Company)]
    public void Validation_Works(Companies::Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Companies::Source> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Companies::Source>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DataleonlabsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Companies::Source.Gouve)]
    [InlineData(Companies::Source.User)]
    [InlineData(Companies::Source.Company)]
    public void SerializationRoundtrip_Works(Companies::Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Companies::Source> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Companies::Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Companies::Source>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Companies::Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MemberTypeTest : TestBase
{
    [Theory]
    [InlineData(Companies::MemberType.Person)]
    [InlineData(Companies::MemberType.Company)]
    public void Validation_Works(Companies::MemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Companies::MemberType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Companies::MemberType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DataleonlabsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Companies::MemberType.Person)]
    [InlineData(Companies::MemberType.Company)]
    public void SerializationRoundtrip_Works(Companies::MemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Companies::MemberType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Companies::MemberType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Companies::MemberType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Companies::MemberType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
