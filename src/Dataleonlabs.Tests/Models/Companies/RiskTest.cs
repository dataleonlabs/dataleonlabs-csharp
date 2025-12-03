using System.Text.Json;
using Dataleonlabs.Models.Companies;

namespace Dataleonlabs.Tests.Models.Companies;

public class RiskTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Risk
        {
            Code = "20030",
            Reason = "Document mismatch",
            Score = 0.92,
        };

        string expectedCode = "20030";
        string expectedReason = "Document mismatch";
        float expectedScore = 0.92;

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedScore, model.Score);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Risk
        {
            Code = "20030",
            Reason = "Document mismatch",
            Score = 0.92,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Risk>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Risk
        {
            Code = "20030",
            Reason = "Document mismatch",
            Score = 0.92,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Risk>(json);
        Assert.NotNull(deserialized);

        string expectedCode = "20030";
        string expectedReason = "Document mismatch";
        float expectedScore = 0.92;

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedScore, deserialized.Score);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Risk
        {
            Code = "20030",
            Reason = "Document mismatch",
            Score = 0.92,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Risk { };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Risk { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Risk
        {
            // Null should be interpreted as omitted for these properties
            Code = null,
            Reason = null,
            Score = null,
        };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Risk
        {
            // Null should be interpreted as omitted for these properties
            Code = null,
            Reason = null,
            Score = null,
        };

        model.Validate();
    }
}
