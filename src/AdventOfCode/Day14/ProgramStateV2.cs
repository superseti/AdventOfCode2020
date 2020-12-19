using System;
using System.Collections.Generic;

namespace AdventOfCode.Day14
{
    internal class ProgramStateV2
    {
        public Dictionary<Int64, Int64> Values { get; private set; } = new Dictionary<Int64, Int64>();
        public MemoryPositionsCalculator Calculator { get; private set; } = new MemoryPositionsCalculator();
    }
}
