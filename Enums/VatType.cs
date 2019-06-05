namespace InitPro.Kassa.Api.Enums
{
    public enum VatType
    {
        none,       //без НДС;
        vat,        //НДС по ставке 0%;
        vat10,      //НДС чека по ставке 10%;
        vat20       //НДС чека по ставке 20%;
    }
}