using System;
using System.Text.Json;
using Dataleonlabs.Core;
using Dataleonlabs.Exceptions;
using Dataleonlabs.Models.Individuals;

namespace Dataleonlabs.Tests.Models.Individuals;

public class IndividualListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IndividualListParams
        {
            EndDate = "2019-12-27",
            Limit = 1,
            Offset = 0,
            SourceID = "source_id",
            StartDate = "2019-12-27",
            State = State.Void,
            Status = Status.Rejected,
            WorkspaceID = "workspace_id",
        };

        string expectedEndDate = "2019-12-27";
        long expectedLimit = 1;
        long expectedOffset = 0;
        string expectedSourceID = "source_id";
        string expectedStartDate = "2019-12-27";
        ApiEnum<string, State> expectedState = State.Void;
        ApiEnum<string, Status> expectedStatus = Status.Rejected;
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedEndDate, parameters.EndDate);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedSourceID, parameters.SourceID);
        Assert.Equal(expectedStartDate, parameters.StartDate);
        Assert.Equal(expectedState, parameters.State);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IndividualListParams { };

        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawQueryData.ContainsKey("end_date"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.SourceID);
        Assert.False(parameters.RawQueryData.ContainsKey("source_id"));
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawQueryData.ContainsKey("start_date"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawQueryData.ContainsKey("state"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawQueryData.ContainsKey("workspace_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new IndividualListParams
        {
            // Null should be interpreted as omitted for these properties
            EndDate = null,
            Limit = null,
            Offset = null,
            SourceID = null,
            StartDate = null,
            State = null,
            Status = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.EndDate);
        Assert.False(parameters.RawQueryData.ContainsKey("end_date"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.SourceID);
        Assert.False(parameters.RawQueryData.ContainsKey("source_id"));
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawQueryData.ContainsKey("start_date"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawQueryData.ContainsKey("state"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawQueryData.ContainsKey("workspace_id"));
    }

    [Fact]
    public void Url_Works()
    {
        IndividualListParams parameters = new()
        {
            EndDate = "2019-12-27",
            Limit = 1,
            Offset = 0,
            SourceID = "source_id",
            StartDate = "2019-12-27",
            State = State.Void,
            Status = Status.Rejected,
            WorkspaceID = "workspace_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://inference.eu-west-1.dataleon.ai/individuals?end_date=2019-12-27&limit=1&offset=0&source_id=source_id&start_date=2019-12-27&state=VOID&status=rejected&workspace_id=workspace_id"
            ),
            url
        );
    }
}

public class StateTest : TestBase
{
    [Theory]
    [InlineData(State.Void)]
    [InlineData(State.Waiting)]
    [InlineData(State.Started)]
    [InlineData(State.Running)]
    [InlineData(State.Processed)]
    [InlineData(State.Failed)]
    [InlineData(State.Aborted)]
    [InlineData(State.Expired)]
    [InlineData(State.Deleted)]
    public void Validation_Works(State rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, State> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DataleonlabsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(State.Void)]
    [InlineData(State.Waiting)]
    [InlineData(State.Started)]
    [InlineData(State.Running)]
    [InlineData(State.Processed)]
    [InlineData(State.Failed)]
    [InlineData(State.Aborted)]
    [InlineData(State.Expired)]
    [InlineData(State.Deleted)]
    public void SerializationRoundtrip_Works(State rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, State> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Rejected)]
    [InlineData(Status.NeedReview)]
    [InlineData(Status.Approved)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<DataleonlabsInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Rejected)]
    [InlineData(Status.NeedReview)]
    [InlineData(Status.Approved)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
