using AdventOfCode.Day10;
using Xunit;

namespace AdventOfCode.Tests.Day10
{
    public class JoltsDifferenceFinderTests
    {
        [ClassData(typeof(JoltsDifferencesData))]
        [Theory]
        public void Ctor_ShouldWork(int[] jolts, int joltDevice, int numberOf3JoltsDif, int numberOf1JoltyDif)
        {
            var result = new JoltsDifferenceFinder(jolts);

            Assert.Equal(joltDevice, result.Info.DeviceJoltage);
            Assert.Equal(numberOf3JoltsDif, result.DifferencesInfo.NumberOfThreeJoltsDifference);
            Assert.Equal(numberOf1JoltyDif, result.DifferencesInfo.NumberOfOneJoltDifference);
        }
    }
}