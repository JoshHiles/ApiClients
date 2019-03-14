using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace ApiClients.LookupClient
{
    public interface ILookupClient : IBaseClient
    {
        Task<HttpResponseMessage> IsTodayABankHoliday();

        Task<HttpResponseMessage> CheckIfADateIsABankHoliday(DateTime date);

        Task<HttpResponseMessage> GetListOfNCPEthnicity();

        Task<HttpResponseMessage> GetListOfNCPLegalStatus();

        Task<HttpResponseMessage> GetListOfNCPPlacementType();
    }

    public class LookupClient : ILookupClient
    {
        public string BaseUri { get; set; }

        private static readonly string BaseApi = "lookupapi/api/values";

        public async Task<HttpResponseMessage> IsTodayABankHoliday()
        {
            return await $"{BaseUri}{BaseApi}/IsTodayABH"
                .GetAsync();
        }

        public async Task<HttpResponseMessage> CheckIfADateIsABankHoliday(DateTime dateRequest)
        {
            return await $"{BaseUri}{BaseApi}/CheckIfBH"
                .SetQueryParam("date", dateRequest)
                .GetAsync();
        }

        public async Task<HttpResponseMessage> GetListOfNCPEthnicity()
        {
            return await $"{BaseUri}{BaseApi}"
                .SetQueryParam("id", "ncpdethnicity")
                .GetAsync();
        }

        public async Task<HttpResponseMessage> GetListOfNCPLegalStatus()
        {
            return await $"{BaseUri}{BaseApi}"
                .SetQueryParam("id", "ncpdlegalstatus")
                .GetAsync();
        }

        public async Task<HttpResponseMessage> GetListOfNCPPlacementType()
        {
            return await $"{BaseUri}{BaseApi}"
                .SetQueryParam("id", "ncpdplacementtype")
                .GetAsync();
        }
    }
}
