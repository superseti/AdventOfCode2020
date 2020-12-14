using AdventOfCode.Day14;
using System;
using Xunit;

namespace AdventOfCode.Tests.Day14
{
    public class InstructionsInterpreterTests
    {
        private InstructionsInterpreter _sut;

        public InstructionsInterpreterTests()
        {
            this._sut = new InstructionsInterpreter();
        }

        [Fact]
        public void GetFinalResult_WithOneInstruction_ShuouldWork()
        {
            var valueExpected = 73;
            var data = new string[]
            {
                "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                        "mem[8] = 11"
            };

            Int64 finalResult = this._sut.Interpret(data);

            Assert.Equal(valueExpected, finalResult);
        }

        [Fact]
        public void GetFinalResult_WithSeveralInstructions_ShuouldWork()
        {
            var valueExpected = 165;
            var data = new string[]
            {
                "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
"mem[8] = 11",
"mem[7] = 101",
"mem[8] = 0",
            };

            Int64 finalResult = this._sut.Interpret(data);

            Assert.Equal(valueExpected, finalResult);
        }

        [Fact]
        public void GetFinalResult_WithSeveralMasksAndInstructions_ShuouldWork()
        {
            var valueExpected = 266;
            var data = new string[]
            {
                "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
"mem[8] = 11",
"mem[7] = 101",
"mem[8] = 0",
                "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
"mem[9] = 101",
"mem[13] = 0",
            };

            Int64 finalResult = this._sut.Interpret(data);

            Assert.Equal(valueExpected, finalResult);
        }
    }
}
