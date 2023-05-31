
using IncredibleBackendContracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using T_Store_CryptoSystem.BusinessLayer.Models;
using T_Store_CryptoSystem.BusinessLayer.Services.Interfaces;

namespace T_Store_CryptoSystem.BusinessLayer.MassTransit;

public class Consumer : IConsumer<NewRatesEvent>
{
    private readonly ILogger<Consumer> _logger;
    private readonly IRateService _rateService;

    public Consumer(ILogger<Consumer> logger, IRateService rateService)
    {
        _logger = logger;
        _rateService = rateService;
    }

    public async Task Consume(ConsumeContext<NewRatesEvent> context)
    {
        _logger.LogInformation($"RateConsumer: Save actual rates in model");
        _rateService.SaveCurrencyRate(context.Message.Rates);
    }
}
