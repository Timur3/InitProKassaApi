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
                    x = (sum * (10 / 100));
                    break;
                case VatType.vat20:
                    x = (sum * (20/100));
                    break;
                default:
                    x = sum;
                    break;
            }
            return x;
        }
    }
}
