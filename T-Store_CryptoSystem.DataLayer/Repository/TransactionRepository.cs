﻿
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

    public Task<List<TransactionDto>> GetAllTransactionsByAccountId(long accountId)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> GetBalanceByAccountId(long accountId)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionDto?> GetTransactionById(long id)
    {
        throw new NotImplementedException();
    }
}
