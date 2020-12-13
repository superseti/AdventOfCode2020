using AdventOfCode.Day13;
using Xunit;

namespace AdventOfCode.Tests.Day13
{
    public class BusCorrelativeDepartureFinderTests
    {
        [Fact]
        public void FindCorrelativeDeparture_ShouldWork()
        {
            string busIds = "7,13,x,x,59,x,31,19";

            var finder = new BusCorrelativeDepartureFinder();

            var result = finder.FindCorrelativeDeparture(busIds);

            var expected = 1068781;

            Assert.Equal(expected, result);
        }
    }
}
