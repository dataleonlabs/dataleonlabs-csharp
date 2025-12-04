using System.Collections.Generic;
using System.Text.Json;
using Dataleonlabs.Core;
using Dataleonlabs.Models.Individuals;

namespace Dataleonlabs.Tests.Models.Individuals;

public class IndividualUpdateParamsPersonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IndividualUpdateParamsPerson
        {
            Birthday = "15/05/1985",
            Email = "john.doe@example.com",
            FirstName = "John",
            Gender = IndividualUpdateParamsPersonGender.M,
            LastName = "Doe",
            MaidenName = "John Doe",
            Nationality = "FRA",
            PhoneNumber = "+33 1 23 45 67 89",
        };

        string expectedBirthday = "15/05/1985";
        string expectedEmail = "john.doe@example.com";
        string expectedFirstName = "John";
        ApiEnum<string, IndividualUpdateParamsPersonGender> expectedGender =
            IndividualUpdateParamsPersonGender.M;
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IndividualUpdateParamsPerson
        {
            Birthday = "15/05/1985",
            Email = "john.doe@example.com",
            FirstName = "John",
            Gender = IndividualUpdateParamsPersonGender.M,
            LastName = "Doe",
            MaidenName = "John Doe",
            Nationality = "FRA",
            PhoneNumber = "+33 1 23 45 67 89",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<IndividualUpdateParamsPerson>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IndividualUpdateParamsPerson
        {
            Birthday = "15/05/1985",
            Email = "john.doe@example.com",
            FirstName = "John",
            Gender = IndividualUpdateParamsPersonGender.M,
            LastName = "Doe",
            MaidenName = "John Doe",
            Nationality = "FRA",
            PhoneNumber = "+33 1 23 45 67 89",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<IndividualUpdateParamsPerson>(json);
        Assert.NotNull(deserialized);

        string expectedBirthday = "15/05/1985";
        string expectedEmail = "john.doe@example.com";
        string expectedFirstName = "John";
        ApiEnum<string, IndividualUpdateParamsPersonGender> expectedGender =
            IndividualUpdateParamsPersonGender.M;
        string expectedLastName = "Doe";
        string expectedMaidenName = "John Doe";
        string expectedNationality = "FRA";
        string expectedPhoneNumber = "+33 1 23 45 67 89";

        Assert.Equal(expectedBirthday, deserialized.Birthday);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedFirstName, deserialized.FirstName);
        Assert.Equal(expectedGender, deserialized.Gender);
        Assert.Equal(expectedLastName, deserialized.LastName);
        Assert.Equal(expectedMaidenName, deserialized.MaidenName);
        Assert.Equal(expectedNationality, deserialized.Nationality);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IndividualUpdateParamsPerson
        {
            Birthday = "15/05/1985",
            Email = "john.doe@example.com",
            FirstName = "John",
            Gender = IndividualUpdateParamsPersonGender.M,
            LastName = "Doe",
            MaidenName = "John Doe",
            Nationality = "FRA",
            PhoneNumber = "+33 1 23 45 67 89",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new IndividualUpdateParamsPerson { };

        Assert.Null(model.Birthday);
        Assert.False(model.RawData.ContainsKey("birthday"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.FirstName);
        Assert.False(model.RawData.ContainsKey("first_name"));
        Assert.Null(model.Gender);
        Assert.False(model.RawData.ContainsKey("gender"));
        Assert.Null(model.LastName);
        Assert.False(model.RawData.ContainsKey("last_name"));
        Assert.Null(model.MaidenName);
        Assert.False(model.RawData.ContainsKey("maiden_name"));
        Assert.Null(model.Nationality);
        Assert.False(model.RawData.ContainsKey("nationality"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new IndividualUpdateParamsPerson { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new IndividualUpdateParamsPerson
        {
            // Null should be interpreted as omitted for these properties
            Birthday = null,
            Email = null,
            FirstName = null,
            Gender = null,
            LastName = null,
            MaidenName = null,
            Nationality = null,
            PhoneNumber = null,
        };

        Assert.Null(model.Birthday);
        Assert.False(model.RawData.ContainsKey("birthday"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.FirstName);
        Assert.False(model.RawData.ContainsKey("first_name"));
        Assert.Null(model.Gender);
        Assert.False(model.RawData.ContainsKey("gender"));
        Assert.Null(model.LastName);
        Assert.False(model.RawData.ContainsKey("last_name"));
        Assert.Null(model.MaidenName);
        Assert.False(model.RawData.ContainsKey("maiden_name"));
        Assert.Null(model.Nationality);
        Assert.False(model.RawData.ContainsKey("nationality"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new IndividualUpdateParamsPerson
        {
            // Null should be interpreted as omitted for these properties
            Birthday = null,
            Email = null,
            FirstName = null,
            Gender = null,
            LastName = null,
            MaidenName = null,
            Nationality = null,
            PhoneNumber = null,
        };

        model.Validate();
    }
}

public class IndividualUpdateParamsTechnicalDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IndividualUpdateParamsTechnicalData
        {
            ActiveAmlSuspicions = false,
            CallbackURL = "https://example.com/callback",
            CallbackURLNotification = "https://example.com/notify",
            FilteringScoreAmlSuspicions = 0.75,
            Language = "fra",
            PortalSteps =
            [
                IndividualUpdateParamsTechnicalDataPortalStep.IdentityVerification,
                IndividualUpdateParamsTechnicalDataPortalStep.Selfie,
                IndividualUpdateParamsTechnicalDataPortalStep.FaceMatch,
            ],
            RawDataValue = true,
        };

        bool expectedActiveAmlSuspicions = false;
        string expectedCallbackURL = "https://example.com/callback";
        string expectedCallbackURLNotification = "https://example.com/notify";
        float expectedFilteringScoreAmlSuspicions = 0.75;
        string expectedLanguage = "fra";
        List<ApiEnum<string, IndividualUpdateParamsTechnicalDataPortalStep>> expectedPortalSteps =
        [
            IndividualUpdateParamsTechnicalDataPortalStep.IdentityVerification,
            IndividualUpdateParamsTechnicalDataPortalStep.Selfie,
            IndividualUpdateParamsTechnicalDataPortalStep.FaceMatch,
        ];
        bool expectedRawDataValue = true;

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
        Assert.Equal(expectedRawDataValue, model.RawDataValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IndividualUpdateParamsTechnicalData
        {
            ActiveAmlSuspicions = false,
            CallbackURL = "https://example.com/callback",
            CallbackURLNotification = "https://example.com/notify",
            FilteringScoreAmlSuspicions = 0.75,
            Language = "fra",
            PortalSteps =
            [
                IndividualUpdateParamsTechnicalDataPortalStep.IdentityVerification,
                IndividualUpdateParamsTechnicalDataPortalStep.Selfie,
                IndividualUpdateParamsTechnicalDataPortalStep.FaceMatch,
            ],
            RawDataValue = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<IndividualUpdateParamsTechnicalData>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IndividualUpdateParamsTechnicalData
        {
            ActiveAmlSuspicions = false,
            CallbackURL = "https://example.com/callback",
            CallbackURLNotification = "https://example.com/notify",
            FilteringScoreAmlSuspicions = 0.75,
            Language = "fra",
            PortalSteps =
            [
                IndividualUpdateParamsTechnicalDataPortalStep.IdentityVerification,
                IndividualUpdateParamsTechnicalDataPortalStep.Selfie,
                IndividualUpdateParamsTechnicalDataPortalStep.FaceMatch,
            ],
            RawDataValue = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<IndividualUpdateParamsTechnicalData>(json);
        Assert.NotNull(deserialized);

        bool expectedActiveAmlSuspicions = false;
        string expectedCallbackURL = "https://example.com/callback";
        string expectedCallbackURLNotification = "https://example.com/notify";
        float expectedFilteringScoreAmlSuspicions = 0.75;
        string expectedLanguage = "fra";
        List<ApiEnum<string, IndividualUpdateParamsTechnicalDataPortalStep>> expectedPortalSteps =
        [
            IndividualUpdateParamsTechnicalDataPortalStep.IdentityVerification,
            IndividualUpdateParamsTechnicalDataPortalStep.Selfie,
            IndividualUpdateParamsTechnicalDataPortalStep.FaceMatch,
        ];
        bool expectedRawDataValue = true;

        Assert.Equal(expectedActiveAmlSuspicions, deserialized.ActiveAmlSuspicions);
        Assert.Equal(expectedCallbackURL, deserialized.CallbackURL);
        Assert.Equal(expectedCallbackURLNotification, deserialized.CallbackURLNotification);
        Assert.Equal(expectedFilteringScoreAmlSuspicions, deserialized.FilteringScoreAmlSuspicions);
        Assert.Equal(expectedLanguage, deserialized.Language);
        Assert.Equal(expectedPortalSteps.Count, deserialized.PortalSteps.Count);
        for (int i = 0; i < expectedPortalSteps.Count; i++)
        {
            Assert.Equal(expectedPortalSteps[i], deserialized.PortalSteps[i]);
        }
        Assert.Equal(expectedRawDataValue, deserialized.RawDataValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IndividualUpdateParamsTechnicalData
        {
            ActiveAmlSuspicions = false,
            CallbackURL = "https://example.com/callback",
            CallbackURLNotification = "https://example.com/notify",
            FilteringScoreAmlSuspicions = 0.75,
            Language = "fra",
            PortalSteps =
            [
                IndividualUpdateParamsTechnicalDataPortalStep.IdentityVerification,
                IndividualUpdateParamsTechnicalDataPortalStep.Selfie,
                IndividualUpdateParamsTechnicalDataPortalStep.FaceMatch,
            ],
            RawDataValue = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new IndividualUpdateParamsTechnicalData { };

        Assert.Null(model.ActiveAmlSuspicions);
        Assert.False(model.RawData.ContainsKey("active_aml_suspicions"));
        Assert.Null(model.CallbackURL);
        Assert.False(model.RawData.ContainsKey("callback_url"));
        Assert.Null(model.CallbackURLNotification);
        Assert.False(model.RawData.ContainsKey("callback_url_notification"));
        Assert.Null(model.FilteringScoreAmlSuspicions);
        Assert.False(model.RawData.ContainsKey("filtering_score_aml_suspicions"));
        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
        Assert.Null(model.PortalSteps);
        Assert.False(model.RawData.ContainsKey("portal_steps"));
        Assert.Null(model.RawDataValue);
        Assert.False(model.RawData.ContainsKey("raw_data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new IndividualUpdateParamsTechnicalData { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new IndividualUpdateParamsTechnicalData
        {
            // Null should be interpreted as omitted for these properties
            ActiveAmlSuspicions = null,
            CallbackURL = null,
            CallbackURLNotification = null,
            FilteringScoreAmlSuspicions = null,
            Language = null,
            PortalSteps = null,
            RawDataValue = null,
        };

        Assert.Null(model.ActiveAmlSuspicions);
        Assert.False(model.RawData.ContainsKey("active_aml_suspicions"));
        Assert.Null(model.CallbackURL);
        Assert.False(model.RawData.ContainsKey("callback_url"));
        Assert.Null(model.CallbackURLNotification);
        Assert.False(model.RawData.ContainsKey("callback_url_notification"));
        Assert.Null(model.FilteringScoreAmlSuspicions);
        Assert.False(model.RawData.ContainsKey("filtering_score_aml_suspicions"));
        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
        Assert.Null(model.PortalSteps);
        Assert.False(model.RawData.ContainsKey("portal_steps"));
        Assert.Null(model.RawDataValue);
        Assert.False(model.RawData.ContainsKey("raw_data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new IndividualUpdateParamsTechnicalData
        {
            // Null should be interpreted as omitted for these properties
            ActiveAmlSuspicions = null,
            CallbackURL = null,
            CallbackURLNotification = null,
            FilteringScoreAmlSuspicions = null,
            Language = null,
            PortalSteps = null,
            RawDataValue = null,
        };

        model.Validate();
    }
}
