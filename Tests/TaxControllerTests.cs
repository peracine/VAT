using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class TaxControllerTests : IClassFixture<TestClient>
    {
        private const string _countryCode = "XX";
        private string _requestUri = $"API/Tax/{_countryCode}/VAT";
        private readonly TestClient _client;

        public TaxControllerTests(TestClient client)
        {
            _client = client;
        }

        [Fact]
        public async Task GetTax_returns_OK()
        {
            var model = new { Price = 99.99, ProductType = "Standard" };
            var result = await _client.PostAsync(_requestUri, model);
            Assert.True(result.StatusCode == HttpStatusCode.OK, $"GetTax returned an invalid status ({result.StatusCode}).");
        }

        [Fact]
        public async Task GetTax_with_invalid_ProductType_returns_BadRequest()
        {
            var model = new { Price = 100, ProductType = "InvalidProductType" };
            var result = await _client.PostAsync(_requestUri, model);
            Assert.True(result.StatusCode == HttpStatusCode.BadRequest, $"GetTax returned an invalid status ({result.StatusCode}).");
        }
    }
}
