using Dataleonlabs.Models.Companies;

namespace Dataleonlabs.Tests.Models.Companies;

public class RiskTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Risk
        {
            Code = "20030",
            Reason = "Document mismatch",
            Score = 0.92,
        };

        string expectedCode = "20030";
        string expectedReason = "Document mismatch";
        float expectedScore = 0.92;

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedScore, model.Score);
    }
}
