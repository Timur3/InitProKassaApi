using InitPro.Kassa.Api.Enums;

namespace InitPro.Kassa.Api.Models.Request
{
    public class Item
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public decimal sum { get; set; }
        public string measurement_unit { get; set; }
        public PaymentMethod payment_method { get; set; }
        public PaymentObject payment_object { get; set; }
        public Vat vat { get; set; }
        public AgentInfo agent_info { get; set; }
    }
}