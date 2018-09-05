using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using VatCalculator.Models;
using VatCalculator.Services;
using VatCalculator.TaxComputing;
using VatCalculator.ViewModels;

namespace VatCalculator.Controllers
{
    [Route("api/[controller]")]
    public class TaxController : Controller
    {
        private readonly ITaxComputingServices _taxComputingServices;

        public TaxController(ITaxComputingServices taxComputingServices)
        {
            _taxComputingServices = taxComputingServices;
        }

        [HttpGet]
        public IActionResult Get() => Ok("VatCalculator");

        [HttpPost]
        [Route("{countryCode}/VAT")]
        [ProducesResponseType(typeof(TaxIncludedPrice), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetTax(string countryCode, [FromBody]ProductViewModel product)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid parameters.");

            CountryCode country = CountryCode.Other;
            Enum.TryParse(countryCode.Trim(), true, out country);
            var taxComputing = TaxComputingFactory.GetTaxComputingByCountry(country, product.MapToProduct());
            return Ok(_taxComputingServices.GetTaxIncludedPrice(taxComputing));
        }
    }
}
