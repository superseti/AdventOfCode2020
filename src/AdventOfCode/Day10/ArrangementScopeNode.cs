using System.Collections.Generic;

namespace AdventOfCode.Day10
{
    class ArrangementScopeNode
    {
        public ArrangementScopeNode(int joltIndex, int[] jolts)
        {
            this.JoltsJumpeables = new List<int>();
            this.JoltIndex = joltIndex;
            this.Joltage = jolts[this.JoltIndex];
            this.DetermineScope(jolts);
        }

        public int JoltIndex { get; private set; }
        public int Joltage { get; private set; }
        public List<int> JoltsJumpeables { get; private set; }

        private void DetermineScope(int[] jolts)
        {
            if (this.JoltIndex >= jolts.Length - 2) { return; }

            var ixChildren = this.JoltIndex + 2;

            var nextNextJoltage = jolts[ixChildren];
            var difference = nextNextJoltage - this.Joltage;

            if (difference > 3) { return; }

            this.JoltsJumpeables.Add(jolts[ixChildren - 1]);

            ixChildren++;

            if (ixChildren < jolts.Length)
            {
                var nextNextNextJoltage = jolts[ixChildren];
                difference = nextNextNextJoltage - this.Joltage;

                if (difference <= 3)
                {
                    this.JoltsJumpeables.Add(jolts[ixChildren - 1]);
                }
            }
        }
    }
}