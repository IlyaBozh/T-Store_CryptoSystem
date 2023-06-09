﻿
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
        var result = 1m;

        lock (_locker)
        {
            _logger.LogInformation("Business layer: Call method GetRate");

            var rates = new Dictionary<string, decimal>();
            rates.Add("USDBITCOIN", (decimal)0.000000012);
            rates.Add("BITCOINUSD", (decimal)83333333.333);

            if (currencyFirst != currencySecond)
            {
                if ("USD" == currencyFirst || "USD" == currencySecond)
                {
                    _logger.LogInformation("Business layer: Calculate currency rate");
                    result = rates.ContainsKey(currencyFirst + currencySecond) is true ? rates[currencyFirst + currencySecond] : rates[currencySecond + currencyFirst];
                }
                else
                {
                    _logger.LogInformation("Business layer: Calculate currency rate");
                    result = rates[currencySecond] / rates[currencyFirst];
                }
            }
            return result;
        }
    }

    public Dictionary<string, decimal> GetRate()
    {
        if (RateModel.CurrencyRates is null || RateModel.CurrencyRates.Count == 0)
        {
            throw new ServiceUnavailableException("Rates is epmty");
        }
        _logger.LogInformation("Business layer: Currency rates returned");

        return RateModel.CurrencyRates;
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
