using Microsoft.AspNetCore.Mvc;

namespace AzTestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodingForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
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
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
