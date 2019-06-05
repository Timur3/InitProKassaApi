namespace InitPro.Kassa.Api.Enums
{
    public enum Operation
    {
        sell,               //чек «Приход»
        sell_refund,        //чек «Возврат прихода»
        sell_correction,    //чек «Коррекция прихода»
        buy,                //чек «Расход»
        buy_refund,         //чек «Возврат расхода»
        buy_correction      //чек «Коррекция расхода»
    }
}
