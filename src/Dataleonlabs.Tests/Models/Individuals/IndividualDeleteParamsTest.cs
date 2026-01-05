using Dataleonlabs.Models.Individuals;

namespace Dataleonlabs.Tests.Models.Individuals;

public class IndividualDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IndividualDeleteParams { IndividualID = "individual_id" };

        string expectedIndividualID = "individual_id";

        Assert.Equal(expectedIndividualID, parameters.IndividualID);
    }
}
