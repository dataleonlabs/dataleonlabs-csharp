using System;
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

    [Fact]
    public void Url_Works()
    {
        IndividualDeleteParams parameters = new() { IndividualID = "individual_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://inference.eu-west-1.dataleon.ai/individuals/individual_id"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IndividualDeleteParams { IndividualID = "individual_id" };

        IndividualDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
