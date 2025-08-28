using System.Threading.Tasks;
using Dataleonlabs.Models.Companies.Documents.DocumentUploadParamsProperties;

namespace Dataleonlabs.Tests.Services.Companies.Documents;

public class DocumentServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var documentResponse = await this.client.Companies.Documents.List(
            new() { CompanyID = "company_id" }
        );
        documentResponse.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Upload_Works()
    {
        var genericDocument = await this.client.Companies.Documents.Upload(
            new() { CompanyID = "company_id", DocumentType = DocumentType.LiasseFiscale }
        );
        genericDocument.Validate();
    }
}
