﻿using System;
using System.Collections.Generic;
using System.Linq;
using QTSC_ORM.Data.Entities;
using QTSC_ORM.Data.Repositories.Interfaces;

namespace QTSC_ORM.Data.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool",
            "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastRepository()
        {
        }

        public IEnumerable<WeatherForecast> GetWeather(int start, int count)
        {
            var rng = new Random();

            return Enumerable.Range(start, count).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }
    }
}
