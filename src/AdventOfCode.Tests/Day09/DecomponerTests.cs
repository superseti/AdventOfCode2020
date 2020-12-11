using AdventOfCode.Day09;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode.Tests.Day09
{
    public class DecomponerTests
    {
        [ClassData(typeof(DecomponerData))]
        [Theory]
        public void IsPossibleToDecompone_ShouldWork(Int64 Number, Int64[] possibleElements, bool expectedResult)
        {
            var result = new Decomponer().IsPossibleDecompone(Number, possibleElements);

            Assert.Equal(expectedResult, result);
        }
    }
}
