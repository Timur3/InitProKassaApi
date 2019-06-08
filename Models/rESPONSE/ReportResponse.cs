using System;
using InitPro.Kassa.Api.Enums;

namespace InitPro.Kassa.Api.Models.Response
{
    public class ReportResponse
    {
        public Error error { get; set; }
        public Status status { get; set; }
        public PayLoad payloud { get; set; }
        public DateTime timestamp { get; set; }
        public string group_code { get; set; }
        public string daemon_code { get; set; }
        public string device_code { get; set; }
        public int external_id { get; set; }        // ID платежа из моей базы
        public string callback_url { get; set; }
    }
}
