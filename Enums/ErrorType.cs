using System.ComponentModel;

namespace InitPro.Kassa.Api.Enums
{
    public enum ErrorType
    {
        [Description("Системная ошибка")]
        system,
        [Description("Неизвестная ошибка")]
        unknown
    }
}
