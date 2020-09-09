namespace Kneat.Starwars.Services.TimeCalculation
{
    public class HoursPerMonth : IHoursCalculation
    {
       protected readonly IHours _hours;

        public HoursPerMonth(IHours hours)
        {
            this._hours = hours;
        }
        public double GetHours() => _hours.Get(365/12); // TODO: get the year based on the leap year./
    }
}