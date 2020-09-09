using System;

namespace Kneat.Starwars.Services.Helpers
{
    public class MGLTCalculator : IMGLTCalculator
    {
        public readonly IConvertConsumable _convertConsumable;

        public MGLTCalculator(IConvertConsumable convertConsumable)
        {
            _convertConsumable = convertConsumable;
        }

        public double CalculateStopsByDistance(double distance, string consumables, double velocity)
        {
            var hours = GetHours(distance, velocity);
            var consumablesHours = ConvertCosumablesToHours(consumables);
            var stops = hours / consumablesHours;
            return Math.Floor(stops);
        }

        private double GetHours(double distance, double velocity) => distance / velocity;

        private double ConvertCosumablesToHours(string consumables)
        {

            var consumablesArr = consumables.Split(' ');
            double number = Double.Parse(consumablesArr[0]);
            
            string time = consumablesArr[1];
            return _convertConsumable.ToHour(number, time);
        }
    }
}