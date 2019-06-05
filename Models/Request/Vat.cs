using InitPro.Kassa.Api.Enums;

namespace InitPro.Kassa.Api.Models
{
    public class Vat
    {
        public VatType type { get; set; }
        public decimal sum { get; set; }
    }
}