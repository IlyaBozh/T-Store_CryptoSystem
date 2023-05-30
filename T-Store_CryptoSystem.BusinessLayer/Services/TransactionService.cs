
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Transactions;
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
    
    public async Task<List<long>> Withdraw(List<TransactionModel> transactions)
    {
        int senderIndex = 0;
        int recipientIndex = 1;

        _logger.LogInformation($"Business layer: Check balance by account id {transactions[senderIndex].AccountId}");
        await CheckBalance(transactions[senderIndex]);

        var transfersConvert = await _calculationService.ConvertCurrency(transactions);

        _logger.LogInformation("Business layer: Query to data base for add transfers");
        var transferResult = await _transactionRepository.AddTransferTransactions(_mapper.Map<List<TransactionDto>>(transfersConvert));

        return transferResult;
    }

    public async Task<decimal?> GetBalanceByAccountId(long accountId)
    {
        _logger.LogInformation("Business layer: Query in data base for received balance");
        var balance = await _transactionRepository.GetBalanceByAccountId(accountId);

        _logger.LogInformation($"Business layer: Balance by account id {accountId} returned to controller");
        return balance;
    }

    public async Task<TransactionModel?> GetTransactionById(long id)
    {
        _logger.LogInformation("Business layer: Query in data base for transaction receiving");
        var transaction = await _transactionRepository.GetTransactionById(id);

        if (transaction is null)
        {
            throw new EntityNotFoundException($"Transaction {id} not found");
        }

        _logger.LogInformation("Business layer: Transaction returned to controller");
        return _mapper.Map<TransactionModel>(transaction);
    }

    public async Task<Dictionary<DateTime, List<TransactionModel>>> GetTransactionsByAccountId(long accountId)
    {
        _logger.LogInformation($"Business layer: Query in database for transaction by accountId {accountId}");
        var transactions = await _transactionRepository.GetAllTransactionsByAccountId(accountId);

        _logger.LogInformation($"Business layer: Add transactions in dictionary");
        var transactionsDictionary = _mapper.Map<List<TransactionDto>, List<TransactionModel>>(transactions)
            .GroupBy(t => t.Date)
            .ToDictionary(date => date.Key, transactions => transactions
            .ToList());

        _logger.LogInformation("Business layer: Transactions returned to controller");
        return transactionsDictionary;
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
