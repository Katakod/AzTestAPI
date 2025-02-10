using Microsoft.AspNetCore.Mvc;

namespace AzTestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodingForecastController : ControllerBase
    {
        private static readonly string[] Forecasts = new[]
        {
            "Horrific", "Smelly", "Clean", "Dry", "Solid", "Monolithic", "Scalable", "Hacked"
        };

        private readonly ILogger<CodingForecastController> _logger;

        public CodingForecastController(ILogger<CodingForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCodingForecast")]
        public IEnumerable<CodingForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new CodingForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Probablility = Random.Shared.Next(1, 100),
                Forecast = Forecasts[Random.Shared.Next(Forecasts.Length)]
            })
            .ToArray();
        }
    }
}
