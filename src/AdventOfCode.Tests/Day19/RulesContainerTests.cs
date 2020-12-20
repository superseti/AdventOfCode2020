using AdventOfCode.Day19;
using Xunit;

namespace AdventOfCode.Tests.Day19
{
    public class RulesContainerTests
    {
        private RulesContainer _sut;

        public RulesContainerTests()
        {
            this._sut = new RulesContainer();
        }

        [ClassData(typeof(RulesTestsData))]
        [Theory]
        public void IsMessageValid_ShouldWork(string[] rulesLines, string message, bool expected)
        {
            this._sut.Init(rulesLines);
            var result = this._sut.IsMessageValid(message);

            Assert.Equal(expected, result);
        }
    }
}
