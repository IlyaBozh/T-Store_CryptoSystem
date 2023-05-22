
using Microsoft.Extensions.Logging;
using T_Store_CryptoSystem.BusinessLayer.Exceptions;
using T_Store_CryptoSystem.BusinessLayer.Models;
using T_Store_CryptoSystem.BusinessLayer.Services.Interfaces;

namespace T_Store_CryptoSystem.BusinessLayer.Services;

public class RateService : IRateService
{
    private readonly ILogger<RateService> _logger;
    private readonly object _locker = new object();

    public RateService(ILogger<RateService> logger) => _logger = logger;

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
        lock (_locker)
        {
            if (rates is null)
            {
                throw new ServiceUnavailableException("Rates is epmty");
            }
            _logger.LogInformation("Business layer: Convert to the dictionary currency rates wihtout base currency");
            RateModel.CurrencyRates = rates.ToDictionary(t => t.Key.Substring(3), t => t.Value);

            _logger.LogInformation("Business layer: Find base currency");
            RateModel.BaseCurrency = rates.GroupBy(k => k.Key.Remove(3))
                .FirstOrDefault()!
                .Key;
        }
    }
}
