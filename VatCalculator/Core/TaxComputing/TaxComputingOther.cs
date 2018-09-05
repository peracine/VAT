using VatCalculator.Models;

namespace VatCalculator.TaxComputing
{
    public class TaxComputingOther : BaseTaxComputing
    {
        public TaxComputingOther(Product product) : base(product)
        {
        }

        public override TaxIncludedPrice TaxIncludedPrice => GetTaxIncludedPrice(GetTaxByProductType(Product.ProductType));

        public override decimal GetTaxByProductType(ProductType productType)
        {
            return 0;
        }
    }
}