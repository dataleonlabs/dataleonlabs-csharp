using System;
using Dataleonlabs.Models.Companies;

namespace Dataleonlabs.Tests.Models.Companies;

public class CompanyRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CompanyRetrieveParams
        {
            CompanyID = "company_id",
            Document = true,
            Scope = "scope",
        };

        string expectedCompanyID = "company_id";
        bool expectedDocument = true;
        string expectedScope = "scope";

        Assert.Equal(expectedCompanyID, parameters.CompanyID);
        Assert.Equal(expectedDocument, parameters.Document);
        Assert.Equal(expectedScope, parameters.Scope);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CompanyRetrieveParams { CompanyID = "company_id" };

        Assert.Null(parameters.Document);
        Assert.False(parameters.RawQueryData.ContainsKey("document"));
        Assert.Null(parameters.Scope);
        Assert.False(parameters.RawQueryData.ContainsKey("scope"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CompanyRetrieveParams
        {
            CompanyID = "company_id",

            // Null should be interpreted as omitted for these properties
            Document = null,
            Scope = null,
        };

        Assert.Null(parameters.Document);
        Assert.False(parameters.RawQueryData.ContainsKey("document"));
        Assert.Null(parameters.Scope);
        Assert.False(parameters.RawQueryData.ContainsKey("scope"));
    }

    [Fact]
    public void Url_Works()
    {
        CompanyRetrieveParams parameters = new()
        {
            CompanyID = "company_id",
            Document = true,
            Scope = "scope",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://inference.eu-west-1.dataleon.ai/companies/company_id?document=true&scope=scope"
            ),
            url
        );
    }
}
