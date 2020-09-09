using System;

namespace Kneat.Starwars.Services.TimeCalculation
{
    public class Hours : IHours
    {
        public double Get(int days) => new TimeSpan(days, 0, 0, 0).TotalHours;
    }
}