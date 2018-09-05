using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VatCalculator;

namespace Tests
{
    public class TestClient : IDisposable
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public TestClient()
        {
            var mockServices = new MockServices();

            var builder = new WebHostBuilder()
                .ConfigureTestServices(s => s.AddSingleton(mockServices.MockTaxComputingServices.Object))
                .UseStartup<Startup>();

            _server = new TestServer(builder);
            _client = _server.CreateClient();
        }

        public async Task<HttpResponseMessage> PostAsync(string requestUri, object model)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            return await _client.PostAsync(requestUri, content);
        }

        public void Dispose()
        {
            _client.Dispose();
            _server.Dispose();
        }
    }
}
