using Microsoft.AspNetCore.Mvc;

namespace talkingAboutAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet()]
        [Route("[action]")]
        public IActionResult Meet()
        {
            var documentTitles = new List<string> { "Sales", "Education", "SGK", "Test" };
            return Ok(documentTitles);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 4)
            {
                return Ok(id);
            }

            return NotFound();
        }
    }
}