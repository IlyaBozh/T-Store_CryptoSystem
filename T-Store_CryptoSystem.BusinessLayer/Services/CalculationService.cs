
using T_Store_CryptoSystem.BusinessLayer.Models;
using T_Store_CryptoSystem.BusinessLayer.Services.Interfaces;

namespace T_Store_CryptoSystem.BusinessLayer.Services;

public class CalculationService : ICalculationService
{
    public Task<List<TransactionModel>> ConvertCurrency(List<TransactionModel> transferModels)
    {
        throw new NotImplementedException();
    }
}
