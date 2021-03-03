using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QTSC_ORM.Data;
using QTSC_ORM.Data.Repositories;
using QTSC_ORM.Service.Implementations;
using QTSC_ORM.Service.Interfaces;
using QTSC_ORM.Service.Utils;

namespace QTSC_ORM.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<DataContext>(
                options => options.UseSqlite(config.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("QTSC-ORM")));

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IWeatherForcastService, WeatherForecastService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
