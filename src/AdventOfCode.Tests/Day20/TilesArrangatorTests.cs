using AdventOfCode.Day20;
using System;
using Xunit;

namespace AdventOfCode.Tests.Day20
{
    public class TilesArrangatorTests
    {
        [ClassData(typeof(TilesArrangatorTestsData))]
        [Theory]
        public void GetCornersCheckSum_ShouldWork(string tilestext, Int64 expected)
        {
            var arrangator = new TilesArrangator();
            var inputData = tilestext.Replace("\r\n", "\n").Split(new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
            arrangator.Init(inputData);
            var result = arrangator.GetCornersCheckSum();

            Assert.Equal(expected, result);

        }
    }
}
