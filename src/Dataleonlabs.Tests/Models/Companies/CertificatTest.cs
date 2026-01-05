using System;
using System.Text.Json;
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Certificat
        {
            ID = "cert_123",
            CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
            Filename = "certificate.pdf",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Certificat>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Certificat
        {
            ID = "cert_123",
            CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
            Filename = "certificate.pdf",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Certificat>(element);
        Assert.NotNull(deserialized);

        string expectedID = "cert_123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z");
        string expectedFilename = "certificate.pdf";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFilename, deserialized.Filename);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Certificat
        {
            ID = "cert_123",
            CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
            Filename = "certificate.pdf",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Certificat { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Certificat { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Certificat
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Filename = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Certificat
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            Filename = null,
        };

        model.Validate();
    }
}
