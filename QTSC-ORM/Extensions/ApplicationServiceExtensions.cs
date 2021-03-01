using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QTSC_ORM.Data;
using QTSC_ORM.Data.Repositories;
using QTSC_ORM.Service.Implementations;
using QTSC_ORM.Service.Interfaces;

namespace QTSC_ORM.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<DataContext>(
                options => options.UseSqlite(config.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("QTSC-ORM.Data")));

            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

            services.AddScoped<IWeatherForcastService, WeatherForecastService>();

            return services;
        }
    }
}
