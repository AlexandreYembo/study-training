using System;
using Kneat.Starwars.Services.TimeCalculation;

namespace Kneat.Starwars.Services.Helpers
{
    public class ConvertConsumable : IConvertConsumable
    {
        private readonly Func<string, IHoursCalculation> _hoursCalculation;

        public ConvertConsumable(Func<string, IHoursCalculation> hoursCalculation)
        {
            _hoursCalculation = hoursCalculation;
        }

        /// <summary>
        /// Get the calculation by DI and multiply for the numbers of time.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="timeType"></param>
        /// <returns></returns>
        public double ToHour(double number, string timeType)
        {
            var instance = _hoursCalculation(timeType);
            var hours = instance.GetHours() * number;

            return hours;
        }
    }
}