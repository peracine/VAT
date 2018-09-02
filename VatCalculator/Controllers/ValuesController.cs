using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace VatCalculator.Controllers
{
    [Route("vat-calc")]
    public class ValuesController : Controller
    {
        [HttpPost]
        public Result GetTax([FromBody]Prd value)
        {
            var r = new RegionInfo(value.CountryCode);
            switch (r.EnglishName)
            {
                case "Norway":
                    switch (value.ProductType)
                    {
                        case ProductType.Food:
                        case ProductType.Beverages:
                            var result1 = new Result();
                            var x1 = value.Price * (decimal)0.15;
                            decimal y1 = value.Price + x1;
                            result1.PriceWithTax = y1;
                            result1.Tax = x1;
                            return result1;
                        case ProductType.SportingActivities:
                            var result2 = new Result();
                            var x2 = value.Price * (decimal)0.12;
                            decimal y2 = value.Price + x2;
                            result2.PriceWithTax = y2;
                            result2.Tax = x2;
                            return result2;
                        case ProductType.Standard:
                        default:
                            var result = new Result();
                            var x = value.Price * (decimal)0.25;
                            decimal y = value.Price + x;
                            result.PriceWithTax = y;
                            result.Tax = x;
                            return result;
                    }
                case "Sweden":
                    switch (value.ProductType)
                    {
                        case ProductType.Food:
                            var result1 = new Result();
                            var x1 = value.Price * (decimal)0.12;
                            decimal y1 = value.Price + x1;
                            result1.PriceWithTax = y1;
                            result1.Tax = x1;
                            return result1;
                        case ProductType.SportingActivities:
                        case ProductType.Books:
                        case ProductType.Newspapers:
                            var result2 = new Result();
                            var x2 = value.Price * (decimal)0.06;
                            decimal y2 = value.Price + x2;
                            result2.PriceWithTax = y2;
                            result2.Tax = x2;
                            return result2;
                        case ProductType.InternationalPassengerTransport:
                            var result3 = new Result();
                            var x3 = value.Price * (decimal)0;
                            decimal y3 = value.Price + x3;
                            result3.PriceWithTax = y3;
                            result3.Tax = x3;
                            return result3;
                        case ProductType.Standard:
                        default:
                            var result = new Result();
                            var x = value.Price * (decimal)0.25;
                            decimal y = value.Price + x;
                            result.PriceWithTax = y;
                            result.Tax = x;
                            return result;
                    }
                case "Finland":
                    switch (value.ProductType)
                    {
                        case ProductType.Food:
                        case ProductType.Beverages:
                        case ProductType.Flowers:
                            var result2 = new Result();
                            var x2 = value.Price * (decimal)0.14;
                            decimal y2 = value.Price + x2;
                            result2.PriceWithTax =y2;
                            result2.Tax = x2;
                            return result2;
                        case ProductType.SportingActivities:
                        case ProductType.Books:
                        case ProductType.Newspapers:
                            var result3 = new Result();
                            var x3 = value.Price * (decimal)0.10;
                            decimal y3 = value.Price + x3;
                            result3.PriceWithTax =y3;
                            result3.Tax = x3;
                            return result3;
                        case ProductType.InternationalPassengerTransport:
                            var result4 = new Result();
                            var x4 = value.Price * (decimal)0;
                            decimal y4 = value.Price + x4;
                            result4.PriceWithTax =y4;
                            result4.Tax = x4;
                            return result4;
                        case ProductType.Standard:
                        default:
                            var result = new Result();
                            var x = value.Price * (decimal)0.24;
                            decimal y = value.Price + x;
                            result.PriceWithTax = y;
                            result.Tax = x;
                            return result;

                    }
                    break;
            }

            return new Result
            {
                PriceWithTax = value.Price
            };
        }
    }

    public class Result
    {
        public decimal Tax { get; set; }
        public decimal PriceWithTax { get; set; }
    }

    public class Prd
    {
        public decimal Price { get; set; }
        public ProductType ProductType { get; set; }
        public string CountryCode { get; set; }
    }

    public enum ProductType
    {
        Standard,
        Food,
        Beverages,
        SportingActivities,
        Books,
        Newspapers,
        InternationalPassengerTransport,
        Flowers
    }
}
