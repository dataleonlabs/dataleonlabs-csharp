using System;
using System.Collections.Generic;
using System.Text.Json;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;
using Dataleonlabs.Models.Companies;

namespace Dataleonlabs.Tests.Models.Companies;

public class CompanyUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CompanyUpdateParams
        {
            CompanyID = "company_id",
            Company = new()
            {
                Name = "ACME Corp",
                Address = "123 rue Exemple, Paris",
                CommercialName = "ACME",
                Country = "FR",
                Email = "info@acme.fr",
                EmployerIdentificationNumber = "EIN123456",
                LegalForm = "SARL",
                PhoneNumber = "+33 1 23 45 67 89",
                RegistrationDate = "2010-05-15",
                RegistrationID = "RCS123456",
                ShareCapital = "100000",
                Status = "active",
                TaxIdentificationNumber = "FR123456789",
                Type = "main",
                WebsiteUrl = "https://acme.fr",
            },
            WorkspaceID = "wk_123",
            SourceID = "ID54410069066",
            TechnicalData = new()
            {
                ActiveAmlSuspicions = false,
                CallbackUrl = "https://example.com/callback",
                CallbackUrlNotification = "https://example.com/notify",
                FilteringScoreAmlSuspicions = 0.75f,
                Language = "fra",
                PortalSteps =
                [
                    CompanyUpdateParamsTechnicalDataPortalStep.IdentityVerification,
                    CompanyUpdateParamsTechnicalDataPortalStep.DocumentSigning,
                ],
                RawDataValue = true,
            },
        };

        string expectedCompanyID = "company_id";
        CompanyUpdateParamsCompany expectedCompany = new()
        {
            Name = "ACME Corp",
            Address = "123 rue Exemple, Paris",
            CommercialName = "ACME",
            Country = "FR",
            Email = "info@acme.fr",
            EmployerIdentificationNumber = "EIN123456",
            LegalForm = "SARL",
            PhoneNumber = "+33 1 23 45 67 89",
            RegistrationDate = "2010-05-15",
            RegistrationID = "RCS123456",
            ShareCapital = "100000",
            Status = "active",
            TaxIdentificationNumber = "FR123456789",
            Type = "main",
            WebsiteUrl = "https://acme.fr",
        };
        string expectedWorkspaceID = "wk_123";
        string expectedSourceID = "ID54410069066";
        CompanyUpdateParamsTechnicalData expectedTechnicalData = new()
        {
            ActiveAmlSuspicions = false,
            CallbackUrl = "https://example.com/callback",
            CallbackUrlNotification = "https://example.com/notify",
            FilteringScoreAmlSuspicions = 0.75f,
            Language = "fra",
            PortalSteps =
            [
                CompanyUpdateParamsTechnicalDataPortalStep.IdentityVerification,
                CompanyUpdateParamsTechnicalDataPortalStep.DocumentSigning,
            ],
            RawDataValue = true,
        };

        Assert.Equal(expectedCompanyID, parameters.CompanyID);
        Assert.Equal(expectedCompany, parameters.Company);
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
        Assert.Equal(expectedSourceID, parameters.SourceID);
        Assert.Equal(expectedTechnicalData, parameters.TechnicalData);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CompanyUpdateParams
        {
            CompanyID = "company_id",
            Company = new()
            {
                Name = "ACME Corp",
                Address = "123 rue Exemple, Paris",
                CommercialName = "ACME",
                Country = "FR",
                Email = "info@acme.fr",
                EmployerIdentificationNumber = "EIN123456",
                LegalForm = "SARL",
                PhoneNumber = "+33 1 23 45 67 89",
                RegistrationDate = "2010-05-15",
                RegistrationID = "RCS123456",
                ShareCapital = "100000",
                Status = "active",
                TaxIdentificationNumber = "FR123456789",
                Type = "main",
                WebsiteUrl = "https://acme.fr",
            },
            WorkspaceID = "wk_123",
        };

        Assert.Null(parameters.SourceID);
        Assert.False(parameters.RawBodyData.ContainsKey("source_id"));
        Assert.Null(parameters.TechnicalData);
        Assert.False(parameters.RawBodyData.ContainsKey("technical_data"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CompanyUpdateParams
        {
            CompanyID = "company_id",
            Company = new()
            {
                Name = "ACME Corp",
                Address = "123 rue Exemple, Paris",
                CommercialName = "ACME",
                Country = "FR",
                Email = "info@acme.fr",
                EmployerIdentificationNumber = "EIN123456",
                LegalForm = "SARL",
                PhoneNumber = "+33 1 23 45 67 89",
                RegistrationDate = "2010-05-15",
                RegistrationID = "RCS123456",
                ShareCapital = "100000",
                Status = "active",
                TaxIdentificationNumber = "FR123456789",
                Type = "main",
                WebsiteUrl = "https://acme.fr",
            },
            WorkspaceID = "wk_123",

            // Null should be interpreted as omitted for these properties
            SourceID = null,
            TechnicalData = null,
        };

        Assert.Null(parameters.SourceID);
        Assert.False(parameters.RawBodyData.ContainsKey("source_id"));
        Assert.Null(parameters.TechnicalData);
        Assert.False(parameters.RawBodyData.ContainsKey("technical_data"));
    }

    [Fact]
    public void Url_Works()
    {
        CompanyUpdateParams parameters = new()
        {
            CompanyID = "company_id",
            Company = new()
            {
                Name = "ACME Corp",
                Address = "123 rue Exemple, Paris",
                CommercialName = "ACME",
                Country = "FR",
                Email = "info@acme.fr",
                EmployerIdentificationNumber = "EIN123456",
                LegalForm = "SARL",
                PhoneNumber = "+33 1 23 45 67 89",
                RegistrationDate = "2010-05-15",
                RegistrationID = "RCS123456",
                ShareCapital = "100000",
                Status = "active",
                TaxIdentificationNumber = "FR123456789",
                Type = "main",
                WebsiteUrl = "https://acme.fr",
            },
            WorkspaceID = "wk_123",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://inference.eu-west-1.dataleon.ai/companies/company_id"), url);
    }
}

public class CompanyUpdateParamsCompanyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompanyUpdateParamsCompany
        {
            Name = "ACME Corp",
            Address = "123 rue Exemple, Paris",
            CommercialName = "ACME",
            Country = "FR",
            Email = "info@acme.fr",
            EmployerIdentificationNumber = "EIN123456",
            LegalForm = "SARL",
            PhoneNumber = "+33 1 23 45 67 89",
            RegistrationDate = "2010-05-15",
            RegistrationID = "RCS123456",
            ShareCapital = "100000",
            Status = "active",
            TaxIdentificationNumber = "FR123456789",
            Type = "main",
            WebsiteUrl = "https://acme.fr",
        };

        string expectedName = "ACME Corp";
        string expectedAddress = "123 rue Exemple, Paris";
        string expectedCommercialName = "ACME";
        string expectedCountry = "FR";
        string expectedEmail = "info@acme.fr";
        string expectedEmployerIdentificationNumber = "EIN123456";
        string expectedLegalForm = "SARL";
        string expectedPhoneNumber = "+33 1 23 45 67 89";
        string expectedRegistrationDate = "2010-05-15";
        string expectedRegistrationID = "RCS123456";
        string expectedShareCapital = "100000";
        string expectedStatus = "active";
        string expectedTaxIdentificationNumber = "FR123456789";
        string expectedType = "main";
        string expectedWebsiteUrl = "https://acme.fr";

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedCommercialName, model.CommercialName);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedEmployerIdentificationNumber, model.EmployerIdentificationNumber);
        Assert.Equal(expectedLegalForm, model.LegalForm);
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
        var model = new CompanyUpdateParamsCompany
        {
            Name = "ACME Corp",
            Address = "123 rue Exemple, Paris",
            CommercialName = "ACME",
            Country = "FR",
            Email = "info@acme.fr",
            EmployerIdentificationNumber = "EIN123456",
            LegalForm = "SARL",
            PhoneNumber = "+33 1 23 45 67 89",
            RegistrationDate = "2010-05-15",
            RegistrationID = "RCS123456",
            ShareCapital = "100000",
            Status = "active",
            TaxIdentificationNumber = "FR123456789",
            Type = "main",
            WebsiteUrl = "https://acme.fr",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CompanyUpdateParamsCompany>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CompanyUpdateParamsCompany
        {
            Name = "ACME Corp",
            Address = "123 rue Exemple, Paris",
            CommercialName = "ACME",
            Country = "FR",
            Email = "info@acme.fr",
            EmployerIdentificationNumber = "EIN123456",
            LegalForm = "SARL",
            PhoneNumber = "+33 1 23 45 67 89",
            RegistrationDate = "2010-05-15",
            RegistrationID = "RCS123456",
            ShareCapital = "100000",
            Status = "active",
            TaxIdentificationNumber = "FR123456789",
            Type = "main",
            WebsiteUrl = "https://acme.fr",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CompanyUpdateParamsCompany>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "ACME Corp";
        string expectedAddress = "123 rue Exemple, Paris";
        string expectedCommercialName = "ACME";
        string expectedCountry = "FR";
        string expectedEmail = "info@acme.fr";
        string expectedEmployerIdentificationNumber = "EIN123456";
        string expectedLegalForm = "SARL";
        string expectedPhoneNumber = "+33 1 23 45 67 89";
        string expectedRegistrationDate = "2010-05-15";
        string expectedRegistrationID = "RCS123456";
        string expectedShareCapital = "100000";
        string expectedStatus = "active";
        string expectedTaxIdentificationNumber = "FR123456789";
        string expectedType = "main";
        string expectedWebsiteUrl = "https://acme.fr";

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedCommercialName, deserialized.CommercialName);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(
            expectedEmployerIdentificationNumber,
            deserialized.EmployerIdentificationNumber
        );
        Assert.Equal(expectedLegalForm, deserialized.LegalForm);
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
        var model = new CompanyUpdateParamsCompany
        {
            Name = "ACME Corp",
            Address = "123 rue Exemple, Paris",
            CommercialName = "ACME",
            Country = "FR",
            Email = "info@acme.fr",
            EmployerIdentificationNumber = "EIN123456",
            LegalForm = "SARL",
            PhoneNumber = "+33 1 23 45 67 89",
            RegistrationDate = "2010-05-15",
            RegistrationID = "RCS123456",
            ShareCapital = "100000",
            Status = "active",
            TaxIdentificationNumber = "FR123456789",
            Type = "main",
            WebsiteUrl = "https://acme.fr",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CompanyUpdateParamsCompany { Name = "ACME Corp" };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
        Assert.Null(model.CommercialName);
        Assert.False(model.RawData.ContainsKey("commercial_name"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.EmployerIdentificationNumber);
        Assert.False(model.RawData.ContainsKey("employer_identification_number"));
        Assert.Null(model.LegalForm);
        Assert.False(model.RawData.ContainsKey("legal_form"));
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
        var model = new CompanyUpdateParamsCompany { Name = "ACME Corp" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CompanyUpdateParamsCompany
        {
            Name = "ACME Corp",

            // Null should be interpreted as omitted for these properties
            Address = null,
            CommercialName = null,
            Country = null,
            Email = null,
            EmployerIdentificationNumber = null,
            LegalForm = null,
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
        Assert.Null(model.CommercialName);
        Assert.False(model.RawData.ContainsKey("commercial_name"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.EmployerIdentificationNumber);
        Assert.False(model.RawData.ContainsKey("employer_identification_number"));
        Assert.Null(model.LegalForm);
        Assert.False(model.RawData.ContainsKey("legal_form"));
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
        var model = new CompanyUpdateParamsCompany
        {
            Name = "ACME Corp",

            // Null should be interpreted as omitted for these properties
            Address = null,
            CommercialName = null,
            Country = null,
            Email = null,
            EmployerIdentificationNumber = null,
            LegalForm = null,
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

public class CompanyUpdateParamsTechnicalDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompanyUpdateParamsTechnicalData
        {
            ActiveAmlSuspicions = false,
            CallbackUrl = "https://example.com/callback",
            CallbackUrlNotification = "https://example.com/notify",
            FilteringScoreAmlSuspicions = 0.75f,
            Language = "fra",
            PortalSteps =
            [
                CompanyUpdateParamsTechnicalDataPortalStep.IdentityVerification,
                CompanyUpdateParamsTechnicalDataPortalStep.DocumentSigning,
            ],
            RawDataValue = true,
        };

        bool expectedActiveAmlSuspicions = false;
        string expectedCallbackUrl = "https://example.com/callback";
        string expectedCallbackUrlNotification = "https://example.com/notify";
        float expectedFilteringScoreAmlSuspicions = 0.75f;
        string expectedLanguage = "fra";
        List<ApiEnum<string, CompanyUpdateParamsTechnicalDataPortalStep>> expectedPortalSteps =
        [
            CompanyUpdateParamsTechnicalDataPortalStep.IdentityVerification,
            CompanyUpdateParamsTechnicalDataPortalStep.DocumentSigning,
        ];
        bool expectedRawDataValue = true;

        Assert.Equal(expectedActiveAmlSuspicions, model.ActiveAmlSuspicions);
        Assert.Equal(expectedCallbackUrl, model.CallbackUrl);
        Assert.Equal(expectedCallbackUrlNotification, model.CallbackUrlNotification);
        Assert.Equal(expectedFilteringScoreAmlSuspicions, model.FilteringScoreAmlSuspicions);
        Assert.Equal(expectedLanguage, model.Language);
        Assert.NotNull(model.PortalSteps);
        Assert.Equal(expectedPortalSteps.Count, model.PortalSteps.Count);
        for (int i = 0; i < expectedPortalSteps.Count; i++)
        {
            Assert.Equal(expectedPortalSteps[i], model.PortalSteps[i]);
        }
        Assert.Equal(expectedRawDataValue, model.RawDataValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CompanyUpdateParamsTechnicalData
        {
            ActiveAmlSuspicions = false,
            CallbackUrl = "https://example.com/callback",
            CallbackUrlNotification = "https://example.com/notify",
            FilteringScoreAmlSuspicions = 0.75f,
            Language = "fra",
            PortalSteps =
            [
                CompanyUpdateParamsTechnicalDataPortalStep.IdentityVerification,
                CompanyUpdateParamsTechnicalDataPortalStep.DocumentSigning,
            ],
            RawDataValue = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CompanyUpdateParamsTechnicalData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CompanyUpdateParamsTechnicalData
        {
            ActiveAmlSuspicions = false,
            CallbackUrl = "https://example.com/callback",
            CallbackUrlNotification = "https://example.com/notify",
            FilteringScoreAmlSuspicions = 0.75f,
            Language = "fra",
            PortalSteps =
            [
                CompanyUpdateParamsTechnicalDataPortalStep.IdentityVerification,
                CompanyUpdateParamsTechnicalDataPortalStep.DocumentSigning,
            ],
            RawDataValue = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CompanyUpdateParamsTechnicalData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedActiveAmlSuspicions = false;
        string expectedCallbackUrl = "https://example.com/callback";
        string expectedCallbackUrlNotification = "https://example.com/notify";
        float expectedFilteringScoreAmlSuspicions = 0.75f;
        string expectedLanguage = "fra";
        List<ApiEnum<string, CompanyUpdateParamsTechnicalDataPortalStep>> expectedPortalSteps =
        [
            CompanyUpdateParamsTechnicalDataPortalStep.IdentityVerification,
            CompanyUpdateParamsTechnicalDataPortalStep.DocumentSigning,
        ];
        bool expectedRawDataValue = true;

        Assert.Equal(expectedActiveAmlSuspicions, deserialized.ActiveAmlSuspicions);
        Assert.Equal(expectedCallbackUrl, deserialized.CallbackUrl);
        Assert.Equal(expectedCallbackUrlNotification, deserialized.CallbackUrlNotification);
        Assert.Equal(expectedFilteringScoreAmlSuspicions, deserialized.FilteringScoreAmlSuspicions);
        Assert.Equal(expectedLanguage, deserialized.Language);
        Assert.NotNull(deserialized.PortalSteps);
        Assert.Equal(expectedPortalSteps.Count, deserialized.PortalSteps.Count);
        for (int i = 0; i < expectedPortalSteps.Count; i++)
        {
            Assert.Equal(expectedPortalSteps[i], deserialized.PortalSteps[i]);
        }
        Assert.Equal(expectedRawDataValue, deserialized.RawDataValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CompanyUpdateParamsTechnicalData
        {
            ActiveAmlSuspicions = false,
            CallbackUrl = "https://example.com/callback",
            CallbackUrlNotification = "https://example.com/notify",
            FilteringScoreAmlSuspicions = 0.75f,
            Language = "fra",
            PortalSteps =
            [
                CompanyUpdateParamsTechnicalDataPortalStep.IdentityVerification,
                CompanyUpdateParamsTechnicalDataPortalStep.DocumentSigning,
            ],
            RawDataValue = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CompanyUpdateParamsTechnicalData { };

        Assert.Null(model.ActiveAmlSuspicions);
        Assert.False(model.RawData.ContainsKey("active_aml_suspicions"));
        Assert.Null(model.CallbackUrl);
        Assert.False(model.RawData.ContainsKey("callback_url"));
        Assert.Null(model.CallbackUrlNotification);
        Assert.False(model.RawData.ContainsKey("callback_url_notification"));
        Assert.Null(model.FilteringScoreAmlSuspicions);
        Assert.False(model.RawData.ContainsKey("filtering_score_aml_suspicions"));
        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
        Assert.Null(model.PortalSteps);
        Assert.False(model.RawData.ContainsKey("portal_steps"));
        Assert.Null(model.RawDataValue);
        Assert.False(model.RawData.ContainsKey("raw_data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CompanyUpdateParamsTechnicalData { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CompanyUpdateParamsTechnicalData
        {
            // Null should be interpreted as omitted for these properties
            ActiveAmlSuspicions = null,
            CallbackUrl = null,
            CallbackUrlNotification = null,
            FilteringScoreAmlSuspicions = null,
            Language = null,
            PortalSteps = null,
            RawDataValue = null,
        };

        Assert.Null(model.ActiveAmlSuspicions);
        Assert.False(model.RawData.ContainsKey("active_aml_suspicions"));
        Assert.Null(model.CallbackUrl);
        Assert.False(model.RawData.ContainsKey("callback_url"));
        Assert.Null(model.CallbackUrlNotification);
        Assert.False(model.RawData.ContainsKey("callback_url_notification"));
        Assert.Null(model.FilteringScoreAmlSuspicions);
        Assert.False(model.RawData.ContainsKey("filtering_score_aml_suspicions"));
        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
        Assert.Null(model.PortalSteps);
        Assert.False(model.RawData.ContainsKey("portal_steps"));
        Assert.Null(model.RawDataValue);
        Assert.False(model.RawData.ContainsKey("raw_data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CompanyUpdateParamsTechnicalData
        {
            // Null should be interpreted as omitted for these properties
            ActiveAmlSuspicions = null,
            CallbackUrl = null,
            CallbackUrlNotification = null,
            FilteringScoreAmlSuspicions = null,
            Language = null,
            PortalSteps = null,
            RawDataValue = null,
        };

        model.Validate();
    }
}

public class CompanyUpdateParamsTechnicalDataPortalStepTest : TestBase
{
    [Theory]
    [InlineData(CompanyUpdateParamsTechnicalDataPortalStep.IdentityVerification)]
    [InlineData(CompanyUpdateParamsTechnicalDataPortalStep.DocumentSigning)]
    [InlineData(CompanyUpdateParamsTechnicalDataPortalStep.ProofOfAddress)]
    [InlineData(CompanyUpdateParamsTechnicalDataPortalStep.Selfie)]
    [InlineData(CompanyUpdateParamsTechnicalDataPortalStep.FaceMatch)]
    public void Validation_Works(CompanyUpdateParamsTechnicalDataPortalStep rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CompanyUpdateParamsTechnicalDataPortalStep> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CompanyUpdateParamsTechnicalDataPortalStep>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DataleonlabsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CompanyUpdateParamsTechnicalDataPortalStep.IdentityVerification)]
    [InlineData(CompanyUpdateParamsTechnicalDataPortalStep.DocumentSigning)]
    [InlineData(CompanyUpdateParamsTechnicalDataPortalStep.ProofOfAddress)]
    [InlineData(CompanyUpdateParamsTechnicalDataPortalStep.Selfie)]
    [InlineData(CompanyUpdateParamsTechnicalDataPortalStep.FaceMatch)]
    public void SerializationRoundtrip_Works(CompanyUpdateParamsTechnicalDataPortalStep rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CompanyUpdateParamsTechnicalDataPortalStep> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CompanyUpdateParamsTechnicalDataPortalStep>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CompanyUpdateParamsTechnicalDataPortalStep>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CompanyUpdateParamsTechnicalDataPortalStep>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
