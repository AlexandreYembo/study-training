namespace Kneat.Starwars.Services.Helpers
{
    /// <summary>
    /// Interface used to implement the consumable calculation
    /// </summary>
    public interface IConvertConsumableHelper
    {
         double ToHour(double number, string timeType);
    }
}