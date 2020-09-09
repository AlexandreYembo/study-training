using System;
using Kneat.Starwars.Services.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Kneat.Starwars.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = RegisterStartup();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var calculatorService = serviceProvider.GetService<IMGLTCalculator>();
            var stops = calculatorService.CalculateStopsByDistance(1000000, "6 months", 20);
        }

        private static ServiceCollection RegisterStartup()
        {
            var serviceCollection = new ServiceCollection();
            Startup.Main(serviceCollection);

            return serviceCollection;
        }
    }
}
