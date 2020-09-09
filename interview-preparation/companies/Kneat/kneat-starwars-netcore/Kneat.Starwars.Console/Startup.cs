using System;
using Kneat.Starwars.Services.Helpers;
using Kneat.Starwars.Services.TimeCalculation;
using Microsoft.Extensions.DependencyInjection;

namespace Kneat.Starwars.Console
{
    public static class Startup
    {
        public static void Main(IServiceCollection services)
        {
            services.AddTransient<IMGLTCalculator, MGLTCalculator>();
            services.AddTransient<IConvertConsumable, ConvertConsumable>();
            services.AddTransient<IHours, Hours>();
            services.AddTransient<HoursPerDay>();
            services.AddTransient<HoursPerWeek>();
            services.AddTransient<HoursPerMonth>();
            services.AddTransient<HoursPerYear>();

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
                        return null;
                }
            });
        }
    }
}