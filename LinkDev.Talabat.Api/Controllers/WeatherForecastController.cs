using LinkDev.Talabat.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.Talabat.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
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
				Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
		}

		[HttpPost(Name = "GetWeatherForecast")]
		public IEnumerable<string> GetOther()
		{
			List<string> random = new List<string>() { "Abdo", "Mostafa", "Hazem" };
			Random random1 = new Random();
			return Enumerable.Range(1, 3).Select(num => random[random1.Next(random.Count)]);
			//	return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			//	{
			//		Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
			//		TemperatureC = Random.Shared.Next(-20, 55),
			//		Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			//	})
			//	.ToArray();
			//}
		}
	}
}
