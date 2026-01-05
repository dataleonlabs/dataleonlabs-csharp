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
}
