using System;
using VatCalculator.Models;
using VatCalculator.TaxComputing;

namespace VatCalculator.Services
{
    public class TaxComputingServices : ITaxComputingServices
    {
        public TaxIncludedPrice GetTaxIncludedPrice(BaseTaxComputing taxComputing)
        {
            if (taxComputing == null)
                throw new ArgumentNullException("taxComputing cannot be null.");

            return taxComputing.TaxIncludedPrice;
        }
    }
}
