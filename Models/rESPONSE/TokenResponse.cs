using System;

namespace InitPro.Kassa.Api.Models.Response
{
    public class TokenResponse
    {
        public Error error { get; set; }
        public string token { get; set; }
        public string timestamp { get; set; }
    }
}
