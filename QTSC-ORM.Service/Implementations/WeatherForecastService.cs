using System;
using System.Collections.Generic;
using QTSC_ORM.Data.Repositories;
using QTSC_ORM.Service.Interfaces;

namespace QTSC_ORM.Service.Implementations
{
    public class WeatherForecastService : IWeatherForcastService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepo;
        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepo = weatherForecastRepository;
        }

        public IEnumerable<WeatherForecast> GetWeather(int start, int count)
        {
            return _weatherForecastRepo.GetWeather(start, count);
        }
    }
}
