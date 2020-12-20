using AdventOfCode.Day19;
using Xunit;

namespace AdventOfCode.Tests.Day19
{
    public class RuleTests
    {
        [InlineData("0: \"a\"", "a", true)]
        [InlineData("0: \"b\"", "a", false)]
        [Theory]
        public void IsMessageValid_ShouldWork(string ruleLine, string message, bool expected)
        {
            var result = new Rule(ruleLine, null).IsMessageValid(message);

            Assert.Equal(expected, result);
        }
    }
}
