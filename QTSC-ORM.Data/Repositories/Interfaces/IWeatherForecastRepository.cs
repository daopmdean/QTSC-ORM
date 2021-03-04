using System;
using System.Collections.Generic;

namespace QTSC_ORM.Data.Repositories.Interfaces
{
    public interface IWeatherForecastRepository
    {
        IEnumerable<WeatherForecast> GetWeather(int start, int count);
    }
}