
using CryptoSystem_NuGetPackage.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using T_Store_CryptoSystem.BusinessLayer.Services.Interfaces;

namespace T_Store_CryptoSystem.BusinessLayer.MassTransit;

public class RateHistoryConsumer : IConsumer<NewRatesHistoryEvent>
{
    private readonly ILogger<RateHistoryConsumer> _logger;

    public RateHistoryConsumer(ILogger<RateHistoryConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<NewRatesHistoryEvent> context)
    {
        _logger.LogInformation($"RateHistoryConsumer: Save actual rates in model");
    }
}