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
}
