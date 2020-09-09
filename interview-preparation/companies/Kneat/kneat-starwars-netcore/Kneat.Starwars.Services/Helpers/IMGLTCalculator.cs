namespace Kneat.Starwars.Services.Helpers
{
    public interface IMGLTCalculator
    {
         double CalculateStopsByDistance(double distance, string consumables, double velocity);
    }
}