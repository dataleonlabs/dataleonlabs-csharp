using System;
using Dataleonlabs.Models.Companies;

namespace Dataleonlabs.Tests.Models.Companies;

public class CompanyDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CompanyDeleteParams { CompanyID = "company_id" };

        string expectedCompanyID = "company_id";

        Assert.Equal(expectedCompanyID, parameters.CompanyID);
    }

    [Fact]
    public void Url_Works()
    {
        CompanyDeleteParams parameters = new() { CompanyID = "company_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://inference.eu-west-1.dataleon.ai/companies/company_id"), url);
    }
}
