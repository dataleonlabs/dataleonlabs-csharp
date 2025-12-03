using System.Collections.Generic;
using System.Text.Json;
using Dataleonlabs.Models.Companies.Documents;

namespace Dataleonlabs.Tests.Models.Companies.Documents;

public class DocumentResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DocumentResponse
        {
            Documents =
            [
                new()
                {
                    ID = "123456",
                    DocumentType = "identity_document_card",
                    Filename = "document.pdf",
                    Name = "Identity Document Card Back",
                    SignedURL =
                        "https://storage.googleapis.com/bucket-name/document.pdf?signature=...",
                    State = "PROCESSED",
                    Status = "approved",
                    WorkspaceID = "wk_123",
                },
            ],
            TotalDocument = 3,
        };

        List<Document> expectedDocuments =
        [
            new()
            {
                ID = "123456",
                DocumentType = "identity_document_card",
                Filename = "document.pdf",
                Name = "Identity Document Card Back",
                SignedURL = "https://storage.googleapis.com/bucket-name/document.pdf?signature=...",
                State = "PROCESSED",
                Status = "approved",
                WorkspaceID = "wk_123",
            },
        ];
        long expectedTotalDocument = 3;

        Assert.Equal(expectedDocuments.Count, model.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], model.Documents[i]);
        }
        Assert.Equal(expectedTotalDocument, model.TotalDocument);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DocumentResponse
        {
            Documents =
            [
                new()
                {
                    ID = "123456",
                    DocumentType = "identity_document_card",
                    Filename = "document.pdf",
                    Name = "Identity Document Card Back",
                    SignedURL =
                        "https://storage.googleapis.com/bucket-name/document.pdf?signature=...",
                    State = "PROCESSED",
                    Status = "approved",
                    WorkspaceID = "wk_123",
                },
            ],
            TotalDocument = 3,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DocumentResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DocumentResponse
        {
            Documents =
            [
                new()
                {
                    ID = "123456",
                    DocumentType = "identity_document_card",
                    Filename = "document.pdf",
                    Name = "Identity Document Card Back",
                    SignedURL =
                        "https://storage.googleapis.com/bucket-name/document.pdf?signature=...",
                    State = "PROCESSED",
                    Status = "approved",
                    WorkspaceID = "wk_123",
                },
            ],
            TotalDocument = 3,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DocumentResponse>(json);
        Assert.NotNull(deserialized);

        List<Document> expectedDocuments =
        [
            new()
            {
                ID = "123456",
                DocumentType = "identity_document_card",
                Filename = "document.pdf",
                Name = "Identity Document Card Back",
                SignedURL = "https://storage.googleapis.com/bucket-name/document.pdf?signature=...",
                State = "PROCESSED",
                Status = "approved",
                WorkspaceID = "wk_123",
            },
        ];
        long expectedTotalDocument = 3;

        Assert.Equal(expectedDocuments.Count, deserialized.Documents.Count);
        for (int i = 0; i < expectedDocuments.Count; i++)
        {
            Assert.Equal(expectedDocuments[i], deserialized.Documents[i]);
        }
        Assert.Equal(expectedTotalDocument, deserialized.TotalDocument);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DocumentResponse
        {
            Documents =
            [
                new()
                {
                    ID = "123456",
                    DocumentType = "identity_document_card",
                    Filename = "document.pdf",
                    Name = "Identity Document Card Back",
                    SignedURL =
                        "https://storage.googleapis.com/bucket-name/document.pdf?signature=...",
                    State = "PROCESSED",
                    Status = "approved",
                    WorkspaceID = "wk_123",
                },
            ],
            TotalDocument = 3,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DocumentResponse { };

        Assert.Null(model.Documents);
        Assert.False(model.RawData.ContainsKey("documents"));
        Assert.Null(model.TotalDocument);
        Assert.False(model.RawData.ContainsKey("total_document"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DocumentResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DocumentResponse
        {
            // Null should be interpreted as omitted for these properties
            Documents = null,
            TotalDocument = null,
        };

        Assert.Null(model.Documents);
        Assert.False(model.RawData.ContainsKey("documents"));
        Assert.Null(model.TotalDocument);
        Assert.False(model.RawData.ContainsKey("total_document"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DocumentResponse
        {
            // Null should be interpreted as omitted for these properties
            Documents = null,
            TotalDocument = null,
        };

        model.Validate();
    }
}

public class DocumentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Document
        {
            ID = "123456",
            DocumentType = "identity_document_card",
            Filename = "document.pdf",
            Name = "Identity Document Card Back",
            SignedURL = "https://storage.googleapis.com/bucket-name/document.pdf?signature=...",
            State = "PROCESSED",
            Status = "approved",
            WorkspaceID = "wk_123",
        };

        string expectedID = "123456";
        string expectedDocumentType = "identity_document_card";
        string expectedFilename = "document.pdf";
        string expectedName = "Identity Document Card Back";
        string expectedSignedURL =
            "https://storage.googleapis.com/bucket-name/document.pdf?signature=...";
        string expectedState = "PROCESSED";
        string expectedStatus = "approved";
        string expectedWorkspaceID = "wk_123";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDocumentType, model.DocumentType);
        Assert.Equal(expectedFilename, model.Filename);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSignedURL, model.SignedURL);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Document
        {
            ID = "123456",
            DocumentType = "identity_document_card",
            Filename = "document.pdf",
            Name = "Identity Document Card Back",
            SignedURL = "https://storage.googleapis.com/bucket-name/document.pdf?signature=...",
            State = "PROCESSED",
            Status = "approved",
            WorkspaceID = "wk_123",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Document>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Document
        {
            ID = "123456",
            DocumentType = "identity_document_card",
            Filename = "document.pdf",
            Name = "Identity Document Card Back",
            SignedURL = "https://storage.googleapis.com/bucket-name/document.pdf?signature=...",
            State = "PROCESSED",
            Status = "approved",
            WorkspaceID = "wk_123",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Document>(json);
        Assert.NotNull(deserialized);

        string expectedID = "123456";
        string expectedDocumentType = "identity_document_card";
        string expectedFilename = "document.pdf";
        string expectedName = "Identity Document Card Back";
        string expectedSignedURL =
            "https://storage.googleapis.com/bucket-name/document.pdf?signature=...";
        string expectedState = "PROCESSED";
        string expectedStatus = "approved";
        string expectedWorkspaceID = "wk_123";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDocumentType, deserialized.DocumentType);
        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSignedURL, deserialized.SignedURL);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Document
        {
            ID = "123456",
            DocumentType = "identity_document_card",
            Filename = "document.pdf",
            Name = "Identity Document Card Back",
            SignedURL = "https://storage.googleapis.com/bucket-name/document.pdf?signature=...",
            State = "PROCESSED",
            Status = "approved",
            WorkspaceID = "wk_123",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Document { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.DocumentType);
        Assert.False(model.RawData.ContainsKey("document_type"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.SignedURL);
        Assert.False(model.RawData.ContainsKey("signed_url"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.WorkspaceID);
        Assert.False(model.RawData.ContainsKey("workspace_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Document { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Document
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            DocumentType = null,
            Filename = null,
            Name = null,
            SignedURL = null,
            State = null,
            Status = null,
            WorkspaceID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.DocumentType);
        Assert.False(model.RawData.ContainsKey("document_type"));
        Assert.Null(model.Filename);
        Assert.False(model.RawData.ContainsKey("filename"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.SignedURL);
        Assert.False(model.RawData.ContainsKey("signed_url"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.WorkspaceID);
        Assert.False(model.RawData.ContainsKey("workspace_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Document
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            DocumentType = null,
            Filename = null,
            Name = null,
            SignedURL = null,
            State = null,
            Status = null,
            WorkspaceID = null,
        };

        model.Validate();
    }
}
