using DependencyInjection_task.Models;

namespace DependencyInjection_task.ServiceContracts {
    public interface IWeatherService {
        List<CityWeather> GetWeatherDetails();
        CityWeather? GetWeatherByCityCode(string CityCode);
    }
}
