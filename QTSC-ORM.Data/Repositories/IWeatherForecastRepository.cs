using System;
using System.Collections.Generic;

namespace QTSC_ORM.Data.Repositories
{
    public interface IWeatherForecastRepository
    {
        IEnumerable<WeatherForecast> GetWeather(int start, int count);
    }
}