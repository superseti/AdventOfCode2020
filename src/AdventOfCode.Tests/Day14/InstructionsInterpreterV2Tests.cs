using AdventOfCode.Day14;
using System;
using Xunit;

namespace AdventOfCode.Tests.Day14
{
    public class InstructionsInterpreterV2Tests
    {
        private InstructionsInterpreterV2 _sut;

        public InstructionsInterpreterV2Tests()
        {
            this._sut = new InstructionsInterpreterV2();
        }

        [InlineData(new string[] { "mask = 000000000000000000000000000000X1001X", "mem[42] = 100",
            "mask = 00000000000000000000000000000000X0XX", "mem[26] = 1" }, 208)]
        [InlineData(new string[] { "mask = 000000000000000000000000000000X1001X", "mem[42] = 100" }, 400)]
        [InlineData(new string[] { "mask = 00000000000000000000000000000000X0XX", "mem[26] = 1" }, 8)]
        [Theory]
        public void GetFinalResult_ShuouldWork(string[] instructions, Int64 valueExpected)
        {
            Int64 finalResult = this._sut.Interpret(instructions);

            Assert.Equal(valueExpected, finalResult);
        }
    }
}
