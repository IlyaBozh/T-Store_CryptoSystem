
using CryptoSystem_NuGetPackage.Events;
using Microsoft.AspNetCore.Mvc;
using T_Store_CryptoSystem.BusinessLayer.Services.Interfaces;

namespace T_Store_CryptoSystem.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("ratesHistory")]
public class RatesHistoryController : Controller
{
    private readonly IRatesHistoryService _ratesHistoryService;
    private readonly ILogger<RatesHistoryController> _logger;

    public RatesHistoryController(ILogger<RatesHistoryController> logger, IRatesHistoryService ratesHistoryService)
    {
        _ratesHistoryService = ratesHistoryService;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
    public async Task<ActionResult<NewRatesHistoryEvent>> GetTransactionById([FromBody] RatesInfoEvent info)
    {
        _logger.LogInformation($"Controller: Call method SendInfo");
        var history = await _ratesHistoryService.SendInfo(info);

        _logger.LogInformation($"history returned");
        return Ok(history);
    }
}