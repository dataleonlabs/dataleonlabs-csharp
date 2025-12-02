using System.Collections.Generic;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Companies;

namespace Dataleonlabs.Tests.Models.Companies;

public class CompanyModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CompanyModel
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
}

public class TechnicalDataModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TechnicalDataModel
        {
            ActiveAmlSuspicions = false,
            CallbackURL = "https://example.com/callback",
            CallbackURLNotification = "https://example.com/notify",
            FilteringScoreAmlSuspicions = 0.75,
            Language = "fra",
            PortalSteps = [PortalStepModel.IdentityVerification, PortalStepModel.DocumentSigning],
            RawData1 = true,
        };

        bool expectedActiveAmlSuspicions = false;
        string expectedCallbackURL = "https://example.com/callback";
        string expectedCallbackURLNotification = "https://example.com/notify";
        float expectedFilteringScoreAmlSuspicions = 0.75;
        string expectedLanguage = "fra";
        List<ApiEnum<string, PortalStepModel>> expectedPortalSteps =
        [
            PortalStepModel.IdentityVerification,
            PortalStepModel.DocumentSigning,
        ];
        bool expectedRawData1 = true;

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
        Assert.Equal(expectedRawData1, model.RawData1);
    }
}
