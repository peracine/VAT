using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using VatCalculator;
using VatCalculator.Controllers;
using Xunit;

namespace Tests
{
    public class Tests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public Tests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Theory]
        [InlineData(1000, ProductType.Flowers, 250, 1250)]
        [InlineData(1000, ProductType.Beverages, 150, 1150)]
        [InlineData(1000, ProductType.Books, 250, 1250)]
        [InlineData(1000, ProductType.Food, 150, 1150)]
        [InlineData(1000, ProductType.InternationalPassengerTransport, 250, 1250)]
        [InlineData(1000, ProductType.Newspapers, 250, 1250)]
        [InlineData(1000, ProductType.SportingActivities, 120, 1120)]
        [InlineData(1000, ProductType.Standard, 250, 1250)]
        public async Task NorwegianVatTests(decimal price, ProductType productType, decimal expectedVat, decimal expectedPriceWithVat)
        {
            await PostProductAndAssertPrice(price, productType, expectedVat, expectedPriceWithVat, "NO");
        }

        [Theory]
        [InlineData(1000, ProductType.Flowers, 250, 1250)]
        [InlineData(1000, ProductType.Beverages, 250, 1250)]
        [InlineData(1000, ProductType.Books, 60, 1060)]
        [InlineData(1000, ProductType.Food, 120, 1120)]
        [InlineData(1000, ProductType.InternationalPassengerTransport, 0, 1000)]
        [InlineData(1000, ProductType.Newspapers, 60, 1060)]
        [InlineData(1000, ProductType.SportingActivities, 60, 1060)]
        [InlineData(1000, ProductType.Standard, 250, 1250)]
        public async Task SwedishVatTests(decimal price, ProductType productType, decimal expectedVat, decimal expectedPriceWithVat)
        {
            await PostProductAndAssertPrice(price, productType, expectedVat, expectedPriceWithVat, "SE");
        }

        [Theory]
        [InlineData(1000, ProductType.Flowers, 140, 1140)]
        [InlineData(1000, ProductType.Beverages, 140, 1140)]
        [InlineData(1000, ProductType.Books, 100, 1100)]
        [InlineData(1000, ProductType.Food, 140, 1140)]
        [InlineData(1000, ProductType.InternationalPassengerTransport, 0, 1000)]
        [InlineData(1000, ProductType.Newspapers, 100, 1100)]
        [InlineData(1000, ProductType.SportingActivities, 100, 1100)]
        [InlineData(1000, ProductType.Standard, 240, 1240)]
        public async Task FinnishVatTests(decimal price, ProductType productType, decimal expectedVat, decimal expectedPriceWithVat)
        {
            await PostProductAndAssertPrice(price, productType, expectedVat, expectedPriceWithVat, "FI");
        }

        [Fact]
        public async Task UnsupportedCountryTests()
        {
            await PostProductAndAssertPrice(1000, ProductType.Standard, 0, 1000, "NI");
        }

        [Theory]
        [InlineData(1000, ProductType.Flowers, 250, 1250)]
        [InlineData(1000, ProductType.Beverages, 250, 1250)]
        [InlineData(1000, ProductType.Books, 250, 1250)]
        [InlineData(1000, ProductType.Food, 250, 1250)]
        [InlineData(1000, ProductType.InternationalPassengerTransport, 0, 1000)]
        [InlineData(1000, ProductType.Newspapers, 0, 1000)]
        [InlineData(1000, ProductType.SportingActivities, 250, 1250)]
        [InlineData(1000, ProductType.Standard, 250, 1250)]
        public async Task DanishVatTests(decimal price, ProductType productType, decimal expectedVat, decimal expectedPriceWithVat)
        {
            await PostProductAndAssertPrice(price, productType, expectedVat, expectedPriceWithVat, "DK");
        }



        private async Task PostProductAndAssertPrice(decimal price, ProductType productType, decimal expectedVat,
            decimal expectedPriceWithVat, string countryCode)
        {
            var content = JsonConvert.SerializeObject(new Prd()
            {
                ProductType = productType,
                Price = price,
                CountryCode = countryCode
            });
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.PostAsync("vat-calc", byteContent);
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<Result>(await response.Content.ReadAsStringAsync());

            result.Tax.Should().Be(expectedVat);
            result.PriceWithTax.Should().Be(expectedPriceWithVat);
        }
    }
}
