
using Microsoft.Extensions.Logging;
using T_Store_CryptoSystem.BusinessLayer.Models;
using T_Store_CryptoSystem.BusinessLayer.Services.Interfaces;
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
