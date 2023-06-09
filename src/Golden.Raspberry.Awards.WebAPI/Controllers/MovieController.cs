using Golden.Raspberry.Awards.WebAPI.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Golden.Raspberry.Awards.WebAPI.Controllers;


[ApiController]
[Route("api/movies")]
public class MovieController : ControllerBase
{
    private readonly ILogger<MovieController> _logger;
    private readonly AwardRangeCommandHandler _handler;

    public MovieController(
        ILogger<MovieController> logger,
        AwardRangeCommandHandler handler)
    {
        _logger = logger;
        _handler = handler;
    }

    [HttpGet("award-range")]
    [ProducesResponseType(typeof(AwardRangeResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<AwardRangeResponse>> GetAwardRange()
    {
        try
        {
            return Ok(await _handler.HandlerAsync());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, nameof(GetAwardRange));
            throw;
        }        
    }
}