using AdventOfCode.Day05;
using Xunit;

namespace AdventOfCode.Tests.Day05
{
    public class GroupAnswerAcumulatorTests
    {
        private ColumnSeatResolver sut;

        public GroupAnswerAcumulatorTests()
        {
            this.sut = new ColumnSeatResolver();
        }

        [InlineData("RRR", 7)]
        [InlineData("RLL", 4)]
        [InlineData("RLR", 5)]
        [Theory]
        public void Resolve_ShouldWork(string columnInfo, int columnExpected)
        {
            var result = this.sut.Resolve(columnInfo);

            Assert.Equal(columnExpected, result);
        }
    }
}
