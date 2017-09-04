using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace NCrunchIntTests.Tests
{
    public class Failing
    {
        private readonly HttpClient _client;

        public Failing()
        {
            var server = new TestServer(new WebHostBuilder()
                .ConfigureServices(collection =>
                {
                })
                .UseStartup<TestStartup>());
            _client = server.CreateClient();
        }
        
        [Fact]
        public async Task response_status_is_200()
        {
            var content = new StringContent("{}", Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("status", content);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task response_is_ok()
        {
            var content = new StringContent("{}", Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("status", content);
            string message = await response.Content.ReadAsStringAsync();
            Assert.Equal("OK", message);
        }
    }
}
