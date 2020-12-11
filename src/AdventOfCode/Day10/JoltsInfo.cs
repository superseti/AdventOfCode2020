using System;
using System.Linq;

namespace AdventOfCode.Day10
{
    public class JoltsInfo
    {
        public JoltsInfo(int[] jolts)
        {
            this.Jolts = jolts;
            Array.Sort(this.Jolts);
            this.DeviceJoltage = this.Jolts.Last() + 3;
        }

        public int[] Jolts { get; private set; }
        public int InitialJoltage { get; private set; } = 0;
        public int DeviceJoltage { get; private set; }
    }
}
