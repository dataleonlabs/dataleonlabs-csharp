using System;
using System.Text.Json;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;
using Dataleonlabs.Models.Individuals.Documents;

namespace Dataleonlabs.Tests.Models.Individuals.Documents;

public class DocumentUploadParamsTest : TestBase
{
    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DocumentUploadParams
        {
            IndividualID = "individual_id",
            DocumentType = DocumentType.LiasseFiscale,
        };

        Assert.Null(parameters.File);
        Assert.False(parameters.RawBodyData.ContainsKey("file"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawBodyData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DocumentUploadParams
        {
            IndividualID = "individual_id",
            DocumentType = DocumentType.LiasseFiscale,

            // Null should be interpreted as omitted for these properties
            File = null,
            UrlValue = null,
        };

        Assert.Null(parameters.File);
        Assert.False(parameters.RawBodyData.ContainsKey("file"));
        Assert.Null(parameters.UrlValue);
        Assert.False(parameters.RawBodyData.ContainsKey("url"));
    }

    [Fact]
    public void Url_Works()
    {
        DocumentUploadParams parameters = new()
        {
            IndividualID = "individual_id",
            DocumentType = DocumentType.LiasseFiscale,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://inference.eu-west-1.dataleon.ai/individuals/individual_id/documents"),
            url
        );
    }
}

public class DocumentTypeTest : TestBase
{
    [Theory]
    [InlineData(DocumentType.LiasseFiscale)]
    [InlineData(DocumentType.AmortisedLoanSchedule)]
    [InlineData(DocumentType.Invoice)]
    [InlineData(DocumentType.Receipt)]
    [InlineData(DocumentType.CompanyStatuts)]
    [InlineData(DocumentType.RegistrationCompanyCertificate)]
    [InlineData(DocumentType.Kbis)]
    [InlineData(DocumentType.Rib)]
    [InlineData(DocumentType.LivretFamille)]
    [InlineData(DocumentType.BirthCertificate)]
    [InlineData(DocumentType.Payslip)]
    [InlineData(DocumentType.SocialSecurityCard)]
    [InlineData(DocumentType.VehicleRegistrationCertificate)]
    [InlineData(DocumentType.CarteGrise)]
    [InlineData(DocumentType.CriminalRecordExtract)]
    [InlineData(DocumentType.ProofOfAddress)]
    [InlineData(DocumentType.IdentityCardFront)]
    [InlineData(DocumentType.IdentityCardBack)]
    [InlineData(DocumentType.DriverLicenseFront)]
    [InlineData(DocumentType.DriverLicenseBack)]
    [InlineData(DocumentType.IdentityDocument)]
    [InlineData(DocumentType.DriverLicense)]
    [InlineData(DocumentType.Passport)]
    [InlineData(DocumentType.Tax)]
    [InlineData(DocumentType.CertificateOfIncorporation)]
    [InlineData(DocumentType.CertificateOfGoodStanding)]
    [InlineData(DocumentType.LcbFtLabAmlPolicies)]
    [InlineData(DocumentType.NiuEntreprise)]
    [InlineData(DocumentType.FinancialStatements)]
    [InlineData(DocumentType.Rccm)]
    [InlineData(DocumentType.ProofOfSourceFunds)]
    [InlineData(DocumentType.OrganizationalChart)]
    [InlineData(DocumentType.RiskPolicies)]
    public void Validation_Works(DocumentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DocumentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DocumentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DataleonlabsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DocumentType.LiasseFiscale)]
    [InlineData(DocumentType.AmortisedLoanSchedule)]
    [InlineData(DocumentType.Invoice)]
    [InlineData(DocumentType.Receipt)]
    [InlineData(DocumentType.CompanyStatuts)]
    [InlineData(DocumentType.RegistrationCompanyCertificate)]
    [InlineData(DocumentType.Kbis)]
    [InlineData(DocumentType.Rib)]
    [InlineData(DocumentType.LivretFamille)]
    [InlineData(DocumentType.BirthCertificate)]
    [InlineData(DocumentType.Payslip)]
    [InlineData(DocumentType.SocialSecurityCard)]
    [InlineData(DocumentType.VehicleRegistrationCertificate)]
    [InlineData(DocumentType.CarteGrise)]
    [InlineData(DocumentType.CriminalRecordExtract)]
    [InlineData(DocumentType.ProofOfAddress)]
    [InlineData(DocumentType.IdentityCardFront)]
    [InlineData(DocumentType.IdentityCardBack)]
    [InlineData(DocumentType.DriverLicenseFront)]
    [InlineData(DocumentType.DriverLicenseBack)]
    [InlineData(DocumentType.IdentityDocument)]
    [InlineData(DocumentType.DriverLicense)]
    [InlineData(DocumentType.Passport)]
    [InlineData(DocumentType.Tax)]
    [InlineData(DocumentType.CertificateOfIncorporation)]
    [InlineData(DocumentType.CertificateOfGoodStanding)]
    [InlineData(DocumentType.LcbFtLabAmlPolicies)]
    [InlineData(DocumentType.NiuEntreprise)]
    [InlineData(DocumentType.FinancialStatements)]
    [InlineData(DocumentType.Rccm)]
    [InlineData(DocumentType.ProofOfSourceFunds)]
    [InlineData(DocumentType.OrganizationalChart)]
    [InlineData(DocumentType.RiskPolicies)]
    public void SerializationRoundtrip_Works(DocumentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DocumentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DocumentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DocumentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DocumentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
