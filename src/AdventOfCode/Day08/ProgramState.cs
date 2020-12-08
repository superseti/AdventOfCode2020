using System.Collections.Generic;

namespace AdventOfCode.Day08
{
    public class ProgramState
    {
        public int AccumulatorValue { get; set; }
        public int CurrentLineExecuting { get; set; }
        public List<ProgramLine> CallStack { get; private set; } = new List<ProgramLine>();
    }
}
