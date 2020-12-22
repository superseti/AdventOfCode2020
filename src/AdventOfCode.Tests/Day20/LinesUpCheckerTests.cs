using AdventOfCode.Day20;
using Xunit;

namespace AdventOfCode.Tests.Day20
{
    public class LinesUpCheckerTests
    {
        [ClassData(typeof(LinesUpCheckerTestsData))]
        [Theory]
        public void AreValid_ShouldWork(string tileAtext, string tileBtext, TilePosition expected)
        {
            var tileA = new Tile();
            tileA.Init(tileAtext.Replace("\r\n", "\n"));
            var tileB = new Tile();
            tileB.Init(tileBtext.Replace("\r\n", "\n"));

            var manipulater = new ManipulaterTiles();

            var result = new LinesUpChecker().AreValid(tileA, tileB, manipulater);

            Assert.True(result.Success);
            Assert.Equal(expected, result.Position);
        }
    }
}
