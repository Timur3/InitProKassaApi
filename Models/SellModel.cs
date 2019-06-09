using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InitPro.Kassa.Api.Models
{
    public class SellModel
    {
        public string Token { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Sum { get; set; }
        public string MeasurementUnit { get; set; }
    }
}
