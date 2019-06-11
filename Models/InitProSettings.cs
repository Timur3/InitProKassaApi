using InitPro.Kassa.Api.Enums;

namespace InitPro.Kassa.Api.Models
{
    public class InitProSettings
    {
        public string BaseUrl { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public string GroupCode { get; set; }
        public string Email { get; set; }
        public string Sno { get; set; }
        public string Inn { get; set; }
        public string Payment_address { get; set; }
    }
}
