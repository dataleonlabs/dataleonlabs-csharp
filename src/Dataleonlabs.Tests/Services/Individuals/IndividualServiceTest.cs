using System.Threading.Tasks;

namespace Dataleonlabs.Tests.Services.Individuals;

public class IndividualServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var individual = await this.client.Individuals.Create(new() { WorkspaceID = "wk_123" });
        individual.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var individual = await this.client.Individuals.Retrieve(
            new() { IndividualID = "individual_id" }
        );
        individual.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var individual = await this.client.Individuals.Update(
            new() { IndividualID = "individual_id", WorkspaceID = "wk_123" }
        );
        individual.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var individuals = await this.client.Individuals.List();
        foreach (var item in individuals)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Individuals.Delete(new() { IndividualID = "individual_id" });
    }
}
