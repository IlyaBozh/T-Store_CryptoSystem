
using CryptoSystem_NuGetPackage.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using T_Store_CryptoSystem.BusinessLayer.Services.Interfaces;

namespace T_Store_CryptoSystem.BusinessLayer.MassTransit;

public class RatesConsumer : IConsumer<NewRatesEvent>
{
    private readonly ILogger<RatesConsumer> _logger;
    private readonly IRateService _rateService;

    public RatesConsumer(ILogger<RatesConsumer> logger, IRateService rateService)
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
