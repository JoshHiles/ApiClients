using System;
using System.Collections.Generic;
using System.Text;
using Flurl.Http.Testing;
using Xunit;

namespace ApiClients.Tests
{
    public class LookupClientTests
    {
        private readonly HttpTest _httpTest;
        private readonly LookupClient.LookupClient _client;

        public LookupClientTests()
        {
            _httpTest = new HttpTest();
            _client = new LookupClient.LookupClient();
            _client.BaseUri = "";
        }

        public void Dispose()
        {
            _httpTest.Dispose();
        }

    }
}
