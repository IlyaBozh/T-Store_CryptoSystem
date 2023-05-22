
using T_Store_CryptoSystem.BusinessLayer.Models;

namespace T_Store_CryptoSystem.BusinessLayer.Services.Interfaces;

public interface ICalculationService
{
    public Task<List<TransactionModel>> ConvertCurrency(List<TransactionModel> transferModels);
}