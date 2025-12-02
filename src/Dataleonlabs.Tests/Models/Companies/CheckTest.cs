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
            Validate1 = true,
            Weight = 1,
        };

        bool expectedMasked = false;
        string expectedMessage = "Name matched successfully";
        string expectedName = "name_match";
        bool expectedValidate1 = true;
        long expectedWeight = 1;

        Assert.Equal(expectedMasked, model.Masked);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedValidate1, model.Validate1);
        Assert.Equal(expectedWeight, model.Weight);
    }
}
