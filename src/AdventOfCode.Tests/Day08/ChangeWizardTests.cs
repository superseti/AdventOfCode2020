using AdventOfCode.Day08;
using Xunit;

namespace AdventOfCode.Tests.Day08
{
    public class ChangeWizardTests
    {
        [ClassData(typeof(ChangeWizardData))]
        [Theory]
        public void DetectChange_ShouldReturnAccumulator(string programLines, int lineChanged, int accumulator)
        {
           var result = new ChangeWizard(programLines).DetectChange();

            Assert.Equal(lineChanged, result.LineNumber);
            Assert.Equal(accumulator, result.AccumulatorValue);
        }
    }
}
