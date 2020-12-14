using AdventOfCode.Helpers;

namespace AdventOfCode.Day14
{
    public class FourteenthDayResolver : IResolver
    {
        public string ResolveFirst()
        {
            var instructions = new InputDataReader().GetInputDataSplitted(this);
            return new InstructionsInterpreter().Interpret(instructions).ToString();
        }

        public string ResolveSecond()
        {
            return string.Empty;
        }
    }
}
