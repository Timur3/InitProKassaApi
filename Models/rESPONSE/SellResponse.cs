using InitPro.Kassa.Api.Enums;

namespace InitPro.Kassa.Api.Models.Response
{
    public class SellResponse
    {
        public string uuid { get; set; }
        public string timestamp { get; set; }
        public Error error { get; set; }
        public Status status { get; set; }
    }
}
