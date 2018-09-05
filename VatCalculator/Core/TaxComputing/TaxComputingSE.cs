using VatCalculator.Models;

namespace VatCalculator.TaxComputing
{
    public class TaxComputingSE : BaseTaxComputing
    {
        public TaxComputingSE(Product product) : base(product)
        {
        }

        public override TaxIncludedPrice TaxIncludedPrice => GetTaxIncludedPrice(GetTaxByProductType(Product.ProductType));

        public override decimal GetTaxByProductType(ProductType productType)
        {
            switch (productType)
            {
                case ProductType.Food:
                    return 0.12m;
                case ProductType.SportingActivities:
                case ProductType.Books:
                case ProductType.Newspapers:
                    return 0.06m;
                case ProductType.InternationalPassengerTransport:
                    return 0;
                default:
                    return 0.25m;
            }
        }
    }
}
