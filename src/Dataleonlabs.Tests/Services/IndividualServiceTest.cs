using System.Threading.Tasks;

namespace Dataleonlabs.Tests.Services;

public class IndividualServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var individual = await this.client.Individuals.Create(
            new() { WorkspaceID = "wk_123" },
            TestContext.Current.CancellationToken
        );
        individual.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var individual = await this.client.Individuals.Retrieve(
            "individual_id",
            new(),
            TestContext.Current.CancellationToken
        );
        individual.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var individual = await this.client.Individuals.Update(
            "individual_id",
            new() { WorkspaceID = "wk_123" },
            TestContext.Current.CancellationToken
        );
        individual.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var individuals = await this.client.Individuals.List(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in individuals)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Individuals.Delete(
            "individual_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
