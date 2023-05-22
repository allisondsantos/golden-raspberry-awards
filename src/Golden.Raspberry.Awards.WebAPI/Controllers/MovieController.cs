using Microsoft.AspNetCore.Mvc;

namespace Golden.Raspberry.Awards.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly ILogger<MovieController> _logger;

    public MovieController(ILogger<MovieController> logger)
    {
        _logger = logger;
    }

    [HttpGet("award-range")]
    public IActionResult GetAwardRange()
    {
        try
        {
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, nameof(GetAwardRange));
            throw;
        }
        
    }
}
