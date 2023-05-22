
using T_Store_CryptoSystem.BusinessLayer.Models;

namespace T_Store_CryptoSystem.BusinessLayer.Services.Interfaces;

public interface ITransactionService
{
    public Task<long> AddDeposit(TransactionModel transaction);
    public Task<decimal?> GetBalanceByAccountId(long accountId);
    public Task<TransactionModel?> GetTransactionById(long id);
    public Task<Dictionary<DateTime, List<TransactionModel>>> GetTransactionsByAccountId(long accountId);
    public Task<long> Withdraw(TransactionModel transaction);
}
