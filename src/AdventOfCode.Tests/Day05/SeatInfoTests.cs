using AdventOfCode.Day05;
using Xunit;

namespace AdventOfCode.Tests.Day05
{
    public class SeatInfoTests
    {
        [InlineData("BFFFBBFRRR", 70, 7)]
        [InlineData("FFFBBBFRRR", 14, 7)]
        [InlineData("BBFFBBFRLL", 102, 4)]
        [Theory]
        public void Ctor_ShouldWork(string seatInfoStr, int rowExpected, int columnExpected)
        {
            var result = new SeatInfo(seatInfoStr, new ColumnSeatResolver(), new RowSeatResolver());

            Assert.Equal(columnExpected, result.Column);
            Assert.Equal(rowExpected, result.Row);
        }
    }
}
