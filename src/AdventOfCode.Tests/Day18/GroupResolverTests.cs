using AdventOfCode.Day18;
using Xunit;

namespace AdventOfCode.Tests.Day18
{
    public class GroupResolverTests
    {
        private GroupResolver _sut;

        public GroupResolverTests()
        {
            this._sut = new GroupResolver();
        }

        [InlineData("4 * 3", 12)]
        [InlineData("4 + 3", 7)]
        [InlineData("(4 + 3)", 7)]
        [InlineData("1 + 4 + 3", 8)]
        [InlineData("2 * 4 + 3", 11)]
        [InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12240)]
        [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632)]
        [Theory]
        public void ResolveGroup_ShouldWork(string expresion, int expected)
        {
            var result = this._sut.Resolve(expresion);

            Assert.Equal(expected, result);
        }
    }
}
