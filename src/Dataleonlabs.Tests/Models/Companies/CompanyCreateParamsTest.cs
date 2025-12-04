using System.Collections.Generic;
using System.Text.Json;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Companies;

namespace Dataleonlabs.Tests.Models.Companies;

public class CompanyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Company
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
            WebsiteURL = "https://acme.fr",
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
        string expectedWebsiteURL = "https://acme.fr";

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
        Assert.Equal(expectedWebsiteURL, model.WebsiteURL);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Company
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
            WebsiteURL = "https://acme.fr",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Company>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Company
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
            WebsiteURL = "https://acme.fr",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Company>(json);
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
        string expectedWebsiteURL = "https://acme.fr";

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
        Assert.Equal(expectedWebsiteURL, deserialized.WebsiteURL);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Company
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
            WebsiteURL = "https://acme.fr",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Company { Name = "ACME Corp" };

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
        Assert.Null(model.WebsiteURL);
        Assert.False(model.RawData.ContainsKey("website_url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Company { Name = "ACME Corp" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Company
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
            WebsiteURL = null,
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
        Assert.Null(model.WebsiteURL);
        Assert.False(model.RawData.ContainsKey("website_url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Company
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
            WebsiteURL = null,
        };

        model.Validate();
    }
}

public class TechnicalDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TechnicalData
        {
            ActiveAmlSuspicions = false,
            CallbackURL = "https://example.com/callback",
            CallbackURLNotification = "https://example.com/notify",
            FilteringScoreAmlSuspicions = 0.75,
            Language = "fra",
            PortalSteps = [PortalStep.IdentityVerification, PortalStep.DocumentSigning],
            RawDataValue = true,
        };

        bool expectedActiveAmlSuspicions = false;
        string expectedCallbackURL = "https://example.com/callback";
        string expectedCallbackURLNotification = "https://example.com/notify";
        float expectedFilteringScoreAmlSuspicions = 0.75;
        string expectedLanguage = "fra";
        List<ApiEnum<string, PortalStep>> expectedPortalSteps =
        [
            PortalStep.IdentityVerification,
            PortalStep.DocumentSigning,
        ];
        bool expectedRawDataValue = true;

        Assert.Equal(expectedActiveAmlSuspicions, model.ActiveAmlSuspicions);
        Assert.Equal(expectedCallbackURL, model.CallbackURL);
        Assert.Equal(expectedCallbackURLNotification, model.CallbackURLNotification);
        Assert.Equal(expectedFilteringScoreAmlSuspicions, model.FilteringScoreAmlSuspicions);
        Assert.Equal(expectedLanguage, model.Language);
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
        var model = new TechnicalData
        {
            ActiveAmlSuspicions = false,
            CallbackURL = "https://example.com/callback",
            CallbackURLNotification = "https://example.com/notify",
            FilteringScoreAmlSuspicions = 0.75,
            Language = "fra",
            PortalSteps = [PortalStep.IdentityVerification, PortalStep.DocumentSigning],
            RawDataValue = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TechnicalData>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TechnicalData
        {
            ActiveAmlSuspicions = false,
            CallbackURL = "https://example.com/callback",
            CallbackURLNotification = "https://example.com/notify",
            FilteringScoreAmlSuspicions = 0.75,
            Language = "fra",
            PortalSteps = [PortalStep.IdentityVerification, PortalStep.DocumentSigning],
            RawDataValue = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TechnicalData>(json);
        Assert.NotNull(deserialized);

        bool expectedActiveAmlSuspicions = false;
        string expectedCallbackURL = "https://example.com/callback";
        string expectedCallbackURLNotification = "https://example.com/notify";
        float expectedFilteringScoreAmlSuspicions = 0.75;
        string expectedLanguage = "fra";
        List<ApiEnum<string, PortalStep>> expectedPortalSteps =
        [
            PortalStep.IdentityVerification,
            PortalStep.DocumentSigning,
        ];
        bool expectedRawDataValue = true;

        Assert.Equal(expectedActiveAmlSuspicions, deserialized.ActiveAmlSuspicions);
        Assert.Equal(expectedCallbackURL, deserialized.CallbackURL);
        Assert.Equal(expectedCallbackURLNotification, deserialized.CallbackURLNotification);
        Assert.Equal(expectedFilteringScoreAmlSuspicions, deserialized.FilteringScoreAmlSuspicions);
        Assert.Equal(expectedLanguage, deserialized.Language);
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
        var model = new TechnicalData
        {
            ActiveAmlSuspicions = false,
            CallbackURL = "https://example.com/callback",
            CallbackURLNotification = "https://example.com/notify",
            FilteringScoreAmlSuspicions = 0.75,
            Language = "fra",
            PortalSteps = [PortalStep.IdentityVerification, PortalStep.DocumentSigning],
            RawDataValue = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TechnicalData { };

        Assert.Null(model.ActiveAmlSuspicions);
        Assert.False(model.RawData.ContainsKey("active_aml_suspicions"));
        Assert.Null(model.CallbackURL);
        Assert.False(model.RawData.ContainsKey("callback_url"));
        Assert.Null(model.CallbackURLNotification);
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
        var model = new TechnicalData { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TechnicalData
        {
            // Null should be interpreted as omitted for these properties
            ActiveAmlSuspicions = null,
            CallbackURL = null,
            CallbackURLNotification = null,
            FilteringScoreAmlSuspicions = null,
            Language = null,
            PortalSteps = null,
            RawDataValue = null,
        };

        Assert.Null(model.ActiveAmlSuspicions);
        Assert.False(model.RawData.ContainsKey("active_aml_suspicions"));
        Assert.Null(model.CallbackURL);
        Assert.False(model.RawData.ContainsKey("callback_url"));
        Assert.Null(model.CallbackURLNotification);
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
        var model = new TechnicalData
        {
            // Null should be interpreted as omitted for these properties
            ActiveAmlSuspicions = null,
            CallbackURL = null,
            CallbackURLNotification = null,
            FilteringScoreAmlSuspicions = null,
            Language = null,
            PortalSteps = null,
            RawDataValue = null,
        };

        model.Validate();
    }
}
