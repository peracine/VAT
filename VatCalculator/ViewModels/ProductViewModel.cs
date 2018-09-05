using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using VatCalculator.Models;

namespace VatCalculator.ViewModels
{
    public class ProductViewModel
    {
        [JsonProperty("Price")]
        [DataType(DataType.Currency)]
        [Required]
        public decimal Price { get; internal set; }

        [JsonProperty("ProductType")]
        [JsonConverter(typeof(StringEnumConverter))]
        [EnumDataType(typeof(ProductType))]
        [Required]
        public ProductType ProductType { get; internal set; }

        public Product MapToProduct()
        {
            return new Product(Price, ProductType);
        }
    }
}
