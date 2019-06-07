using System;

namespace InitPro.Kassa.Api.Models.Response
{
    public class Token
    {
        public Error error { get; set; }
        public DateTime timestamp { get; set; }
    }

    public class TokenRequest
    {
        public string login { get; set; }
        public string pass { get; set; }
    }

    public class TokenResponse : Token
    {
        public string token { get; set; }
    }
}
