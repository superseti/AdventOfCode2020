using AdventOfCode.Day16;
using Xunit;
using System.Linq;

namespace AdventOfCode.Tests.Day16
{
    public class FieldDetectorTests
    {
        [Fact]
        public void DetectFields_ShouldWork()
        {
            var detector = new FieldDetector();

            var rules = @"class: 0-1 or 4-19
row: 0-5 or 8-19
seat: 0-13 or 16-19".Replace("\r\n", "\n");

            var tickets = @"nearby tickets:
3,9,18
15,1,5
5,14,9".Replace("\r\n", "\n");

            var result = detector.DetectFields(rules, tickets);

            var firstField = result.First(field => field.Position == 0);
            Assert.Equal("row", firstField.Rule.Name);

            var secondField = result.First(field => field.Position == 1);
            Assert.Equal("class", secondField.Rule.Name);

            var thirdField = result.First(field => field.Position == 2);
            Assert.Equal("seat", thirdField.Rule.Name);
        }
    }
}
