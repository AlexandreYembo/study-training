using System;

namespace Kneat.Starwars.Services.TimeCalculation
{
    public class HoursPerWeek : IHoursCalculation
    {
        protected readonly IHours _hours;

        public HoursPerWeek(IHours hours)
        {
            this._hours = hours;
        }

        public double GetHours() => _hours.Get(7); // TODO: get the year based on the leap year./
    }
}