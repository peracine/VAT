using VatCalculator.Models;
using VatCalculator.TaxComputing;

namespace VatCalculator.Services
{
    public interface ITaxComputingServices
    {
        TaxIncludedPrice GetTaxIncludedPrice(BaseTaxComputing taxComputing); 
    }
}
