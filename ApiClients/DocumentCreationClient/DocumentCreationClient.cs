using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ApiClients.DocumentCreationClient.Models;
using Flurl;
using Flurl.Http;

namespace ApiClients.DocumentCreationClient
{
    public interface IDocumentCreationClient : IBaseClient
    {
        Task<HttpResponseMessage> PostHandlebarPdf(HandlebarPdfRequest request);
        Task<HttpResponseMessage> GetBearerToken(string username, string password);
    }

    public class DocumentCreationClient : IDocumentCreationClient
    {
        public string BaseUri { get; set; }

        private static readonly string BaseApi = "api/documentcreation";
        private static readonly string BaseApiAuthenticate = "api/Authenticate";

        public async Task<HttpResponseMessage> GetBearerToken(string username, string password)
        {
            return await $"{BaseUri}{BaseApiAuthenticate}"
                .SetQueryParam("username", username)
                .SetQueryParam("password", password)
                .GetAsync();
        }

        public async Task<HttpResponseMessage> PostHandlebarPdf(HandlebarPdfRequest request)
        {
            return await $"{BaseUri}{BaseApi}/handlebar-pdf"
                .WithOAuthBearerToken(request.BearerToken)
                .PostJsonAsync(request);
        }
    }
}
