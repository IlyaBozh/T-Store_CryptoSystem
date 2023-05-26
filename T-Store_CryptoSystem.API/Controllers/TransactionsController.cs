using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using T_Store_CryptoSystem.API.Extensions;
using T_Store_CryptoSystem.API.Models.Request;
using T_Store_CryptoSystem.API.Models.Response;
using T_Store_CryptoSystem.BusinessLayer.Models;
using T_Store_CryptoSystem.BusinessLayer.Services.Interfaces;

namespace T_Store_CryptoSystem.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("transactions")]
public class TransactionsController : Controller
{
    private readonly ITransactionService _transactionServices;
    private readonly IMapper _mapper;
    private readonly ILogger<TransactionsController> _logger;

    public TransactionsController(ITransactionService transactionServices, IMapper mapper, ILogger<TransactionsController> logger)
    {
        _transactionServices = transactionServices;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpPost("deposit")]
    [ProducesResponseType(typeof(long), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<long>> AddDeposit([FromBody] TransactionRequest transaction)
    {
        _logger.LogInformation($"Controller: Call method AddDeposit, account id {transaction.AccountId}, " +
            $"amount {transaction.Amount}, {transaction.Currency}");
        var id = await _transactionServices.AddDeposit(_mapper.Map<TransactionModel>(transaction));

        _logger.LogInformation($"Controller: Id {id} returned");
        return Created($"{this.GetRequestPath()}/{id}", id);
    }

    [HttpPost("withdraw")]
    [ProducesResponseType(typeof(long), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<long>> Withdraw([FromBody] TransactionTransferRequest transaction)
    {
        _logger.LogInformation($"Controller: Call method Withdraw, accountId {transaction.AccountId}, amount {transaction.Amount}, {transaction.Currency}");
        var id = await _transactionServices.Withdraw(_mapper.Map<TransactionModel>(transaction));

        _logger.LogInformation($"Controller: Withdraw id {id} returned");
        return Created($"{this.GetRequestPath()}/{id}", id);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
    public async Task<ActionResult<TransactionResponse>> GetTransactionById([FromRoute] long id)
    {
        _logger.LogInformation($"Controller: Call method GetTransactionById, transaction id {id} ");
        var transaction = await _transactionServices.GetTransactionById(id);

        _logger.LogInformation($"Transaction id {transaction.Id}, account id {transaction.AccountId} returned");
        return Ok(_mapper.Map<TransactionResponse>(transaction));
    }
}
