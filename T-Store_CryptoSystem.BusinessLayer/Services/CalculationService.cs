
using CryptoSystem_NuGetPackage.Enums;
using Microsoft.Extensions.Logging;
using T_Store_CryptoSystem.BusinessLayer.Models;
using T_Store_CryptoSystem.BusinessLayer.Services.Interfaces;

namespace T_Store_CryptoSystem.BusinessLayer.Services;

public class CalculationService : ICalculationService
{
    private readonly ILogger<CalculationService> _logger;
    private readonly IRateService _rateService;

    public CalculationService(ILogger<CalculationService> logger, IRateService rateService)
    {
        _logger = logger;
        _rateService = rateService;
    }

    public async Task<List<TransactionModel>> ConvertCurrency(List<TransactionModel> transferModels)
    {
        var senderIndex = 0;
        var recipientIndex = 1;

        _logger.LogInformation("Business layer: Call GetCurrencyRate method");
        var crossRate = _rateService.GetCurrencyRate(transferModels[senderIndex].Currency.ToString(), transferModels[recipientIndex].Currency.ToString());

        transferModels[recipientIndex].Amount = transferModels[senderIndex].Amount * crossRate;
        transferModels[recipientIndex].TransactionType = TransactionType.Deposit;
        transferModels[senderIndex].Amount *= -1;

        _logger.LogInformation("Business layer: Transfers converted returned");
        
        return transferModels;
    }
}
