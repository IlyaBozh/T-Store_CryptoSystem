
using AutoMapper;
using Microsoft.Extensions.Logging;
using T_Store_CryptoSystem.BusinessLayer.Exceptions;
using T_Store_CryptoSystem.BusinessLayer.Models;
using T_Store_CryptoSystem.BusinessLayer.Services.Interfaces;
using T_Store_CryptoSystem.DataLayer.Enums;
using T_Store_CryptoSystem.DataLayer.Models;
using T_Store_CryptoSystem.DataLayer.Repository.interfaces;

namespace T_Store_CryptoSystem.BusinessLayer.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly ICalculationService _calculationService;
    private readonly ILogger<TransactionService> _logger;
    private readonly IMapper _mapper;

    public TransactionService(ITransactionRepository transactionRepository, ICalculationService calculationService,
        IMapper mapper, ILogger<TransactionService> logger)
    {
        _transactionRepository = transactionRepository;
        _calculationService = calculationService;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<long> AddDeposit(TransactionModel transaction)
    {
        transaction.TransactionType = TransactionType.Deposit;

        _logger.LogInformation("Business layer: Query to data base for add transaction");
        var transactionIdResult = await _transactionRepository.AddTransaction(_mapper.Map<TransactionDto>(transaction));

        return transactionIdResult;
    }
    
    public async Task<long> Withdraw(TransactionModel transaction)
    {
        _logger.LogInformation($"Business layer: Check balance for account id {transaction.AccountId}");
        await CheckBalance(transaction);

        transaction.TransactionType = TransactionType.Withdraw;
        transaction.Amount *= -1;

        _logger.LogInformation("Business layer: Query to data base for add withdraw");
        var transactionIdResult = await _transactionRepository.AddTransaction(_mapper.Map<TransactionDto>(transaction));

        return transactionIdResult;
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

    private async Task CheckBalance(TransactionModel transaction)
    {
        _logger.LogInformation("Business layer: Query in data base for received balance");
        var balance = await _transactionRepository.GetBalanceByAccountId(transaction.AccountId);
        if (transaction.Amount > balance)
        {
            throw new BalanceExceedException($"You have not a enough money on balance");
        }
    }
}
