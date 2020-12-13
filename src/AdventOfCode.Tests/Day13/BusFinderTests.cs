using AdventOfCode.Day13;
using Xunit;
using FluentAssertions;

namespace AdventOfCode.Tests.Day13
{
    public class BusFinderTests
    {
        [Fact]
        public void FindBus_ShouldWork()
        {
            int earliestTimeStampDepart = 939;
            string busIds = "7,13,x,x,59,x,31,19";

            var finder = new BusFinder() {
                EarliestTimeStampDepart = earliestTimeStampDepart
            };

            var result = finder.FindBus(busIds);

            Assert.Equal(59, result.IdBus);
            Assert.Equal(5, result.MinutesWaiting);
            Assert.Equal(944, result.TimeStampDepart);
        }
    }
}
