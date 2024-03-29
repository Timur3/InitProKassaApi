﻿using InitPro.Kassa.Api.Enums;

namespace InitPro.Kassa.Api.Models.Request
{
    public class Item
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
        public decimal sum { get; set; }
        public string measurement_unit { get; set; }
        public string payment_method { get; set; }
        public string payment_object { get; set; }
        public Vat vat { get; set; }
        public AgentInfo agent_info { get; set; }
    }
}