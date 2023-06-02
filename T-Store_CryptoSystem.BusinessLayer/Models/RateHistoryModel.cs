namespace T_Store_CryptoSystem.BusinessLayer.Models;

public class RateHistoryModel
{
    public Dictionary<string, List<decimal>> CurrencyHistoryRates { get; set; }

    public RateHistoryModel()
    {
        CurrencyHistoryRates = new Dictionary<string, List<decimal>>();
    }
}