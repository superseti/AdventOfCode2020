using AdventOfCode.Day16;
using Xunit;

namespace AdventOfCode.Tests.Day16
{
    public class ErrorRateCalculatorTests
    {
        private ErrorRateCalculator _sut;

        public ErrorRateCalculatorTests()
        {
            var rules = @"
class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50".Replace("\r\n", "\n");
            this._sut = new ErrorRateCalculator(rules);
        }

        [InlineData("38,6,12, 234", 246)]
        [InlineData("38,6,12", 12)]
        [InlineData("55,2,20", 55)]
        [InlineData("40,4,50", 4)]
        [InlineData("7,3,47", 0)]
        [Theory]
        public void GetErrorRate_ShouldWork(string ticketValues, int? expected)
        {
            var result = this._sut.GetErrorRate(new Ticket(ticketValues));

            Assert.Equal(expected, result);
        }
    }
}
