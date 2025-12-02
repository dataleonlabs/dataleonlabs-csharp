using System.Collections.Generic;
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
}
