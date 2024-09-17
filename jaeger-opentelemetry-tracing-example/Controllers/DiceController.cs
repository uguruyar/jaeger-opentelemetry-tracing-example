using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace jaeger_opentelemetry_tracing_example.Controllers;

[ApiController]
[Route("[controller]")]
public class DiceController(ILogger<DiceController> logger) : ControllerBase
{
    [HttpGet("rolldice/{player?}")]
    public IActionResult RollDice(string? player)
    {
        var result = Random.Shared.Next(1, 7);

        if (string.IsNullOrEmpty(player))
        {
            logger.LogInformation("Anonymous player is rolling the dice: {result}", result);
        }
        else
        {
            logger.LogInformation("{player} is rolling the dice: {result}", player, result);
        }
        
        return Ok(result.ToString(CultureInfo.InvariantCulture));
    }
}