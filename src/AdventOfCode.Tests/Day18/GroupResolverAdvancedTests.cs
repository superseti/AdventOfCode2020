using AdventOfCode.Day18;
using Xunit;

namespace AdventOfCode.Tests.Day18
{
    public class GroupResolverAdvancedTests
    {
        private GroupResolverAdvanced _sut;

        public GroupResolverAdvancedTests()
        {
            this._sut = new GroupResolverAdvanced();
        }


        [InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 669060)]
        [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 1445)]
        [InlineData("1 + 2 * 3 + 4 * 5 + 6", 231)]
        [InlineData("2 * 3 + (4 * 5)", 46)]
        [InlineData("2 * 3 + 1", 8)]
        [InlineData("(5 * 8) + 2", 42)]
        [Theory]
        public void ResolveGroup_ShouldWork(string expresion, int expected)
        {
            var result = this._sut.Resolve(expresion);

            Assert.Equal(expected, result);
        }
    }
}
