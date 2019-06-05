using InitPro.Kassa.Api.Enums;

namespace InitPro.Kassa.Api.Models.Request
{
    public class Payment
    {
        public PaymentType type { get; set; }
        public decimal sum { get; set; }
    }
}
