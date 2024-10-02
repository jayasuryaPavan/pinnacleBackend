using Microsoft.AspNetCore.Mvc;
using Pinnacle.PIS.Server.Services;

namespace Pinnacle.PIS.Server.Controllers
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
        private readonly IPdfFileHandler _pdfFileHandler;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IPdfFileHandler pdfFileHandler)
        {
            _logger = logger;
            _pdfFileHandler = pdfFileHandler;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _pdfFileHandler.pdfText(Directory.GetCurrentDirectory() + "//files//samplePages.pdf");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

    }
}
