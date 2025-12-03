using System;
using System.Collections.Generic;
using System.Text.Json;
using Dataleonlabs.Models.Companies;
using Dataleonlabs.Models.Companies.Documents;

namespace Dataleonlabs.Tests.Models.Companies.Documents;

public class GenericDocumentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GenericDocument
        {
            ID = "doc_123",
            Checks =
            [
                new()
                {
                    Masked = false,
                    Message = "Name matched successfully",
                    Name = "name_match",
                    Validate1 = true,
                    Weight = 1,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
            DocumentType = "generic",
            Name = "generic_doc",
            SignedURL = "https://cdn.example.com/doc.pdf",
            State = "SUBMITTED",
            Status = "approved",
            Tables = [new() { Operation = [JsonSerializer.Deserialize<JsonElement>("{}")] }],
            Values =
            [
                new()
                {
                    Confidence = 0.95,
                    Name = "Full Name",
                    Value1 = [100, 200],
                },
            ],
        };

        string expectedID = "doc_123";
        List<Check> expectedChecks =
        [
            new()
            {
                Masked = false,
                Message = "Name matched successfully",
                Name = "name_match",
                Validate1 = true,
                Weight = 1,
            },
        ];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z");
        string expectedDocumentType = "generic";
        string expectedName = "generic_doc";
        string expectedSignedURL = "https://cdn.example.com/doc.pdf";
        string expectedState = "SUBMITTED";
        string expectedStatus = "approved";
        List<Table> expectedTables =
        [
            new() { Operation = [JsonSerializer.Deserialize<JsonElement>("{}")] },
        ];
        List<Value> expectedValues =
        [
            new()
            {
                Confidence = 0.95,
                Name = "Full Name",
                Value1 = [100, 200],
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChecks.Count, model.Checks.Count);
        for (int i = 0; i < expectedChecks.Count; i++)
        {
            Assert.Equal(expectedChecks[i], model.Checks[i]);
        }
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDocumentType, model.DocumentType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSignedURL, model.SignedURL);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTables.Count, model.Tables.Count);
        for (int i = 0; i < expectedTables.Count; i++)
        {
            Assert.Equal(expectedTables[i], model.Tables[i]);
        }
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GenericDocument
        {
            ID = "doc_123",
            Checks =
            [
                new()
                {
                    Masked = false,
                    Message = "Name matched successfully",
                    Name = "name_match",
                    Validate1 = true,
                    Weight = 1,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
            DocumentType = "generic",
            Name = "generic_doc",
            SignedURL = "https://cdn.example.com/doc.pdf",
            State = "SUBMITTED",
            Status = "approved",
            Tables = [new() { Operation = [JsonSerializer.Deserialize<JsonElement>("{}")] }],
            Values =
            [
                new()
                {
                    Confidence = 0.95,
                    Name = "Full Name",
                    Value1 = [100, 200],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<GenericDocument>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GenericDocument
        {
            ID = "doc_123",
            Checks =
            [
                new()
                {
                    Masked = false,
                    Message = "Name matched successfully",
                    Name = "name_match",
                    Validate1 = true,
                    Weight = 1,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
            DocumentType = "generic",
            Name = "generic_doc",
            SignedURL = "https://cdn.example.com/doc.pdf",
            State = "SUBMITTED",
            Status = "approved",
            Tables = [new() { Operation = [JsonSerializer.Deserialize<JsonElement>("{}")] }],
            Values =
            [
                new()
                {
                    Confidence = 0.95,
                    Name = "Full Name",
                    Value1 = [100, 200],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<GenericDocument>(json);
        Assert.NotNull(deserialized);

        string expectedID = "doc_123";
        List<Check> expectedChecks =
        [
            new()
            {
                Masked = false,
                Message = "Name matched successfully",
                Name = "name_match",
                Validate1 = true,
                Weight = 1,
            },
        ];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z");
        string expectedDocumentType = "generic";
        string expectedName = "generic_doc";
        string expectedSignedURL = "https://cdn.example.com/doc.pdf";
        string expectedState = "SUBMITTED";
        string expectedStatus = "approved";
        List<Table> expectedTables =
        [
            new() { Operation = [JsonSerializer.Deserialize<JsonElement>("{}")] },
        ];
        List<Value> expectedValues =
        [
            new()
            {
                Confidence = 0.95,
                Name = "Full Name",
                Value1 = [100, 200],
            },
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChecks.Count, deserialized.Checks.Count);
        for (int i = 0; i < expectedChecks.Count; i++)
        {
            Assert.Equal(expectedChecks[i], deserialized.Checks[i]);
        }
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDocumentType, deserialized.DocumentType);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSignedURL, deserialized.SignedURL);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTables.Count, deserialized.Tables.Count);
        for (int i = 0; i < expectedTables.Count; i++)
        {
            Assert.Equal(expectedTables[i], deserialized.Tables[i]);
        }
        Assert.Equal(expectedValues.Count, deserialized.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], deserialized.Values[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GenericDocument
        {
            ID = "doc_123",
            Checks =
            [
                new()
                {
                    Masked = false,
                    Message = "Name matched successfully",
                    Name = "name_match",
                    Validate1 = true,
                    Weight = 1,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2025-05-01T12:00:00Z"),
            DocumentType = "generic",
            Name = "generic_doc",
            SignedURL = "https://cdn.example.com/doc.pdf",
            State = "SUBMITTED",
            Status = "approved",
            Tables = [new() { Operation = [JsonSerializer.Deserialize<JsonElement>("{}")] }],
            Values =
            [
                new()
                {
                    Confidence = 0.95,
                    Name = "Full Name",
                    Value1 = [100, 200],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GenericDocument { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Checks);
        Assert.False(model.RawData.ContainsKey("checks"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DocumentType);
        Assert.False(model.RawData.ContainsKey("document_type"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.SignedURL);
        Assert.False(model.RawData.ContainsKey("signed_url"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Tables);
        Assert.False(model.RawData.ContainsKey("tables"));
        Assert.Null(model.Values);
        Assert.False(model.RawData.ContainsKey("values"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GenericDocument { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GenericDocument
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Checks = null,
            CreatedAt = null,
            DocumentType = null,
            Name = null,
            SignedURL = null,
            State = null,
            Status = null,
            Tables = null,
            Values = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Checks);
        Assert.False(model.RawData.ContainsKey("checks"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DocumentType);
        Assert.False(model.RawData.ContainsKey("document_type"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.SignedURL);
        Assert.False(model.RawData.ContainsKey("signed_url"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Tables);
        Assert.False(model.RawData.ContainsKey("tables"));
        Assert.Null(model.Values);
        Assert.False(model.RawData.ContainsKey("values"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GenericDocument
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Checks = null,
            CreatedAt = null,
            DocumentType = null,
            Name = null,
            SignedURL = null,
            State = null,
            Status = null,
            Tables = null,
            Values = null,
        };

        model.Validate();
    }
}

public class TableTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Table { Operation = [JsonSerializer.Deserialize<JsonElement>("{}")] };

        List<JsonElement> expectedOperation = [JsonSerializer.Deserialize<JsonElement>("{}")];

        Assert.Equal(expectedOperation.Count, model.Operation.Count);
        for (int i = 0; i < expectedOperation.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedOperation[i], model.Operation[i]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Table { Operation = [JsonSerializer.Deserialize<JsonElement>("{}")] };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Table>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Table { Operation = [JsonSerializer.Deserialize<JsonElement>("{}")] };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Table>(json);
        Assert.NotNull(deserialized);

        List<JsonElement> expectedOperation = [JsonSerializer.Deserialize<JsonElement>("{}")];

        Assert.Equal(expectedOperation.Count, deserialized.Operation.Count);
        for (int i = 0; i < expectedOperation.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedOperation[i], deserialized.Operation[i]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Table { Operation = [JsonSerializer.Deserialize<JsonElement>("{}")] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Table { };

        Assert.Null(model.Operation);
        Assert.False(model.RawData.ContainsKey("operation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Table { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Table
        {
            // Null should be interpreted as omitted for these properties
            Operation = null,
        };

        Assert.Null(model.Operation);
        Assert.False(model.RawData.ContainsKey("operation"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Table
        {
            // Null should be interpreted as omitted for these properties
            Operation = null,
        };

        model.Validate();
    }
}

public class ValueTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Value
        {
            Confidence = 0.95,
            Name = "Full Name",
            Value1 = [100, 200],
        };

        double expectedConfidence = 0.95;
        string expectedName = "Full Name";
        List<long> expectedValue1 = [100, 200];

        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedValue1.Count, model.Value1.Count);
        for (int i = 0; i < expectedValue1.Count; i++)
        {
            Assert.Equal(expectedValue1[i], model.Value1[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Value
        {
            Confidence = 0.95,
            Name = "Full Name",
            Value1 = [100, 200],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Value>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Value
        {
            Confidence = 0.95,
            Name = "Full Name",
            Value1 = [100, 200],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Value>(json);
        Assert.NotNull(deserialized);

        double expectedConfidence = 0.95;
        string expectedName = "Full Name";
        List<long> expectedValue1 = [100, 200];

        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedValue1.Count, deserialized.Value1.Count);
        for (int i = 0; i < expectedValue1.Count; i++)
        {
            Assert.Equal(expectedValue1[i], deserialized.Value1[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Value
        {
            Confidence = 0.95,
            Name = "Full Name",
            Value1 = [100, 200],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Value { };

        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Value1);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Value { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Value
        {
            // Null should be interpreted as omitted for these properties
            Confidence = null,
            Name = null,
            Value1 = null,
        };

        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Value1);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Value
        {
            // Null should be interpreted as omitted for these properties
            Confidence = null,
            Name = null,
            Value1 = null,
        };

        model.Validate();
    }
}
