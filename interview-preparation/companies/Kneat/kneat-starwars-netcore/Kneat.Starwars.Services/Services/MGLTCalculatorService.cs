using System;
using Kneat.Starwars.Services.Helpers;
using Kneat.Starwars.Services.Interfaces;

namespace Kneat.Starwars.Services
{
    /// <summary>
    /// Calculator class for MGLT
    /// </summary>
    public class MGLTCalculatorService : IMGLTCalculatorService
    {
        public readonly IConvertConsumableHelper _convertConsumable;

        public MGLTCalculatorService(IConvertConsumableHelper convertConsumable)
        {
            _convertConsumable = convertConsumable;
        }

        /// <summary>
        /// Method that retuns how many stops by a defined distance
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="consumables"></param>
        /// <param name="velocity"></param>
        /// <returns></returns>
        public double CalculateStopsByDistance(double distance, string consumables, string velocity)
        {
            double dVelocity = 0;
            double.TryParse(velocity, out dVelocity);

            if(dVelocity == 0)
                return dVelocity;
                
            var hours = GetHours(distance, dVelocity);
            var consumablesHours = ConvertCosumablesToHours(consumables);
            var stops = consumablesHours == 0 ? consumablesHours : hours / consumablesHours;
            return Math.Floor(stops);
        }

        /// <summary>
        /// Get hours by distance devide by velocity
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="velocity"></param>
        /// <returns></returns>
        private double GetHours(double distance, double velocity) => distance / velocity;

        /// <summary>
        /// Get Consumable hours per Starship
        /// </summary>
        /// <param name="consumables"></param>
        /// <returns></returns>
        private double ConvertCosumablesToHours(string consumables)
        {
            var consumablesArr = consumables.Split(' ');
            double number = Double.Parse(consumablesArr[0]);
            
            string time = consumablesArr[1];
            return _convertConsumable.ToHour(number, time);
        }
    }
}