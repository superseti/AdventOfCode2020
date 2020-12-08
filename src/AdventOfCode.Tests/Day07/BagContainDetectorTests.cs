using AdventOfCode.Day07;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace AdventOfCode.Tests.Day07
{
    public class BagContainDetectorTests
    {
        private readonly BagContainDetector sut;
        private readonly string bagCarried;

        public BagContainDetectorTests()
        {
            this.sut = new BagContainDetector();
            this.bagCarried = "shiny gold";
        }

        [MemberData(nameof(BagsRulesTestsData.GetRulesFromShinyBag), MemberType = typeof(BagsRulesTestsData))]
        [Theory]
        public void GetContainNumberElements_ShouldWorks(string rule, int containExpected)
        {
            var result = this.sut.GetContainNumberElements(rule, this.bagCarried);

            Assert.Equal(containExpected, result);
      }
    }
}