using Dataleonlabs.Core;
using Dataleonlabs.Models.Companies;

namespace Dataleonlabs.Tests.Models.Companies;

public class AmlSuspicionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AmlSuspicion
        {
            Caption = "Suspicious activity",
            Country = "FR",
            Gender = "M",
            Relation = "linked",
            Schema = "v1",
            Score = 0.85,
            Source = "https://aml-checker.example.com/api/v1/suspicion/12345",
            Status = AmlSuspicionStatus.Pending,
            Type = Type.Pep,
        };

        string expectedCaption = "Suspicious activity";
        string expectedCountry = "FR";
        string expectedGender = "M";
        string expectedRelation = "linked";
        string expectedSchema = "v1";
        float expectedScore = 0.85;
        string expectedSource = "https://aml-checker.example.com/api/v1/suspicion/12345";
        ApiEnum<string, AmlSuspicionStatus> expectedStatus = AmlSuspicionStatus.Pending;
        ApiEnum<string, Type> expectedType = Type.Pep;

        Assert.Equal(expectedCaption, model.Caption);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedGender, model.Gender);
        Assert.Equal(expectedRelation, model.Relation);
        Assert.Equal(expectedSchema, model.Schema);
        Assert.Equal(expectedScore, model.Score);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }
}
