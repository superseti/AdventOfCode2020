using AdventOfCode.Day14;
using Xunit;

namespace AdventOfCode.Tests.Day14
{
    public class ValueCalculatorTests
    {
        private ValueCalculator sut;

        public ValueCalculatorTests()
        {
            this.sut = new ValueCalculator
            {
                Mask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X"
            };
        }

        [InlineData(101, "000000000000000000000000000001100101")]
        [InlineData(11, "000000000000000000000000000001001001")]
        [InlineData(0, "000000000000000000000000000001000000")]
        [Theory]
        public void GetValueToApply_ShouldWork(int decimalValue, string expected)
        {
            var result = this.sut.GetValueToApply(decimalValue);

            Assert.Equal(expected, result);
        }
    }
}