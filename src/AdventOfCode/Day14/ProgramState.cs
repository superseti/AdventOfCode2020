using System.Collections.Generic;

namespace AdventOfCode.Day14
{
    internal class ProgramState
    {
        public Dictionary<int, string> Values { get; private set; } = new Dictionary<int, string>();
        public ValueCalculator Calculator { get; private set; } = new ValueCalculator();
    }
}
