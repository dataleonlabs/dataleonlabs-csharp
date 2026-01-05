using System.Threading.Tasks;
using Dataleonlabs.Models.Companies.Documents;

namespace Dataleonlabs.Tests.Services.Companies;

public class DocumentServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var documentResponse = await this.client.Companies.Documents.List(
            "company_id",
            new(),
            TestContext.Current.CancellationToken
        );
        documentResponse.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Upload_Works()
    {
        var genericDocument = await this.client.Companies.Documents.Upload(
            "company_id",
            new() { DocumentType = DocumentType.LiasseFiscale },
            TestContext.Current.CancellationToken
        );
        genericDocument.Validate();
    }
}
