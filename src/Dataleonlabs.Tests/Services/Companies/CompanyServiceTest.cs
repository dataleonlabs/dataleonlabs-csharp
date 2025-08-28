using System.Threading.Tasks;

namespace Dataleonlabs.Tests.Services.Companies;

public class CompanyServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var company = await this.client.Companies.Create(
            new()
            {
                Company = new()
                {
                    Name = "ACME Corp",
                    Address = "123 rue Exemple, Paris",
                    CommercialName = "ACME",
                    Country = "FR",
                    Email = "info@acme.fr",
                    EmployerIdentificationNumber = "EIN123456",
                    LegalForm = "SARL",
                    PhoneNumber = "+33 1 23 45 67 89",
                    RegistrationDate = "2010-05-15",
                    RegistrationID = "RCS123456",
                    ShareCapital = "100000",
                    Status = "active",
                    TaxIdentificationNumber = "FR123456789",
                    Type = "main",
                    WebsiteURL = "https://acme.fr",
                },
                WorkspaceID = "wk_123",
            }
        );
        company.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var company = await this.client.Companies.Retrieve(new() { CompanyID = "company_id" });
        company.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var company = await this.client.Companies.Update(
            new()
            {
                CompanyID = "company_id",
                Company = new()
                {
                    Name = "ACME Corp",
                    Address = "123 rue Exemple, Paris",
                    CommercialName = "ACME",
                    Country = "FR",
                    Email = "info@acme.fr",
                    EmployerIdentificationNumber = "EIN123456",
                    LegalForm = "SARL",
                    PhoneNumber = "+33 1 23 45 67 89",
                    RegistrationDate = "2010-05-15",
                    RegistrationID = "RCS123456",
                    ShareCapital = "100000",
                    Status = "active",
                    TaxIdentificationNumber = "FR123456789",
                    Type = "main",
                    WebsiteURL = "https://acme.fr",
                },
                WorkspaceID = "wk_123",
            }
        );
        company.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var companies = await this.client.Companies.List();
        foreach (var item in companies)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Companies.Delete(new() { CompanyID = "company_id" });
    }
}
