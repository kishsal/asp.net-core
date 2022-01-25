using Microsoft.AspNetCore.Mvc;

namespace _2_DependencyInjection.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private readonly DependencyService1 dependencyService1;

    private readonly DependencyService2 dependencyService2;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        DependencyService1 dependencyService1,
        DependencyService2 dependencyService2)
    {
        _logger = logger;
        this.dependencyService1 = dependencyService1;
        this.dependencyService2 = dependencyService2;
        _logger.LogInformation("Hello from WeatherForecast");
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        dependencyService1.Write();
        dependencyService2.Write();
        return Enumerable.Empty<WeatherForecast>();
    }
}
