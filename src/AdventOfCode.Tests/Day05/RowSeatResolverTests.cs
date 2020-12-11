using AdventOfCode.Day05;
using Xunit;

namespace AdventOfCode.Tests.Day05
{
    public class RowSeatResolverTests
    {
        private RowSeatResolver sut;

        public RowSeatResolverTests()
        {
            this.sut = new RowSeatResolver();
        }

        [InlineData("FBFBBFF", 44)]
        [InlineData("BFFFBBF", 70)]
        [InlineData("FFFBBBF", 14)]
        [InlineData("BBFFBBF", 102)]
        [Theory]
        public void Resolve_ShouldWork(string rowInfo, int columnExpected)
        {
            int result = this.sut.Resolve(rowInfo);

            Assert.Equal(columnExpected, result);
        }
    }
}
