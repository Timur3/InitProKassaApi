namespace InitPro.Kassa.Api.Models
{
    public class PayLoad
    {
        public decimal total { get; set; }                  // итоговая сумма
        public string fns_site { get; set; }                // Адрес сайта ФНС
        public string fn_number { get; set; }               // номер ФН
        public int shift_number { get; set; }               // номер смены
        public string receipt_datetime { get; set; }        // Дата и время документа из ФН 
        public int fiscal_receipt_number { get; set; }      // номер чека
        public int fiscal_document_number { get; set; }     // Фискальный номер документа
        public string ecr_registration_number { get; set; } // Регистрационный номер ККТ
        public int fiscal_document_attribute { get; set; }  // Фискальный признак документа
    }
}