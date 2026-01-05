using System.Threading.Tasks;
using Dataleonlabs.Models.Individuals.Documents;

namespace Dataleonlabs.Tests.Services.Individuals;

public class DocumentServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var documentResponse = await this.client.Individuals.Documents.List(
            "individual_id",
            new(),
            TestContext.Current.CancellationToken
        );
        documentResponse.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Upload_Works()
    {
        var genericDocument = await this.client.Individuals.Documents.Upload(
            "individual_id",
            new() { DocumentType = DocumentType.LiasseFiscale },
            TestContext.Current.CancellationToken
        );
        genericDocument.Validate();
    }
}
