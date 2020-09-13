using Xunit;
using Moq.AutoMock;
using Kneat.Starwars.Services.Interfaces;
using Kneat.Starwars.Services;
using Kneat.Starwars.Services.TimeCalculation;
using Kneat.Starwars.Services.Helpers;

namespace Kneat.Starwars.UnitTesting
{
    public class MGLTCalculatorServiceTests
    {
        private readonly AutoMocker _mocker;
        private readonly MGLTCalculatorService _mgltCalculatorService;

        public MGLTCalculatorServiceTests()
        {
            _mocker = new AutoMocker();
            _mgltCalculatorService = _mocker.CreateInstance<MGLTCalculatorService>();
        }
        [Fact(DisplayName="Should Calculate Stops By Distance and Months")]
        [Trait("MGLT", "Stops Calculation")]
        public void MGLTStops_ShouldCalculateStopByDistanceAndMonths()
        {
            //Arrange
            var hourPerMonth = 730;
            var input = 1000000;
            _mocker.GetMock<IHoursCalculation>().Setup(s => s.GetHours()).Returns(hourPerMonth);
            _mocker.GetMock<IConvertConsumableHelper>().Setup(s => s.ToHour(2, "months")).Returns(hourPerMonth * 2);

            //Act
            var result = _mgltCalculatorService.CalculateStopsByDistance(input, "2 months", "75");

            //Assert
            Assert.Equal(9, result);
        }
    }
}