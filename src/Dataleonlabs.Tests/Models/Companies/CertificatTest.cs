using System;
using Dataleonlabs.Models.Companies;

namespace Dataleonlabs.Tests.Models.Companies;

public class CertificatTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Certificat
        {
            ID = "cert_123",
            CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
            Filename = "certificate.pdf",
        };

        string expectedID = "cert_123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z");
        string expectedFilename = "certificate.pdf";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFilename, model.Filename);
    }
}
