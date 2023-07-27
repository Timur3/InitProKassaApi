using System;
using InitPro.Kassa.Api.Enums;
using Microsoft.Extensions.Logging;

namespace InitPro.Kassa.Api.Helpers
{
    public class VatHelper
    {
        private readonly ILogger<VatHelper> _logger;

        public VatHelper(ILogger<VatHelper> logger)
        {
            _logger = logger;
        }
        
        public decimal GetVatSum(decimal sum, VatType vatType)
        {
            decimal x = 0;
            switch(vatType)
            {
                case VatType.vat10:
                    x = sum * (decimal)0.1;
                    break;
                case VatType.vat20:
                    x = sum * (decimal)0.2;
                    break;
                default:
                    x = sum;
                    break;
            }
            decimal vat = Math.Round(x,2);
            
            _logger.LogDebug("Calculated VAT tax value for {Summa} payment amount with {VatRate} rate is {VatSumma}", sum, vatType, vat);
            
            return vat;
        }
    }
}
