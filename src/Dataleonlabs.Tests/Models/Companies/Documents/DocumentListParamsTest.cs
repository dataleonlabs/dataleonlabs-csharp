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
}
