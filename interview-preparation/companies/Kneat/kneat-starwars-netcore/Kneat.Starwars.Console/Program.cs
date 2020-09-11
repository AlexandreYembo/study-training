using System;
using System.Threading.Tasks;
using Kneat.Starwars.Services;
using Kneat.Starwars.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Kneat.Starwars.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = RegisterStartup();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var starshipsService = serviceProvider.GetService<IStarshipsService>();

            var distance = int.Parse(System.Console.ReadLine());
            
            var starships =  await starshipsService.GetAllStarShipsAndAddStop(distance);
            
            foreach (var result in starships)
            {
                System.Console.WriteLine(result.Name + "=" + result.Stops);
            }

            starshipsService.Dispose();
        }

        private static ServiceCollection RegisterStartup()
        {
            var serviceCollection = new ServiceCollection();
            Startup.Main(serviceCollection);

            return serviceCollection;
        }
    }
}
