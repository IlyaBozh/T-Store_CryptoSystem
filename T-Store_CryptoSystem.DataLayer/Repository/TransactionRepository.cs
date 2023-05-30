
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;
using T_Store_CryptoSystem.DataLayer.Models;
using T_Store_CryptoSystem.DataLayer.Repository.interfaces;

namespace T_Store_CryptoSystem.DataLayer.Repository;

public class TransactionRepository : BaseRepository, ITransactionRepository
{
    private readonly ILogger<TransactionRepository> _logger;

    public TransactionRepository(IDbConnection dbConnection, ILogger<TransactionRepository> logger)
        : base(dbConnection)
    {
        _logger = logger;
    }

    public async Task<long> AddTransaction(TransactionDto transaction)
    {
        _logger.LogInformation("Data layer: Connection to data base");
        var parameters = new DynamicParameters(new
        {
            transaction.AccountId,
            transaction.TransactionType,
            transaction.Amount,
            transaction.Currency
        });
        parameters.Add("@Date", transaction.Date, DbType.DateTime2);

        var id = await _dbConnection.QueryFirstOrDefaultAsync<long>(
                  TransactionStoredProcedure.Transaction_Add,
                  param: parameters,
                  commandType: CommandType.StoredProcedure);

        _logger.LogInformation($"Data layer: Transaction {transaction.TransactionType} id {id} created");
        return id;
    }

    public async Task<List<long>> AddTransferTransactions(List<TransactionDto> transfer)
    {
        _logger.LogInformation("Data layer: Connection to data base");
        var transferIds = (await _dbConnection.QueryAsync<long>(
                  TransactionStoredProcedure.Transaction_AddTransfer,
                  param: new
                  {
                      AccountIdSender = transfer[0].AccountId,
                      AccountIdRecipient = transfer[1].AccountId,
                      Amount = (decimal)transfer[0].Amount,
                      AmountConverted = transfer[1].Amount,
                      CurrencySender = transfer[0].Currency,
                      CurrencyRecipient = transfer[1].Currency,
                  },
                  commandType: CommandType.StoredProcedure)).ToList();

        _logger.LogInformation($"Data layer:Transaction-{transfer[0].TransactionType}, ids {transferIds[0]}, {transferIds[1]} created");
        return transferIds;
    }

    public async Task<List<TransactionDto>> GetAllTransactionsByAccountId(long accountId)
    {
        _logger.LogInformation("Data layer: Connection to data base");
        var transactions = (await _dbConnection.QueryAsync<TransactionDto>(
                  TransactionStoredProcedure.Transaction_GetAllTransactionsByAccountId,
                  param: new { accountId },
                  commandType: CommandType.StoredProcedure)).ToList();

        _logger.LogInformation($"Data layer: Transactions by account id {accountId} returned to business");
        return transactions;
    }

    public async Task<decimal> GetBalanceByAccountId(long accountId)
    {
        _logger.LogInformation("Data layer: Connection to data base");
        var balance = await _dbConnection.QueryFirstOrDefaultAsync<decimal>(
                 TransactionStoredProcedure.Transaction_GetBalanceByAccountId,
                 param: new { accountId },
                 commandType: CommandType.StoredProcedure);

        _logger.LogInformation($"Data layer: Balance {balance} returned to business");
        return balance;
    }

    public async Task<TransactionDto?> GetTransactionById(long id)
    {
        _logger.LogInformation("Data layer: Connection to data base");
        var transaction = await _dbConnection.QueryFirstOrDefaultAsync<TransactionDto>(
                 TransactionStoredProcedure.Transaction_GetById,
                 param: new { id },
                 commandType: CommandType.StoredProcedure);

        _logger.LogInformation($"Data layer: Transaction id {id} returned to business");
        return transaction;
    }
}
