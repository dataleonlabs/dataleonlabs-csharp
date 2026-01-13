using System;
using System.Collections.Generic;
using System.Text.Json;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;
using Dataleonlabs.Models.Individuals;

namespace Dataleonlabs.Tests.Models.Individuals;

public class IndividualUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IndividualUpdateParams
        {
            IndividualID = "individual_id",
            WorkspaceID = "wk_123",
            Person = new()
            {
                Birthday = "15/05/1985",
                Email = "john.doe@example.com",
                FirstName = "John",
                Gender = IndividualUpdateParamsPersonGender.M,
                LastName = "Doe",
                MaidenName = "John Doe",
                Nationality = "FRA",
                PhoneNumber = "+33 1 23 45 67 89",
            },
            SourceID = "ID54410069066",
            TechnicalData = new()
            {
                ActiveAmlSuspicions = false,
                CallbackUrl = "https://example.com/callback",
                CallbackUrlNotification = "https://example.com/notify",
                FilteringScoreAmlSuspicions = 0.75f,
                Language = "fra",
                PortalSteps =
                [
                    IndividualUpdateParamsTechnicalDataPortalStep.IdentityVerification,
                    IndividualUpdateParamsTechnicalDataPortalStep.Selfie,
                    IndividualUpdateParamsTechnicalDataPortalStep.FaceMatch,
                ],
                RawDataValue = true,
            },
        };

        string expectedIndividualID = "individual_id";
        string expectedWorkspaceID = "wk_123";
        IndividualUpdateParamsPerson expectedPerson = new()
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
        string expectedSourceID = "ID54410069066";
        IndividualUpdateParamsTechnicalData expectedTechnicalData = new()
        {
            ActiveAmlSuspicions = false,
            CallbackUrl = "https://example.com/callback",
            CallbackUrlNotification = "https://example.com/notify",
            FilteringScoreAmlSuspicions = 0.75f,
            Language = "fra",
            PortalSteps =
            [
                IndividualUpdateParamsTechnicalDataPortalStep.IdentityVerification,
                IndividualUpdateParamsTechnicalDataPortalStep.Selfie,
                IndividualUpdateParamsTechnicalDataPortalStep.FaceMatch,
            ],
            RawDataValue = true,
        };

        Assert.Equal(expectedIndividualID, parameters.IndividualID);
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
        Assert.Equal(expectedPerson, parameters.Person);
        Assert.Equal(expectedSourceID, parameters.SourceID);
        Assert.Equal(expectedTechnicalData, parameters.TechnicalData);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IndividualUpdateParams
        {
            IndividualID = "individual_id",
            WorkspaceID = "wk_123",
        };

        Assert.Null(parameters.Person);
        Assert.False(parameters.RawBodyData.ContainsKey("person"));
        Assert.Null(parameters.SourceID);
        Assert.False(parameters.RawBodyData.ContainsKey("source_id"));
        Assert.Null(parameters.TechnicalData);
        Assert.False(parameters.RawBodyData.ContainsKey("technical_data"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new IndividualUpdateParams
        {
            IndividualID = "individual_id",
            WorkspaceID = "wk_123",

            // Null should be interpreted as omitted for these properties
            Person = null,
            SourceID = null,
            TechnicalData = null,
        };

        Assert.Null(parameters.Person);
        Assert.False(parameters.RawBodyData.ContainsKey("person"));
        Assert.Null(parameters.SourceID);
        Assert.False(parameters.RawBodyData.ContainsKey("source_id"));
        Assert.Null(parameters.TechnicalData);
        Assert.False(parameters.RawBodyData.ContainsKey("technical_data"));
    }

    [Fact]
    public void Url_Works()
    {
        IndividualUpdateParams parameters = new()
        {
            IndividualID = "individual_id",
            WorkspaceID = "wk_123",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://inference.eu-west-1.dataleon.ai/individuals/individual_id"),
            url
        );
    }
}

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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IndividualUpdateParamsPerson>(
            json,
            ModelBase.SerializerOptions
        );

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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IndividualUpdateParamsPerson>(
            element,
            ModelBase.SerializerOptions
        );
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

public class IndividualUpdateParamsPersonGenderTest : TestBase
{
    [Theory]
    [InlineData(IndividualUpdateParamsPersonGender.M)]
    [InlineData(IndividualUpdateParamsPersonGender.F)]
    public void Validation_Works(IndividualUpdateParamsPersonGender rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IndividualUpdateParamsPersonGender> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IndividualUpdateParamsPersonGender>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DataleonlabsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IndividualUpdateParamsPersonGender.M)]
    [InlineData(IndividualUpdateParamsPersonGender.F)]
    public void SerializationRoundtrip_Works(IndividualUpdateParamsPersonGender rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IndividualUpdateParamsPersonGender> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IndividualUpdateParamsPersonGender>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IndividualUpdateParamsPersonGender>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IndividualUpdateParamsPersonGender>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
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
            CallbackUrl = "https://example.com/callback",
            CallbackUrlNotification = "https://example.com/notify",
            FilteringScoreAmlSuspicions = 0.75f,
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
        string expectedCallbackUrl = "https://example.com/callback";
        string expectedCallbackUrlNotification = "https://example.com/notify";
        float expectedFilteringScoreAmlSuspicions = 0.75f;
        string expectedLanguage = "fra";
        List<ApiEnum<string, IndividualUpdateParamsTechnicalDataPortalStep>> expectedPortalSteps =
        [
            IndividualUpdateParamsTechnicalDataPortalStep.IdentityVerification,
            IndividualUpdateParamsTechnicalDataPortalStep.Selfie,
            IndividualUpdateParamsTechnicalDataPortalStep.FaceMatch,
        ];
        bool expectedRawDataValue = true;

        Assert.Equal(expectedActiveAmlSuspicions, model.ActiveAmlSuspicions);
        Assert.Equal(expectedCallbackUrl, model.CallbackUrl);
        Assert.Equal(expectedCallbackUrlNotification, model.CallbackUrlNotification);
        Assert.Equal(expectedFilteringScoreAmlSuspicions, model.FilteringScoreAmlSuspicions);
        Assert.Equal(expectedLanguage, model.Language);
        Assert.NotNull(model.PortalSteps);
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
            CallbackUrl = "https://example.com/callback",
            CallbackUrlNotification = "https://example.com/notify",
            FilteringScoreAmlSuspicions = 0.75f,
            Language = "fra",
            PortalSteps =
            [
                IndividualUpdateParamsTechnicalDataPortalStep.IdentityVerification,
                IndividualUpdateParamsTechnicalDataPortalStep.Selfie,
                IndividualUpdateParamsTechnicalDataPortalStep.FaceMatch,
            ],
            RawDataValue = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IndividualUpdateParamsTechnicalData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IndividualUpdateParamsTechnicalData
        {
            ActiveAmlSuspicions = false,
            CallbackUrl = "https://example.com/callback",
            CallbackUrlNotification = "https://example.com/notify",
            FilteringScoreAmlSuspicions = 0.75f,
            Language = "fra",
            PortalSteps =
            [
                IndividualUpdateParamsTechnicalDataPortalStep.IdentityVerification,
                IndividualUpdateParamsTechnicalDataPortalStep.Selfie,
                IndividualUpdateParamsTechnicalDataPortalStep.FaceMatch,
            ],
            RawDataValue = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IndividualUpdateParamsTechnicalData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedActiveAmlSuspicions = false;
        string expectedCallbackUrl = "https://example.com/callback";
        string expectedCallbackUrlNotification = "https://example.com/notify";
        float expectedFilteringScoreAmlSuspicions = 0.75f;
        string expectedLanguage = "fra";
        List<ApiEnum<string, IndividualUpdateParamsTechnicalDataPortalStep>> expectedPortalSteps =
        [
            IndividualUpdateParamsTechnicalDataPortalStep.IdentityVerification,
            IndividualUpdateParamsTechnicalDataPortalStep.Selfie,
            IndividualUpdateParamsTechnicalDataPortalStep.FaceMatch,
        ];
        bool expectedRawDataValue = true;

        Assert.Equal(expectedActiveAmlSuspicions, deserialized.ActiveAmlSuspicions);
        Assert.Equal(expectedCallbackUrl, deserialized.CallbackUrl);
        Assert.Equal(expectedCallbackUrlNotification, deserialized.CallbackUrlNotification);
        Assert.Equal(expectedFilteringScoreAmlSuspicions, deserialized.FilteringScoreAmlSuspicions);
        Assert.Equal(expectedLanguage, deserialized.Language);
        Assert.NotNull(deserialized.PortalSteps);
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
            CallbackUrl = "https://example.com/callback",
            CallbackUrlNotification = "https://example.com/notify",
            FilteringScoreAmlSuspicions = 0.75f,
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
        Assert.Null(model.CallbackUrl);
        Assert.False(model.RawData.ContainsKey("callback_url"));
        Assert.Null(model.CallbackUrlNotification);
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
            CallbackUrl = null,
            CallbackUrlNotification = null,
            FilteringScoreAmlSuspicions = null,
            Language = null,
            PortalSteps = null,
            RawDataValue = null,
        };

        Assert.Null(model.ActiveAmlSuspicions);
        Assert.False(model.RawData.ContainsKey("active_aml_suspicions"));
        Assert.Null(model.CallbackUrl);
        Assert.False(model.RawData.ContainsKey("callback_url"));
        Assert.Null(model.CallbackUrlNotification);
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
            CallbackUrl = null,
            CallbackUrlNotification = null,
            FilteringScoreAmlSuspicions = null,
            Language = null,
            PortalSteps = null,
            RawDataValue = null,
        };

        model.Validate();
    }
}

public class IndividualUpdateParamsTechnicalDataPortalStepTest : TestBase
{
    [Theory]
    [InlineData(IndividualUpdateParamsTechnicalDataPortalStep.IdentityVerification)]
    [InlineData(IndividualUpdateParamsTechnicalDataPortalStep.DocumentSigning)]
    [InlineData(IndividualUpdateParamsTechnicalDataPortalStep.ProofOfAddress)]
    [InlineData(IndividualUpdateParamsTechnicalDataPortalStep.Selfie)]
    [InlineData(IndividualUpdateParamsTechnicalDataPortalStep.FaceMatch)]
    public void Validation_Works(IndividualUpdateParamsTechnicalDataPortalStep rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IndividualUpdateParamsTechnicalDataPortalStep> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, IndividualUpdateParamsTechnicalDataPortalStep>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<DataleonlabsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IndividualUpdateParamsTechnicalDataPortalStep.IdentityVerification)]
    [InlineData(IndividualUpdateParamsTechnicalDataPortalStep.DocumentSigning)]
    [InlineData(IndividualUpdateParamsTechnicalDataPortalStep.ProofOfAddress)]
    [InlineData(IndividualUpdateParamsTechnicalDataPortalStep.Selfie)]
    [InlineData(IndividualUpdateParamsTechnicalDataPortalStep.FaceMatch)]
    public void SerializationRoundtrip_Works(IndividualUpdateParamsTechnicalDataPortalStep rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IndividualUpdateParamsTechnicalDataPortalStep> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IndividualUpdateParamsTechnicalDataPortalStep>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, IndividualUpdateParamsTechnicalDataPortalStep>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IndividualUpdateParamsTechnicalDataPortalStep>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
