using InitPro.Kassa.Api.Enums;

namespace InitPro.Kassa.Api.Models
{
    public class Error
    {
        public string error_id { get; set; }  //уникальный идентификатор ошибки
        public int code { get; set; }  //код ошибки
        public string text { get; set; }  //текст ошибки
        public ErrorType type { get; set; }  //тип ошибки
    }
}