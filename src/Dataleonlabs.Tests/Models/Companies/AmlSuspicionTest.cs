using System.Text.Json;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;
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
            Score = 0.85f,
            Source = "https://aml-checker.example.com/api/v1/suspicion/12345",
            Status = AmlSuspicionStatus.Pending,
            Type = Type.Pep,
        };

        string expectedCaption = "Suspicious activity";
        string expectedCountry = "FR";
        string expectedGender = "M";
        string expectedRelation = "linked";
        string expectedSchema = "v1";
        float expectedScore = 0.85f;
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AmlSuspicion
        {
            Caption = "Suspicious activity",
            Country = "FR",
            Gender = "M",
            Relation = "linked",
            Schema = "v1",
            Score = 0.85f,
            Source = "https://aml-checker.example.com/api/v1/suspicion/12345",
            Status = AmlSuspicionStatus.Pending,
            Type = Type.Pep,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AmlSuspicion>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AmlSuspicion
        {
            Caption = "Suspicious activity",
            Country = "FR",
            Gender = "M",
            Relation = "linked",
            Schema = "v1",
            Score = 0.85f,
            Source = "https://aml-checker.example.com/api/v1/suspicion/12345",
            Status = AmlSuspicionStatus.Pending,
            Type = Type.Pep,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AmlSuspicion>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCaption = "Suspicious activity";
        string expectedCountry = "FR";
        string expectedGender = "M";
        string expectedRelation = "linked";
        string expectedSchema = "v1";
        float expectedScore = 0.85f;
        string expectedSource = "https://aml-checker.example.com/api/v1/suspicion/12345";
        ApiEnum<string, AmlSuspicionStatus> expectedStatus = AmlSuspicionStatus.Pending;
        ApiEnum<string, Type> expectedType = Type.Pep;

        Assert.Equal(expectedCaption, deserialized.Caption);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedGender, deserialized.Gender);
        Assert.Equal(expectedRelation, deserialized.Relation);
        Assert.Equal(expectedSchema, deserialized.Schema);
        Assert.Equal(expectedScore, deserialized.Score);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AmlSuspicion
        {
            Caption = "Suspicious activity",
            Country = "FR",
            Gender = "M",
            Relation = "linked",
            Schema = "v1",
            Score = 0.85f,
            Source = "https://aml-checker.example.com/api/v1/suspicion/12345",
            Status = AmlSuspicionStatus.Pending,
            Type = Type.Pep,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AmlSuspicion { };

        Assert.Null(model.Caption);
        Assert.False(model.RawData.ContainsKey("caption"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Gender);
        Assert.False(model.RawData.ContainsKey("gender"));
        Assert.Null(model.Relation);
        Assert.False(model.RawData.ContainsKey("relation"));
        Assert.Null(model.Schema);
        Assert.False(model.RawData.ContainsKey("schema"));
        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AmlSuspicion { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AmlSuspicion
        {
            // Null should be interpreted as omitted for these properties
            Caption = null,
            Country = null,
            Gender = null,
            Relation = null,
            Schema = null,
            Score = null,
            Source = null,
            Status = null,
            Type = null,
        };

        Assert.Null(model.Caption);
        Assert.False(model.RawData.ContainsKey("caption"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Gender);
        Assert.False(model.RawData.ContainsKey("gender"));
        Assert.Null(model.Relation);
        Assert.False(model.RawData.ContainsKey("relation"));
        Assert.Null(model.Schema);
        Assert.False(model.RawData.ContainsKey("schema"));
        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AmlSuspicion
        {
            // Null should be interpreted as omitted for these properties
            Caption = null,
            Country = null,
            Gender = null,
            Relation = null,
            Schema = null,
            Score = null,
            Source = null,
            Status = null,
            Type = null,
        };

        model.Validate();
    }
}

public class AmlSuspicionStatusTest : TestBase
{
    [Theory]
    [InlineData(AmlSuspicionStatus.TruePositive)]
    [InlineData(AmlSuspicionStatus.FalsePositive)]
    [InlineData(AmlSuspicionStatus.Pending)]
    public void Validation_Works(AmlSuspicionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AmlSuspicionStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AmlSuspicionStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DataleonlabsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AmlSuspicionStatus.TruePositive)]
    [InlineData(AmlSuspicionStatus.FalsePositive)]
    [InlineData(AmlSuspicionStatus.Pending)]
    public void SerializationRoundtrip_Works(AmlSuspicionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AmlSuspicionStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AmlSuspicionStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AmlSuspicionStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AmlSuspicionStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.Crime)]
    [InlineData(Type.Sanction)]
    [InlineData(Type.Pep)]
    [InlineData(Type.AdverseNews)]
    [InlineData(Type.Other)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DataleonlabsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.Crime)]
    [InlineData(Type.Sanction)]
    [InlineData(Type.Pep)]
    [InlineData(Type.AdverseNews)]
    [InlineData(Type.Other)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
