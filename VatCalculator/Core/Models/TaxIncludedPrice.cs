namespace VatCalculator.Models
{
    public class TaxIncludedPrice
    {
        public decimal Tax { get; }
        public decimal PriceWithTax { get; }

        public TaxIncludedPrice(decimal tax, decimal priceWithTax)
        {
            Tax = tax;
            PriceWithTax = priceWithTax;
        }
    }
}
