using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiClients.TemplatingClient.Models;
using Flurl;
using Flurl.Http;

namespace ApiClients.TemplatingClient
{
    public interface IEmailTemplateClient
    {
        Task<List<Email>> GetEmails();

        Task<Email> GetEmail(Guid id);

        Task<HttpResponseMessage> PutEmail(Email email);

        Task<Email> PostEmail(Email email);

        Task<HttpResponseMessage> DeleteEmail(Guid id);
    }

    public class EmailTemplateClient : IBaseClient, IEmailTemplateClient
    {
        public string BaseUri { get; set; }

        private static readonly string BaseEmail = "api/emails";

        public async Task<List<Email>> GetEmails()
        {
            return await $"{BaseUri}{BaseEmail}"
                .GetAsync()
                .ReceiveJson<List<Email>>();
        }

        public async Task<Email> GetEmail(Guid id)
        {
            var result = await $"{BaseUri}{BaseEmail}"
                .SetQueryParam("id", id)
                .GetAsync()
                .ReceiveJson<List<Email>>();

            return result.FirstOrDefault();
        }

        public async Task<HttpResponseMessage> PutEmail(Email email)
        {
            return await $"{BaseUri}{BaseEmail}"
                .AppendPathSegment("/" + email.Id)
                .PutJsonAsync(email);
        }

        public async Task<Email> PostEmail(Email email)
        {
            return await $"{BaseUri}{BaseEmail}"
                .PostJsonAsync(email)
                .ReceiveJson<Email>();
        }

        public async Task<HttpResponseMessage> DeleteEmail(Guid id)
        {
            return await $"{BaseUri}{BaseEmail}"
                .AppendPathSegment("/" + id)
                .DeleteAsync();
        }
    }
}
