using System;
using System.Collections.Generic;
using System.Net.Http;
using ApiClients.DocumentCreationClient.Models;
using Flurl.Http.Testing;
using Xunit;

namespace ApiClients.Tests
{
    public class DocumentCreationClientTests : IDisposable
    {
        private readonly HttpTest _httpTest;
        private readonly DocumentCreationClient.DocumentCreationClient _client;

        public DocumentCreationClientTests()
        {
            _httpTest = new HttpTest();
            _client = new DocumentCreationClient.DocumentCreationClient();
            _client.BaseUri = "http://localhost/";
        }

        public void Dispose()
        {
            _httpTest.Dispose();
        }

        [Fact]
        public async void PostHandlebarPdf_WithEmptyData()
        {
            await _client.PostHandlebarPdf(new HandlebarPdfRequest
            {
                AdditionalDocuments = new List<AdditionalDocuments>
                {
                    new AdditionalDocuments()
                }
            });

            _httpTest.ShouldHaveCalled("http://localhost/api/documentcreation/handlebar-pdf")
                .WithVerb(HttpMethod.Post)
                .WithContentType("application/json")
                .Times(1);
        }

        [Fact]
        public async void PostHandlebarPdf_WithTestData()
        {
            await _client.PostHandlebarPdf(new HandlebarPdfRequest
            {
                FileSavePath = "test",
                HandlebarHtmlTemplate = "test",
                Header = "test",
                JsonData = "test",
                UniqueReference = "test",
                AdditionalDocuments = new List<AdditionalDocuments>
                {
                    new AdditionalDocuments
                    {
                        Base64Document = "test",
                        Type = AdditionalDocumentTypes.Doc
                    }
                }
            });

            _httpTest.ShouldHaveCalled("http://localhost/api/documentcreation/handlebar-pdf")
                .WithVerb(HttpMethod.Post)
                .WithContentType("application/json")
                .Times(1);
        }
    }
}
