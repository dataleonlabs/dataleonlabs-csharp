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
}
