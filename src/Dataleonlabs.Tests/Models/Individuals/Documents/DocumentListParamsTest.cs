using Dataleonlabs.Models.Individuals.Documents;

namespace Dataleonlabs.Tests.Models.Individuals.Documents;

public class DocumentListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DocumentListParams { IndividualID = "individual_id" };

        string expectedIndividualID = "individual_id";

        Assert.Equal(expectedIndividualID, parameters.IndividualID);
    }
}
