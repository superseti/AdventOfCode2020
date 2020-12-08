using AdventOfCode.Day08;
using Xunit;

namespace AdventOfCode.Tests.Day08
{
    public class ProgramExecutorTests
    {
        [ClassData(typeof(ProgramLinesData))]
        [Theory]
        public void Ctor_ShouldReadProgram(string programLines, int expectedNumberLines, string expectedFirstInstruction, int expectedFirstParameter, string expectedLastInstruction, int expectedLastParameter)
        {
            var executor = new ProgramExecutor(programLines);

            Assert.Equal(expectedNumberLines, executor.Lines.Length);

            var firstLineIndex = 0;
            var lastLineIndex = expectedNumberLines - 1;

            var firstInstruction = executor.Lines[firstLineIndex];
            var lastInstruction = executor.Lines[lastLineIndex];

            Assert.Equal(firstLineIndex, firstInstruction.LineNumber);
            Assert.Equal(expectedFirstInstruction, firstInstruction.Instruction);
            Assert.Equal(expectedFirstParameter, firstInstruction.Parameter);
            Assert.Equal(lastLineIndex, lastInstruction.LineNumber);
            Assert.Equal(expectedLastInstruction, lastInstruction.Instruction);
            Assert.Equal(expectedLastParameter, lastInstruction.Parameter);
        }

        [ClassData(typeof(ExecutingLinesData))]
        [Theory]
        public void ExecuteCurrentLine_ShouldMoveToTheNextLine(string programLines, int expectedNextLineNumber, int expectedAcumulator)
        {
            var executor = new ProgramExecutor(programLines);
            executor.ExecuteCurrentLine();

            Assert.Equal(expectedNextLineNumber, executor.State.CurrentLineExecuting);
            Assert.Equal(expectedAcumulator, executor.State.AccumulatorValue);
        }

        [ClassData(typeof(ExecutingNonLoopAndLoopLinesData))]
        [Theory]
        public void ExecuteTillLoopOrEnd_ShouldAccumulateValue(string programLines, int expectedAcumulator, bool terminated)
        {
            var executor = new ProgramExecutor(programLines);
            var result = executor.ExecuteTillLoopOrEnd();

            Assert.Equal(expectedAcumulator, executor.State.AccumulatorValue);
            Assert.Equal(terminated, result);
        }
    }
}
