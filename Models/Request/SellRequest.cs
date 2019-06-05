using System;

namespace InitPro.Kassa.Api.Models
{
    public class SellRequest
    {
        public string external_id { get; set; }     // ID платежа из моей базы
        public Receipt receipt { get; set; }
        public Service service { get; set; }
        public DateTime timestamp { get; set; }
    }
}