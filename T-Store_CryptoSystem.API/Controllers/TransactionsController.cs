using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
}
