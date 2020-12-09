using AdventOfCode.Day09;
using System;
using Xunit;
using System.Linq;

namespace AdventOfCode.Tests.Day09
{
    public class NumberNonXmasFinderTests
    {
        [Fact]
        public void GetNumberNonXmas_ShouldWorks()
        {
            var inputData = new Int64[] {
            35,
20 ,
15 ,
25 ,
47 ,
40 ,
62 ,
55 ,
65 ,
95 ,
102,
117,
150,
182,
127,
219,
299,
277,
309,
576,
            };

            var result = new NumberNonXmasFinder() { PreambleSize = 5 }.GetNumberNonXmas(inputData);

            var expectedNumber = 127;

            Assert.Equal(expectedNumber, result.Number);
            Assert.Equal(14, result.Position);
        }
    }
}
