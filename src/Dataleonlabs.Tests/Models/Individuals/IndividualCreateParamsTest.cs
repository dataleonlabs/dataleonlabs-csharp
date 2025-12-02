using System.Collections.Generic;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Individuals;

namespace Dataleonlabs.Tests.Models.Individuals;

public class PersonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Person
        {
            Birthday = "15/05/1985",
            Email = "john.doe@example.com",
            FirstName = "John",
            Gender = Gender.M,
            LastName = "Doe",
            MaidenName = "John Doe",
            Nationality = "FRA",
            PhoneNumber = "+33 1 23 45 67 89",
        };

        string expectedBirthday = "15/05/1985";
        string expectedEmail = "john.doe@example.com";
        string expectedFirstName = "John";
        ApiEnum<string, Gender> expectedGender = Gender.M;
        string expectedLastName = "Doe";
        string expectedMaidenName = "John Doe";
        string expectedNationality = "FRA";
        string expectedPhoneNumber = "+33 1 23 45 67 89";

        Assert.Equal(expectedBirthday, model.Birthday);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedFirstName, model.FirstName);
        Assert.Equal(expectedGender, model.Gender);
        Assert.Equal(expectedLastName, model.LastName);
        Assert.Equal(expectedMaidenName, model.MaidenName);
        Assert.Equal(expectedNationality, model.Nationality);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
    }
}

public class TechnicalDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TechnicalData
        {
            ActiveAmlSuspicions = false,
            CallbackURL = "https://example.com/callback",
            CallbackURLNotification = "https://example.com/notify",
            FilteringScoreAmlSuspicions = 0.75,
            Language = "fra",
            PortalSteps =
            [
                PortalStep.IdentityVerification,
                PortalStep.Selfie,
                PortalStep.FaceMatch,
            ],
            RawData1 = true,
        };

        bool expectedActiveAmlSuspicions = false;
        string expectedCallbackURL = "https://example.com/callback";
        string expectedCallbackURLNotification = "https://example.com/notify";
        float expectedFilteringScoreAmlSuspicions = 0.75;
        string expectedLanguage = "fra";
        List<ApiEnum<string, PortalStep>> expectedPortalSteps =
        [
            PortalStep.IdentityVerification,
            PortalStep.Selfie,
            PortalStep.FaceMatch,
        ];
        bool expectedRawData1 = true;

        Assert.Equal(expectedActiveAmlSuspicions, model.ActiveAmlSuspicions);
        Assert.Equal(expectedCallbackURL, model.CallbackURL);
        Assert.Equal(expectedCallbackURLNotification, model.CallbackURLNotification);
        Assert.Equal(expectedFilteringScoreAmlSuspicions, model.FilteringScoreAmlSuspicions);
        Assert.Equal(expectedLanguage, model.Language);
        Assert.Equal(expectedPortalSteps.Count, model.PortalSteps.Count);
        for (int i = 0; i < expectedPortalSteps.Count; i++)
        {
            Assert.Equal(expectedPortalSteps[i], model.PortalSteps[i]);
        }
        Assert.Equal(expectedRawData1, model.RawData1);
    }
}
