using DependencyInjection_task.Models;
using DependencyInjection_task.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DependencyInjection_task.Controllers {
    public class WeatherController : Controller {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService) {
            _weatherService = weatherService;
        }

        [Route("/")]
        public IActionResult Index() {
            
            var response = string.Join("\n", _weatherService.GetWeatherDetails().Select(city => city.ToString()).ToList());
            return Content(response);
        }

        [Route("/weather/{city?}")]
        public IActionResult Search(string? city) {
            if (city is null) return BadRequest("must provide city name");
            CityWeather? cityweather = _weatherService.GetWeatherByCityCode(city);
            if (cityweather is null) return BadRequest("this city is not found");
            return Content(cityweather.ToString());
        }
    }
}
