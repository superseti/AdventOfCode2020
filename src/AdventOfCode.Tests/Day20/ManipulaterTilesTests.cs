using AdventOfCode.Day20;
using Xunit;

namespace AdventOfCode.Tests.Day20
{
    public class ManipulaterTilesTests
    {
        private ManipulaterTiles _sut;

        public ManipulaterTilesTests()
        {
            this._sut = new ManipulaterTiles();
        }

        [Fact]
        public void Rotate_ShouldWork()
        {
            var tileText =
@"10
...#.#.#.#
####.#....
..#.#.....
....#..#.#
.##..##.#.
.#.####...
####.#.#..
##.####...
##..#.##..
#.##...##.".Replace("\r\n", "\n");

            var tile = new Tile(tileText);
            this._sut.Rotate(tile);

            Assert.True(tile.Data[0][0]);
            Assert.False(tile.Data[0][Tile.Size - 1]);
            Assert.False(tile.Data[1][0]);
            Assert.False(tile.Data[1][Tile.Size - 1]);
            Assert.False(tile.Data[Tile.Size - 1][0]);
            Assert.True(tile.Data[Tile.Size - 1][Tile.Size - 1]);
        }

        [Fact]
        public void RotatePicture_ShouldWork()
        {
            var picture = new string[] {
"...#.#.#.#",
"####.#....",
"..#.#.....",
"....#..#.#",
".##..##.#.",
".#.####...",
"####.#.#..",
"##.####...",
"##..#.##..",
"#.##...##."};

            var result = this._sut.RotatePicture(picture);

            var firstLineExpected = "####....#.";
            var secondLineExpected = ".#####..#.";
            var lastLineExpected = "......#..#";

            Assert.Equal(firstLineExpected, result[0]);
            Assert.Equal(secondLineExpected, result[1]);
            Assert.Equal(lastLineExpected, result[9]);
        }

        [Fact]
        public void RotatePicture_4Times_ShouldLetInitialState()
        {
            var picture = new string[] {
"...#.#.#.#",
"####.#....",
"..#.#.....",
"....#..#.#",
".##..##.#.",
".#.####...",
"####.#.#..",
"##.####...",
"##..#.##..",
"#.##...##."};

            var result = this._sut.RotatePicture(picture);
            result = this._sut.RotatePicture(result);
            result = this._sut.RotatePicture(result);
            result = this._sut.RotatePicture(result);

            var firstLineExpected = "...#.#.#.#";
            var secondLineExpected = "####.#....";
            var lastLineExpected = "#.##...##.";

            Assert.Equal(firstLineExpected, result[0]);
            Assert.Equal(secondLineExpected, result[1]);
            Assert.Equal(lastLineExpected, result[9]);
        }

        [Fact]
        public void FlipPicture_ShouldWork()
        {
            var picture = new string[] {
"...#.#.#.#",
"####.#....",
"..#.#.....",
"....#..#.#",
".##..##.#.",
".#.####...",
"####.#.#..",
"##.####...",
"##..#.##..",
"#.##...##."};

            var result = this._sut.FlipPicture(picture);


            var firstLineExpected = "#.#.#.#...";
            var secondLineExpected = "....#.####";
            var lastLineExpected = ".##...##.#";

            Assert.Equal(firstLineExpected, result[0]);
            Assert.Equal(secondLineExpected, result[1]);
            Assert.Equal(lastLineExpected, result[9]);
        }
    }
}
