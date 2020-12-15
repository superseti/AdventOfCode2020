using AdventOfCode.Day15;
using Xunit;

namespace AdventOfCode.Tests.Day15
{
    public class GameHandlerTests
    {
        private GameHandler _sut;

        public GameHandlerTests()
        {
            this._sut = new GameHandler();
        }

        [Fact]
        public void GetNextNumber_ShouldWork()
        {
            this._sut.Init(new int[] { 0, 3, 6 });

            var result = this._sut.GetNextNumber();

            var resultExpected = 0;

            Assert.Equal(resultExpected, result);
        }
        [Fact]
        public void GetNextNumber_AfterAdvanceNextNumber_ShouldWork()
        {
            this._sut.Init(new int[] { 0, 3, 6 });

            this._sut.AdvanceNextNumber();

            var result = this._sut.GetNextNumber();

            var resultExpected = 3;

            Assert.Equal(resultExpected, result);
        }

        [InlineData(2020, new int[] { 1, 2, 3 }, 27)]
        [InlineData(2020, new int[] { 1, 3, 2 }, 1)]
        [InlineData(2020, new int[] { 0, 3, 6 }, 436)]
        [InlineData(30000000, new int[] { 0, 3, 6 }, 175594)]
        [InlineData(30000000, new int[] { 1, 3, 2 }, 2578)]
        [InlineData(30000000, new int[] { 2, 1, 3 }, 3544142)]
        [InlineData(30000000, new int[] { 1, 2, 3 }, 261214)]
        [InlineData(30000000, new int[] { 2, 3, 1 }, 6895259)]
        [InlineData(30000000, new int[] { 3, 2, 1 }, 18)]
        [InlineData(30000000, new int[] { 3, 1, 2 }, 362)]
        [Theory]
        public void AdvanceTillCycle_AfterAdvanceNextNumber_ShouldWork(int cycle, int[] initialNumbers, int expectedCurrent)
        {
            this._sut.Init(initialNumbers);

            this._sut.AdvanceTillCycle(cycle);

            var result = this._sut.CurrentNumber;

            Assert.Equal(expectedCurrent, result);
        }
    }
}
