using VatCalculator.Models;

namespace VatCalculator.TaxComputing
{
    public class TaxComputingNO : BaseTaxComputing
    {
        public TaxComputingNO(Product product) : base(product)
        {
        }

        public override TaxIncludedPrice TaxIncludedPrice => GetTaxIncludedPrice(GetTaxByProductType(Product.ProductType));

        public override decimal GetTaxByProductType(ProductType productType)
        {
            switch (productType)
            {
                case ProductType.Food:
                case ProductType.Beverages:
                    return 0.15m;
                case ProductType.SportingActivities:
                    return 0.12m;
                default:
                    return 0.25m;
            }
        }
    }
}
