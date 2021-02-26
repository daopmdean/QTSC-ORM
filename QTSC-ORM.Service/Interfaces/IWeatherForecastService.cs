using System;
using System.Collections.Generic;

namespace QTSC_ORM.Service.Interfaces
{
    public interface IWeatherForcastService
    {
        IEnumerable<WeatherForecast> GetWeather(int start, int count);
    }
}
