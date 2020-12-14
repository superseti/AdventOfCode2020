using AdventOfCode.Day14;
using Xunit;

namespace AdventOfCode.Tests.Day14
{
    public class BinaryConverterTests
    {
        [InlineData(11, "1011")]
        [InlineData(73, "1001001")]
        [InlineData(101, "1100101")]
        [Theory]
        public void ToBinary_ShouldWork(int decimalValue, string expected)
        {
            var result = new BinaryConverter().ToBinary(decimalValue);

            Assert.Equal(expected, result);
        }

        [InlineData("1011", 11)]
        [InlineData("1001001", 73)]
        [InlineData("1100101", 101)]
        [Theory]
        public void ToDecimal_ShouldWork(string binaryValue, int expected)
        {
            var result = new BinaryConverter().ToDecimal(binaryValue);

            Assert.Equal(expected, result);
        }
    }
}
