using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace KrchEmployees.Controllers;

[Route("[controller]")]
[ApiController]
public class WeatherForecastController : ControllerBase
{
    private ILoggerManager _logger;

    public WeatherForecastController(ILoggerManager logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<string> Get()
    {
        _logger.LogInfo("Here is an info message from our values controller.");
        _logger.LogDebug("Here is a debug message from our values controller.");
        _logger.LogWarn("Here is a warn message from our values controller.");
        _logger.LogError("Here is an error message from our values controller.");

        return new string[] { "value1", "value2" };
    }
}