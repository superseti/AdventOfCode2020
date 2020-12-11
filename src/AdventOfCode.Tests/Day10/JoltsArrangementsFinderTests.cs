using AdventOfCode.Day10;
using Xunit;

namespace AdventOfCode.Tests.Day10
{
    public class JoltsArrangementsFinderTests
    {
        [ClassData(typeof(JoltsArrangesData))]
        [Theory]
        public void Ctor_ShouldWork(int[] jolts, int differentArranges)
        {
            var result = new JoltsArrangementsFinder(jolts).NumberOfArrangements;

            Assert.Equal(differentArranges, result);
        }
    }
}
