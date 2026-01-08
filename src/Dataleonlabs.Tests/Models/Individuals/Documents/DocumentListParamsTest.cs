using System;
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

    [Fact]
    public void Url_Works()
    {
        DocumentListParams parameters = new() { IndividualID = "individual_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://inference.eu-west-1.dataleon.ai/individuals/individual_id/documents"),
            url
        );
    }
}
