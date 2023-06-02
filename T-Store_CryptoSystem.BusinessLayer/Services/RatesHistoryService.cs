
using CryptoSystem_NuGetPackage.Events;
using IncredibleBackend.Messaging.Interfaces;
using Microsoft.Extensions.Logging;
using T_Store_CryptoSystem.BusinessLayer.Models;
using T_Store_CryptoSystem.BusinessLayer.Services.Interfaces;

namespace T_Store_CryptoSystem.BusinessLayer.Services;

public class RatesHistoryService : IRatesHistoryService
{
    private readonly ILogger<RatesHistoryService> _logger;
    private readonly IMessageProducer _messageProducer;
    private RateHistoryModel _historyModel;

    public RatesHistoryService(ILogger<RatesHistoryService> logger, IMessageProducer messageProducer)
    {
        _messageProducer = messageProducer;
        _logger = logger;
        _historyModel = new RateHistoryModel();
    }

    public async Task SaveRatesHistory(Dictionary<string, List<decimal>> history)
    {
        _historyModel.CurrencyHistoryRates = history;
    }

    public async Task<NewRatesHistoryEvent> SendInfo(RatesInfoEvent info)
    {
        _logger.LogInformation("Business layer: Send info");
        await _messageProducer.ProduceMessage(info, "Send rates to queue");

        _logger.LogInformation("Business layer: return rates history");

        NewRatesHistoryEvent result = new NewRatesHistoryEvent
        {
            RatesHistory = _historyModel.CurrencyHistoryRates
        };

        return result;
    }
}
