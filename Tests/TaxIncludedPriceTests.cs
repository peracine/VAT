using VatCalculator.Models;
using VatCalculator.TaxComputing;
using Xunit;

namespace Tests
{
    public class TaxIncludedPriceTests
    {
        [Theory]
        [InlineData(1000, ProductType.Flowers, 250, 1250)]
        [InlineData(1000, ProductType.Beverages, 150, 1150)]
        [InlineData(1000, ProductType.Books, 250, 1250)]
        [InlineData(1000, ProductType.Food, 150, 1150)]
        [InlineData(1000, ProductType.InternationalPassengerTransport, 250, 1250)]
        [InlineData(1000, ProductType.Newspapers, 250, 1250)]
        [InlineData(1000, ProductType.SportingActivities, 120, 1120)]
        [InlineData(1000, ProductType.Standard, 250, 1250)]
        public void Get_TaxIncludedPrice_for_Norway(decimal price, ProductType productType, decimal expectedVat, decimal expectedPriceWithVat)
        {
            var taxComputing = new TaxComputingNO(new Product(price, productType));
            var result = taxComputing.TaxIncludedPrice;
            Assert.True(result.Tax == expectedVat && result.PriceWithTax == expectedPriceWithVat, $"Invalid resultat for {productType.ToString()} for Norway.");
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
        public void Get_TaxIncludedPrice_for_Sweden(decimal price, ProductType productType, decimal expectedVat, decimal expectedPriceWithVat)
        {
            var taxComputing = new TaxComputingSE(new Product(price, productType));
            var result = taxComputing.TaxIncludedPrice;
            Assert.True(result.Tax == expectedVat && result.PriceWithTax == expectedPriceWithVat, $"Invalid resultat for {productType.ToString()} for Sweden.");
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
        public void Get_TaxIncludedPrice_for_Finland(decimal price, ProductType productType, decimal expectedVat, decimal expectedPriceWithVat)
        {
            var taxComputing = new TaxComputingFI(new Product(price, productType));
            var result = taxComputing.TaxIncludedPrice;
            Assert.True(result.Tax == expectedVat && result.PriceWithTax == expectedPriceWithVat, $"Invalid resultat for {productType.ToString()} for Finland.");
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
        public void Get_TaxIncludedPrice_for_Denmark(decimal price, ProductType productType, decimal expectedVat, decimal expectedPriceWithVat)
        {
            var taxComputing = new TaxComputingDK(new Product(price, productType));
            var result = taxComputing.TaxIncludedPrice;
            Assert.True(result.Tax == expectedVat && result.PriceWithTax == expectedPriceWithVat, $"Invalid resultat for {productType.ToString()} for Denmark.");
        }

        [Theory]
        [InlineData(1000, ProductType.Flowers, 0, 1000)]
        [InlineData(1000, ProductType.Beverages, 0, 1000)]
        [InlineData(1000, ProductType.Books, 0, 1000)]
        [InlineData(1000, ProductType.Food, 0, 1000)]
        [InlineData(1000, ProductType.InternationalPassengerTransport, 0, 1000)]
        [InlineData(1000, ProductType.Newspapers, 0, 1000)]
        [InlineData(1000, ProductType.SportingActivities, 0, 1000)]
        [InlineData(1000, ProductType.Standard, 0, 1000)]
        public void Get_TaxIncludedPrice_for_Other_countries(decimal price, ProductType productType, decimal expectedVat, decimal expectedPriceWithVat)
        {
            var taxComputing = new TaxComputingOther(new Product(price, productType));
            var result = taxComputing.TaxIncludedPrice;
            Assert.True(result.Tax == expectedVat && result.PriceWithTax == expectedPriceWithVat, $"Invalid resultat for {productType.ToString()} for Other countries.");
        }
    }
}
