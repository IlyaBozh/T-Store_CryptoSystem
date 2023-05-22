
using T_Store_CryptoSystem.BusinessLayer.Models;
using T_Store_CryptoSystem.BusinessLayer.Services.Interfaces;

namespace T_Store_CryptoSystem.BusinessLayer.Services;

public class TransactionService : ITransactionService
{
    public Task<long> AddDeposit(TransactionModel transaction)
    {
        throw new NotImplementedException();
    }

    public Task<decimal?> GetBalanceByAccountId(long accountId)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionModel?> GetTransactionById(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Dictionary<DateTime, List<TransactionModel>>> GetTransactionsByAccountId(long accountId)
    {
        throw new NotImplementedException();
    }

    public Task<long> Withdraw(TransactionModel transaction)
    {
        throw new NotImplementedException();
    }
}
