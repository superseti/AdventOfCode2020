using AdventOfCode.Day20;
using Xunit;

namespace AdventOfCode.Tests.Day20
{
    public class MonsterFinderTests
    {
        [ClassData(typeof(MonsterFinderTestsData))]
        [Theory]
        public void CountMonsters_ShouldWork(string[] picture, int expected)
        {
            var result = new MonsterFinder().CountMonsters(picture);

            Assert.Equal(expected, result);
        }

        [ClassData(typeof(MonsterFinderTestsData))]
        [Theory]
        public void CountMonsters_WhenRotated_ShouldWork(string[] picture, int expected)
        {
            var pictureFlipped = new ManipulaterTiles().RotatePicture(picture);
            var result = new MonsterFinder().CountMonsters(pictureFlipped);

            Assert.Equal(expected, result);
        }

        [ClassData(typeof(MonsterFinderTestsData))]
        [Theory]
        public void CountMonsters_WhenFlipped_ShouldWork(string[] picture, int expected)
        {
            var pictureRotated = new ManipulaterTiles().FlipPicture(picture);
            var result = new MonsterFinder().CountMonsters(pictureRotated);

            Assert.Equal(expected, result);
        }
    }
}
