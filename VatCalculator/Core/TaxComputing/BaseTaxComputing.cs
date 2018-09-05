using System;
using VatCalculator.Models;

namespace VatCalculator.TaxComputing
{
    public abstract class BaseTaxComputing
    {
        public Product Product { get; }

        public BaseTaxComputing(Product product) : base()
        {
            Product = product ?? throw new ArgumentNullException("Product cannot be null.");
        }

        private BaseTaxComputing()
        {
        }

        public TaxIncludedPrice GetTaxIncludedPrice(decimal tax)
        {
            return new TaxIncludedPrice(tax: Product.Price * tax, priceWithTax: Product.Price * (1 + tax));
        }

        public abstract TaxIncludedPrice TaxIncludedPrice { get; }

        public abstract decimal GetTaxByProductType(ProductType productType);
    }
}
