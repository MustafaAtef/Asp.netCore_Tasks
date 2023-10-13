using DependencyInjection_task.Models;
using DependencyInjection_task.ServiceContracts;

namespace DependencyInjection_task.Services {
    public class WeatherService : IWeatherService {
        private List<CityWeather> _cities { get; set; }
        public WeatherService() {
            _cities = new List<CityWeather>() {
                new () {CityUniqueCode = "LDN",
                CityName = "London",
                DateAndTime = DateTime.Parse("2030-01-01 8:00"),
                TemperatureFahrenheit = 33 },
                new () {CityUniqueCode = "NYC",
                CityName = "New York",
                DateAndTime = DateTime.Parse("2030-01-01 8:00"),
                TemperatureFahrenheit = 60 },
                new () {CityUniqueCode = "PAR",
                CityName = "Paris",
                DateAndTime = DateTime.Parse("2030-01-01 8:00"),
                TemperatureFahrenheit = 82 }
            };

        }
        public CityWeather? GetWeatherByCityCode(string CityCode) {
            var ans =  _cities.Where(city => (city.CityUniqueCode?.ToLower() ?? "") == CityCode.ToLower()).Select(city => city).Take(1).ToList();
            if (ans.Count == 0) return null;
            return ans[0];
        }

        public List<CityWeather> GetWeatherDetails() {
            return _cities;
        }
    }
}
