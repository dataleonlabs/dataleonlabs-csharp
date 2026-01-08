using System;
using Dataleonlabs.Models.Companies.Documents;

namespace Dataleonlabs.Tests.Models.Companies.Documents;

public class DocumentListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DocumentListParams { CompanyID = "company_id" };

        string expectedCompanyID = "company_id";

        Assert.Equal(expectedCompanyID, parameters.CompanyID);
    }

    [Fact]
    public void Url_Works()
    {
        DocumentListParams parameters = new() { CompanyID = "company_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://inference.eu-west-1.dataleon.ai/companies/company_id/documents"),
            url
        );
    }
}
