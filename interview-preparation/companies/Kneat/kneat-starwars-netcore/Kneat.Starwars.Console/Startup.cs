using System;
using System.IO;
using Kneat.Starwars.Infrastructure.ClientHelper;
using Kneat.Starwars.Infrastructure.Interfaces;
using Kneat.Starwars.Infrastructure.Repositories;
using Kneat.Starwars.Repositories.Interfaces;
using Kneat.Starwars.Services;
using Kneat.Starwars.Services.Helpers;
using Kneat.Starwars.Services.Interfaces;
using Kneat.Starwars.Services.Services;
using Kneat.Starwars.Services.TimeCalculation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kneat.Starwars.Console
{
    public static class Startup
    {
        public static IConfigurationRoot configuration;

        public static void Main(IServiceCollection services)
        {
           // Build configuration
        configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json", false)
            .Build();

            services.AddSingleton<IConfiguration>(provider => configuration);
            services.AddTransient<IStarshipsService, StarshipsService>();
            services.AddTransient<IStarshipsRepository, StarshipsRepository>();
            services.AddTransient<IMGLTCalculatorService, MGLTCalculatorService>();
            services.AddTransient<IConvertConsumableHelper, ConvertConsumableHelper>();
            services.AddTransient<IHours, Hours>();
            services.AddTransient<HoursPerDay>();
            services.AddTransient<HoursPerWeek>();
            services.AddTransient<HoursPerMonth>();
            services.AddTransient<HoursPerYear>();

            services.AddTransient<IApiProxy, ApiProxy>();
            services.AddTransient<IApiProxy, ApiProxy>();
            services.AddTransient<IHttpClient, HttpClientWrap>();

            services.AddTransient<Func<string, IHoursCalculation>>(serviceProvider => timeType =>
            {
                switch (timeType.ToUpper())
                {
                    case "DAY":  
                    case "DAYS":  
                        return serviceProvider.GetService<HoursPerDay>();
                    case "WEEK": 
                    case "WEEKS": 
                        return serviceProvider.GetService<HoursPerWeek>();
                    case "MONTH":
                    case "MONTHS":
                        return serviceProvider.GetService<HoursPerMonth>();
                    case "YEAR":
                    case "YEARS":
                        return serviceProvider.GetService<HoursPerYear>();
                    default:
                        return serviceProvider.GetService<UnknowTime>();
                }
            });
        }
    }
}