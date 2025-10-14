using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Exceptions;

namespace Dataleonlabs.Models.Individuals.IndividualUpdateParamsProperties.TechnicalDataProperties;

[JsonConverter(typeof(PortalStepConverter))]
public enum PortalStep
{
    IdentityVerification,
    DocumentSigning,
    ProofOfAddress,
    Selfie,
    FaceMatch,
}

sealed class PortalStepConverter : JsonConverter<PortalStep>
{
    public override PortalStep Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "identity_verification" => PortalStep.IdentityVerification,
            "document_signing" => PortalStep.DocumentSigning,
            "proof_of_address" => PortalStep.ProofOfAddress,
            "selfie" => PortalStep.Selfie,
            "face_match" => PortalStep.FaceMatch,
            _ => (PortalStep)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortalStep value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PortalStep.IdentityVerification => "identity_verification",
                PortalStep.DocumentSigning => "document_signing",
                PortalStep.ProofOfAddress => "proof_of_address",
                PortalStep.Selfie => "selfie",
                PortalStep.FaceMatch => "face_match",
                _ => throw new DataleonlabsInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
