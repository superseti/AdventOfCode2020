using AdventOfCode.Day07;
using Xunit;

namespace AdventOfCode.Tests.Day07
{
    public class BagContainerDetectorTests
    {
        private BagContainerDetector sut;
        private string bagCarried;

        public BagContainerDetectorTests()
        {
            this.sut = new BagContainerDetector();
            this.bagCarried = "shiny gold";
        }

        [MemberData(nameof(BagsRulesTestsData.GetRulesSingleLineNonIncludeShinyBag), MemberType = typeof(BagsRulesTestsData))]
        [Theory]
        public void GetBagContainers_WithSingleLines_NotIncludedTheBag_ShoulReturnNull(string rule)
        {
            var result = this.sut.GetBagContainers(rule, this.bagCarried);

            Assert.Empty(result);
        }

        [MemberData(nameof(BagsRulesTestsData.GetRulesSingleLineIncludeShinyBag), MemberType = typeof(BagsRulesTestsData))]
        [Theory]
        public void GetBagContainers_WithSingleLines_IncludedTheBag_ShoulReturnContainer(string rule, string container)
        {
            var result = this.sut.GetBagContainers(rule, this.bagCarried);
            var expectedContainer = new string[] { container };

            Assert.Equal(expectedContainer, result);
        }

        [Fact]
        public void GetBagContainers_WithMultipleLines_ShoulReturnContainer()
        {
            string rule = @"light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.";
            var result = this.sut.GetBagContainers(rule, this.bagCarried);
            var expectedContainers = new string[] {
                "bright white",
                "muted yellow",
                "dark orange",
                "light red",
            };

            Assert.Equal(expectedContainers.Length, result.Length);
            foreach (var item in result) 
            {
                Assert.Contains(item, expectedContainers);
            }
        }
    }
}