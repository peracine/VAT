using VatCalculator.Models;

namespace VatCalculator.TaxComputing
{
    public class TaxComputingDK : BaseTaxComputing
    {
        public TaxComputingDK(Product product) : base(product)
        {
        }

        public override TaxIncludedPrice TaxIncludedPrice => GetTaxIncludedPrice(GetTaxByProductType(Product.ProductType));

        public override decimal GetTaxByProductType(ProductType productType)
        {
            switch (productType)
            {
                case ProductType.Newspapers:
                case ProductType.InternationalPassengerTransport:
                    return 0;
                default:
                    return 0.25m;
            }
        }
    }
}
