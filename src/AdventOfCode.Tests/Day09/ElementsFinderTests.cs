using AdventOfCode.Day09;
using System;
using System.Linq;
using Xunit;

namespace AdventOfCode.Tests.Day09
{
    public class ElementsFinderTests
    {
        [ClassData(typeof(ComponerData))]
        [Theory]
        public void GetElementsToAdd_ShouldWorks(Int64 number, Int64[] preamble, Int64 minNumber, Int64 maxNumber)
        {
            var result = new ElementsFinder().GetElementsToAdd(number, preamble);

            var maxElement = result.Max();
            var minElement = result.Min();

            Assert.Equal(maxNumber, maxElement);
            Assert.Equal(minNumber, minElement);
        }
    }
}
