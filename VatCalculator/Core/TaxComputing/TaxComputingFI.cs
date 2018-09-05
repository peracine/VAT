using VatCalculator.Models;

namespace VatCalculator.TaxComputing
{
    public class TaxComputingFI : BaseTaxComputing
    {
        public TaxComputingFI(Product product) : base(product)
        {
        }

        public override TaxIncludedPrice TaxIncludedPrice => GetTaxIncludedPrice(GetTaxByProductType(Product.ProductType));

        public override decimal GetTaxByProductType(ProductType productType)
        {
            switch (productType)
            {
                case ProductType.Food:
                case ProductType.Beverages:
                case ProductType.Flowers:
                    return 0.14m;
                case ProductType.SportingActivities:
                case ProductType.Books:
                case ProductType.Newspapers:
                    return 0.10m;
                case ProductType.InternationalPassengerTransport:
                    return 0;
                default:
                    return 0.24m;
            }
        }
    }
}
