using System;
using InitPro.Kassa.Api.Enums;

namespace InitPro.Kassa.Api.Helpers
{
    public class VatHelper
    {
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
            return Math.Round(x,2);
        }
    }
}
