using Kneat.Starwars.Services.TimeCalculation;
using Xunit;

namespace Kneat.Starwars.UnitTesting
{
    public class TimeCalculatorTests
    {
        private IHoursCalculation _hoursCalculation;
        
        [Fact(DisplayName="Get Hours per day")]
        [Trait("Hours", "Hours Calculation")]
        public void GetHoursPerDay()
        {
            //Arrange
            _hoursCalculation = new HoursPerDay(new Hours());
            //Act
            var result = _hoursCalculation.GetHours();
            //Assert
            Assert.Equal(24, result);
        }

        [Fact(DisplayName="Get Hours per week")]
        [Trait("Hours", "Hours Calculation")]
        public void GetHoursPerWeek()
        {
            //Arrange
            _hoursCalculation = new HoursPerWeek(new Hours());
            //Act
            var result = _hoursCalculation.GetHours();
            //Assert
            Assert.Equal(168, result);
        }

        [Fact(DisplayName="Get Hours per month")]
        [Trait("Hours", "Hours Calculation")]
        public void GetHoursPerMonth()
        {
            //Arrange
            _hoursCalculation = new HoursPerMonth(new Hours());
            //Act
            var result = _hoursCalculation.GetHours();
            //Assert
            Assert.Equal(720, result);
        }

        [Fact(DisplayName="Get Hours per year")]
        [Trait("Hours", "Hours Calculation")]
        public void GetHoursPerYear()
        {
            //Arrange
            _hoursCalculation = new HoursPerYear(new Hours());
            //Act
            var result = _hoursCalculation.GetHours();
            //Assert
            Assert.Equal(8760, result);
        }
    }
}
