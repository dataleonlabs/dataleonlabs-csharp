using System;
using System.Collections.Generic;
using System.Text.Json;
using Dataleonlabs.Core;
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
                    Score = 0.85,
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
                    Validate1 = true,
                    Weight = 1,
                },
            ],
            Company = new()
            {
                Address = "123 Rue de Paris, 75001 Paris, France",
                ClosureDate =
#if NET
                DateOnly
#else
                DateTimeOffset
#endif
                .Parse("2025-12-31"),
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
                RegistrationDate =
#if NET
                DateOnly
#else
                DateTimeOffset
#endif
                .Parse("2010-05-20"),
                RegistrationID = "123456789",
                ShareCapital = "100000 EUR",
                Status = "active",
                TaxIdentificationNumber = "FR123456789",
                Type = "main",
                WebsiteURL = "https://www.acme.com",
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
                                    Value1 = [100, 200],
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
            PortalURL = "https://portal.dataleon.ai/e/123",
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
            SourceID = "src-001",
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
            WebviewURL = "https://id.dataleon.ai/e/123",
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
                Score = 0.85,
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
                Validate1 = true,
                Weight = 1,
            },
        ];
        Companies::CompanyCompanyCompany expectedCompany = new()
        {
            Address = "123 Rue de Paris, 75001 Paris, France",
            ClosureDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2025-12-31"),
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
            RegistrationDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2010-05-20"),
            RegistrationID = "123456789",
            ShareCapital = "100000 EUR",
            Status = "active",
            TaxIdentificationNumber = "FR123456789",
            Type = "main",
            WebsiteURL = "https://www.acme.com",
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
        string expectedPortalURL = "https://portal.dataleon.ai/e/123";
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
        string expectedSourceID = "src-001";
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
        string expectedWebviewURL = "https://id.dataleon.ai/e/123";

        Assert.Equal(expectedAmlSuspicions.Count, model.AmlSuspicions.Count);
        for (int i = 0; i < expectedAmlSuspicions.Count; i++)
        {
            Assert.Equal(expectedAmlSuspicions[i], model.AmlSuspicions[i]);
        }
        Assert.Equal(expectedCertificat, model.Certificat);
        Assert.Equal(expectedChecks.Count, model.Checks.Count);
        for (int i = 0; i < expectedChecks.Count; i++)
        {
            Assert.Equal(expectedChecks[i], model.Checks[i]);
        }
        Assert.Equal(expectedCompany, model.Company);
        Assert.Equal(expectedDocuments.Count, model.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], model.Documents[i]);
        }
        Assert.Equal(expectedMembers.Count, model.Members.Count);
        for (int i = 0; i < expectedMembers.Count; i++)
        {
            Assert.Equal(expectedMembers[i], model.Members[i]);
        }
        Assert.Equal(expectedPortalURL, model.PortalURL);
        Assert.Equal(expectedProperties.Count, model.Properties.Count);
        for (int i = 0; i < expectedProperties.Count; i++)
        {
            Assert.Equal(expectedProperties[i], model.Properties[i]);
        }
        Assert.Equal(expectedRisk, model.Risk);
        Assert.Equal(expectedSourceID, model.SourceID);
        Assert.Equal(expectedTechnicalData, model.TechnicalData);
        Assert.Equal(expectedWebviewURL, model.WebviewURL);
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
            ClosureDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2025-12-31"),
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
            RegistrationDate =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2010-05-20"),
            RegistrationID = "123456789",
            ShareCapital = "100000 EUR",
            Status = "active",
            TaxIdentificationNumber = "FR123456789",
            Type = "main",
            WebsiteURL = "https://www.acme.com",
        };

        string expectedAddress = "123 Rue de Paris, 75001 Paris, France";

#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        expectedClosureDate =
#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        .Parse("2025-12-31");
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

#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        expectedRegistrationDate =
#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        .Parse("2010-05-20");
        string expectedRegistrationID = "123456789";
        string expectedShareCapital = "100000 EUR";
        string expectedStatus = "active";
        string expectedTaxIdentificationNumber = "FR123456789";
        string expectedType = "main";
        string expectedWebsiteURL = "https://www.acme.com";

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
        Assert.Equal(expectedWebsiteURL, model.WebsiteURL);
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
}
