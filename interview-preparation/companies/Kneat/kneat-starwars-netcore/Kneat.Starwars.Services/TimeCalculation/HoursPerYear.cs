namespace Kneat.Starwars.Services.TimeCalculation
{
    public class HoursPerYear : IHoursCalculation
    {
        protected readonly IHours _hours;

        public HoursPerYear(IHours hours)
        {
            this._hours = hours;
        }
        public double GetHours() => _hours.Get(365); // TODO: Implement to get year from Leap Year
    }
}