
namespace InitPro.Kassa.Api.Models
{
    public class SellModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ItemName { get; set; }        // наименование позиции
        public decimal Price { get; set; }          // стоимость, указываем сумму за ЭЭ
        public decimal Quantity { get; set; }       // в нашем случае всегда будет 1
        public string MeasurementUnit { get; set; } // единица измерения кВт\ч
    }
}
