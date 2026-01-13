using System.Text.Json;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Companies;

namespace Dataleonlabs.Tests.Models.Companies;

public class PropertyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Property
        {
            Name = "property_name",
            Type = "string",
            Value = "property_value",
        };

        string expectedName = "property_name";
        string expectedType = "string";
        string expectedValue = "property_value";

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Property
        {
            Name = "property_name",
            Type = "string",
            Value = "property_value",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Property>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Property
        {
            Name = "property_name",
            Type = "string",
            Value = "property_value",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Property>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "property_name";
        string expectedType = "string";
        string expectedValue = "property_value";

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Property
        {
            Name = "property_name",
            Type = "string",
            Value = "property_value",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Property { };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Property { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Property
        {
            // Null should be interpreted as omitted for these properties
            Name = null,
            Type = null,
            Value = null,
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Property
        {
            // Null should be interpreted as omitted for these properties
            Name = null,
            Type = null,
            Value = null,
        };

        model.Validate();
    }
}
