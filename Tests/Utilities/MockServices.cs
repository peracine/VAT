using Moq;
using VatCalculator.Models;
using VatCalculator.Services;
using VatCalculator.TaxComputing;

namespace Tests
{
    public class MockServices
    {
        public Mock<ITaxComputingServices> MockTaxComputingServices { get; }

        public MockServices()
        {
            MockTaxComputingServices = SetTaxComputingServices(666, 666);
        }

        private static Mock<ITaxComputingServices> SetTaxComputingServices(decimal tax, decimal priceWithTax)
        {
            var taxComputingServices = new Mock<ITaxComputingServices>();
            taxComputingServices
                .Setup(s => s.GetTaxIncludedPrice(It.IsAny<BaseTaxComputing>()))
                .Returns(new TaxIncludedPrice(tax, priceWithTax));

            return taxComputingServices;
        }
    }
}
