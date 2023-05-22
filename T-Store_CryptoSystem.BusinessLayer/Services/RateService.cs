
using T_Store_CryptoSystem.BusinessLayer.Services.Interfaces;

namespace T_Store_CryptoSystem.BusinessLayer.Services;

public class RateService : IRateService
{
    public decimal GetCurrencyRate(string currencyFirst, string currencySecond)
    {
        throw new NotImplementedException();
    }

    public Dictionary<string, decimal> GetRate()
    {
        throw new NotImplementedException();
    }

    public void SaveCurrencyRate(Dictionary<string, decimal> rates)
    {
        throw new NotImplementedException();
    }
}
