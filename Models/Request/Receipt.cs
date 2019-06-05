using InitPro.Kassa.Api.Models.Request;

namespace InitPro.Kassa.Api.Models
{
    public class Receipt
    {
        public Client client { get; set; }
        public Company company { get; set; }
        public Item[] items { get; set; }
        public Payment[] payments { get; set; }
        public Vat[] vats { get; set; }
        public decimal total { get; set; }
    }
}