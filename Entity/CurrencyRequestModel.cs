namespace CurrencyApplication.Entity;

public class CurrencyRequestModel
{
    public string FromCurrency { get; set; }
    public string ToCurrency { get; set; }
    public decimal Amount { get; set; }
}