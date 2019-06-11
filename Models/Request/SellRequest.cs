using System;
using System.ComponentModel.DataAnnotations;

namespace InitPro.Kassa.Api.Models.Request
{
    public class SellRequest
    {
        public string external_id { get; set; }     // ID платежа из моей базы
        public Receipt receipt { get; set; }
        public Service service { get; set; }
        public string timestamp { get; set; }
    }
}