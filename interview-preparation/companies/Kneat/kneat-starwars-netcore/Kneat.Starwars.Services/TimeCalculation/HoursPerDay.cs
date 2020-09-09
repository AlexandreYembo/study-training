namespace Kneat.Starwars.Services.TimeCalculation
{
    public class HoursPerDay : IHoursCalculation
    {
        protected readonly IHours _hours;

        public HoursPerDay(IHours hours)
        {
            this._hours = hours;
        }
        
        public double GetHours() => _hours.Get(1);
    }
}