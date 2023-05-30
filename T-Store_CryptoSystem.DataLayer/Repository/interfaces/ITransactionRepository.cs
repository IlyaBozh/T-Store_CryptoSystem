
using T_Store_CryptoSystem.DataLayer.Models;

namespace T_Store_CryptoSystem.DataLayer.Repository.interfaces;

public interface ITransactionRepository
{
    public Task<long> AddTransaction(TransactionDto transaction);
    public Task<decimal> GetBalanceByAccountId(long accountId);
    public Task<TransactionDto?> GetTransactionById(long id);
    public Task<List<TransactionDto>> GetAllTransactionsByAccountId(long accountId);
    public Task<List<long>> AddTransferTransactions(List<TransactionDto> transfer);
}
