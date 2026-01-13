using System.Text.Json;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Companies;

namespace Dataleonlabs.Tests.Models.Companies;

public class CheckTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Check
        {
            Masked = false,
            Message = "Name matched successfully",
            Name = "name_match",
            ValidateValue = true,
            Weight = 1,
        };

        bool expectedMasked = false;
        string expectedMessage = "Name matched successfully";
        string expectedName = "name_match";
        bool expectedValidateValue = true;
        long expectedWeight = 1;

        Assert.Equal(expectedMasked, model.Masked);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedValidateValue, model.ValidateValue);
        Assert.Equal(expectedWeight, model.Weight);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Check
        {
            Masked = false,
            Message = "Name matched successfully",
            Name = "name_match",
            ValidateValue = true,
            Weight = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Check>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Check
        {
            Masked = false,
            Message = "Name matched successfully",
            Name = "name_match",
            ValidateValue = true,
            Weight = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Check>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        bool expectedMasked = false;
        string expectedMessage = "Name matched successfully";
        string expectedName = "name_match";
        bool expectedValidateValue = true;
        long expectedWeight = 1;

        Assert.Equal(expectedMasked, deserialized.Masked);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedValidateValue, deserialized.ValidateValue);
        Assert.Equal(expectedWeight, deserialized.Weight);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Check
        {
            Masked = false,
            Message = "Name matched successfully",
            Name = "name_match",
            ValidateValue = true,
            Weight = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Check { };

        Assert.Null(model.Masked);
        Assert.False(model.RawData.ContainsKey("masked"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.ValidateValue);
        Assert.False(model.RawData.ContainsKey("validate"));
        Assert.Null(model.Weight);
        Assert.False(model.RawData.ContainsKey("weight"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Check { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Check
        {
            // Null should be interpreted as omitted for these properties
            Masked = null,
            Message = null,
            Name = null,
            ValidateValue = null,
            Weight = null,
        };

        Assert.Null(model.Masked);
        Assert.False(model.RawData.ContainsKey("masked"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.ValidateValue);
        Assert.False(model.RawData.ContainsKey("validate"));
        Assert.Null(model.Weight);
        Assert.False(model.RawData.ContainsKey("weight"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Check
        {
            // Null should be interpreted as omitted for these properties
            Masked = null,
            Message = null,
            Name = null,
            ValidateValue = null,
            Weight = null,
        };

        model.Validate();
    }
}
