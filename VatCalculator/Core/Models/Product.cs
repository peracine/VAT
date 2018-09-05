namespace VatCalculator.Models
{
    public class Product
    {
        public decimal Price { get; }
        public ProductType ProductType { get; }

        private Product()
        {
        }

        public Product(decimal price, ProductType productType)
        {
            Price = price;
            ProductType = productType;
        }
    }
}
