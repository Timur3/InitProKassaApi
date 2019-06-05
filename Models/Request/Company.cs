using InitPro.Kassa.Api.Enums;

namespace InitPro.Kassa.Api.Models.Request
{
    public class Company
    {
        public string email { get; set; }
        public SNO sno { get; set; }
        public string inn { get; set; }
        public string payment_address { get; set; }
    }
}