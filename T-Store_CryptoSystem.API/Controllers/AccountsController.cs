﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using T_Store_CryptoSystem.API.Models.Response;
using T_Store_CryptoSystem.BusinessLayer.Services.Interfaces;

namespace T_Store_CryptoSystem.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("accounts")]
public class AccountsController : Controller
{
    private readonly ITransactionService _transactionServices;
    private readonly IMapper _mapper;
    private readonly ILogger<AccountsController> _logger;

    public AccountsController(ITransactionService transactionServices, IMapper mapper, ILogger<AccountsController> logger)
    {
        _transactionServices = transactionServices;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet("{id}/balance")]
    [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
    public async Task<ActionResult<decimal>> GetBalanceByAccountId([FromRoute] long id)
    {
        _logger.LogInformation($"Controller: Call method GetBalanceByAccountId {id}");

        return Ok(await _transactionServices.GetBalanceByAccountId(id));
    }

    [HttpGet("{id}/transactions")]
    [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTransactionsByAccountId([FromRoute] long id)
    {
        _logger.LogInformation($"Controller: Call method GetTransactionByAccountId {id}");
        var transactions = await _transactionServices.GetTransactionsByAccountId(id);

        var transactionsModel = _mapper.Map<List<TransactionResponse>>(transactions);

        _logger.LogInformation($"Controller: Transactions returned by accountId {id}");
        return Ok(transactionsModel);
    }
}
