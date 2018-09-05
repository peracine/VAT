using VatCalculator.Models;

namespace VatCalculator.TaxComputing
{
    public class TaxComputingFactory
    {
        public static BaseTaxComputing GetTaxComputingByCountry(CountryCode countryCode, Product product)
        {
            switch (countryCode)
            {
                case CountryCode.DK: return new TaxComputingDK(product);
                case CountryCode.FI: return new TaxComputingFI(product);
                case CountryCode.NO: return new TaxComputingNO(product);
                case CountryCode.SE: return new TaxComputingSE(product);
                default: return new TaxComputingOther(product);
            }
        }
    }
}
