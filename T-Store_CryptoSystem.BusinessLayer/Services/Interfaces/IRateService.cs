
namespace T_Store_CryptoSystem.BusinessLayer.Services.Interfaces;

public interface IRateService
{
    public void SaveCurrencyRate(Dictionary<string, decimal> rates);
    public Dictionary<string, decimal> GetRate();
    public decimal GetCurrencyRate(string currencyFirst, string currencySecond);
}
