using Dataleonlabs.Models.Individuals;

namespace Dataleonlabs.Tests.Models.Individuals;

public class IndividualRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IndividualRetrieveParams
        {
            IndividualID = "individual_id",
            Document = true,
            Scope = "scope",
        };

        string expectedIndividualID = "individual_id";
        bool expectedDocument = true;
        string expectedScope = "scope";

        Assert.Equal(expectedIndividualID, parameters.IndividualID);
        Assert.Equal(expectedDocument, parameters.Document);
        Assert.Equal(expectedScope, parameters.Scope);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IndividualRetrieveParams { IndividualID = "individual_id" };

        Assert.Null(parameters.Document);
        Assert.False(parameters.RawQueryData.ContainsKey("document"));
        Assert.Null(parameters.Scope);
        Assert.False(parameters.RawQueryData.ContainsKey("scope"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new IndividualRetrieveParams
        {
            IndividualID = "individual_id",

            // Null should be interpreted as omitted for these properties
            Document = null,
            Scope = null,
        };

        Assert.Null(parameters.Document);
        Assert.False(parameters.RawQueryData.ContainsKey("document"));
        Assert.Null(parameters.Scope);
        Assert.False(parameters.RawQueryData.ContainsKey("scope"));
    }
}
