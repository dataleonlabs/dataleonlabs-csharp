using System.Threading.Tasks;
using Dataleonlabs.Models.Individuals.Documents.DocumentUploadParamsProperties;

namespace Dataleonlabs.Tests.Services.Individuals.Documents;

public class DocumentServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var documentResponse = await this.client.Individuals.Documents.List(
            new() { IndividualID = "individual_id" }
        );
        documentResponse.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Upload_Works()
    {
        var genericDocument = await this.client.Individuals.Documents.Upload(
            new() { IndividualID = "individual_id", DocumentType = DocumentType.LiasseFiscale }
        );
        genericDocument.Validate();
    }
}
