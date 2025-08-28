using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dataleonlabs.Models.Companies.Documents.DocumentUploadParamsProperties;

/// <summary>
/// Filter by document type for upload (must be one of the allowed values)
/// </summary>
[JsonConverter(typeof(DocumentTypeConverter))]
public enum DocumentType
{
    LiasseFiscale,
    AmortisedLoanSchedule,
    Invoice,
    Receipt,
    CompanyStatuts,
    RegistrationCompanyCertificate,
    Kbis,
    Rib,
    LivretFamille,
    BirthCertificate,
    Payslip,
    SocialSecurityCard,
    VehicleRegistrationCertificate,
    CarteGrise,
    CriminalRecordExtract,
    ProofOfAddress,
    IdentityCardFront,
    IdentityCardBack,
    DriverLicenseFront,
    DriverLicenseBack,
    IdentityDocument,
    DriverLicense,
    Passport,
    Tax,
    CertificateOfIncorporation,
    CertificateOfGoodStanding,
    LcbFtLabAmlPolicies,
    NiuEntreprise,
    FinancialStatements,
    Rccm,
    ProofOfSourceFunds,
    OrganizationalChart,
    RiskPolicies,
}

sealed class DocumentTypeConverter : JsonConverter<DocumentType>
{
    public override DocumentType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "liasse_fiscale" => DocumentType.LiasseFiscale,
            "amortised_loan_schedule" => DocumentType.AmortisedLoanSchedule,
            "invoice" => DocumentType.Invoice,
            "receipt" => DocumentType.Receipt,
            "company_statuts" => DocumentType.CompanyStatuts,
            "registration_company_certificate" => DocumentType.RegistrationCompanyCertificate,
            "kbis" => DocumentType.Kbis,
            "rib" => DocumentType.Rib,
            "livret_famille" => DocumentType.LivretFamille,
            "birth_certificate" => DocumentType.BirthCertificate,
            "payslip" => DocumentType.Payslip,
            "social_security_card" => DocumentType.SocialSecurityCard,
            "vehicle_registration_certificate" => DocumentType.VehicleRegistrationCertificate,
            "carte_grise" => DocumentType.CarteGrise,
            "criminal_record_extract" => DocumentType.CriminalRecordExtract,
            "proof_of_address" => DocumentType.ProofOfAddress,
            "identity_card_front" => DocumentType.IdentityCardFront,
            "identity_card_back" => DocumentType.IdentityCardBack,
            "driver_license_front" => DocumentType.DriverLicenseFront,
            "driver_license_back" => DocumentType.DriverLicenseBack,
            "identity_document" => DocumentType.IdentityDocument,
            "driver_license" => DocumentType.DriverLicense,
            "passport" => DocumentType.Passport,
            "tax" => DocumentType.Tax,
            "certificate_of_incorporation" => DocumentType.CertificateOfIncorporation,
            "certificate_of_good_standing" => DocumentType.CertificateOfGoodStanding,
            "lcb_ft_lab_aml_policies" => DocumentType.LcbFtLabAmlPolicies,
            "niu_entreprise" => DocumentType.NiuEntreprise,
            "financial_statements" => DocumentType.FinancialStatements,
            "rccm" => DocumentType.Rccm,
            "proof_of_source_funds" => DocumentType.ProofOfSourceFunds,
            "organizational_chart" => DocumentType.OrganizationalChart,
            "risk_policies" => DocumentType.RiskPolicies,
            _ => (DocumentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DocumentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DocumentType.LiasseFiscale => "liasse_fiscale",
                DocumentType.AmortisedLoanSchedule => "amortised_loan_schedule",
                DocumentType.Invoice => "invoice",
                DocumentType.Receipt => "receipt",
                DocumentType.CompanyStatuts => "company_statuts",
                DocumentType.RegistrationCompanyCertificate => "registration_company_certificate",
                DocumentType.Kbis => "kbis",
                DocumentType.Rib => "rib",
                DocumentType.LivretFamille => "livret_famille",
                DocumentType.BirthCertificate => "birth_certificate",
                DocumentType.Payslip => "payslip",
                DocumentType.SocialSecurityCard => "social_security_card",
                DocumentType.VehicleRegistrationCertificate => "vehicle_registration_certificate",
                DocumentType.CarteGrise => "carte_grise",
                DocumentType.CriminalRecordExtract => "criminal_record_extract",
                DocumentType.ProofOfAddress => "proof_of_address",
                DocumentType.IdentityCardFront => "identity_card_front",
                DocumentType.IdentityCardBack => "identity_card_back",
                DocumentType.DriverLicenseFront => "driver_license_front",
                DocumentType.DriverLicenseBack => "driver_license_back",
                DocumentType.IdentityDocument => "identity_document",
                DocumentType.DriverLicense => "driver_license",
                DocumentType.Passport => "passport",
                DocumentType.Tax => "tax",
                DocumentType.CertificateOfIncorporation => "certificate_of_incorporation",
                DocumentType.CertificateOfGoodStanding => "certificate_of_good_standing",
                DocumentType.LcbFtLabAmlPolicies => "lcb_ft_lab_aml_policies",
                DocumentType.NiuEntreprise => "niu_entreprise",
                DocumentType.FinancialStatements => "financial_statements",
                DocumentType.Rccm => "rccm",
                DocumentType.ProofOfSourceFunds => "proof_of_source_funds",
                DocumentType.OrganizationalChart => "organizational_chart",
                DocumentType.RiskPolicies => "risk_policies",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
