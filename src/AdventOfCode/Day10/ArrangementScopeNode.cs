using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day10
{
    class ArrangementScopeNode
    {
        public ArrangementScopeNode(ArrangementScopeNode parent, int joltIndex, ref int[] jolts)
        {
            this.Parent = parent;
            this.JoltIndex = joltIndex;
            this.Joltage = jolts[this.JoltIndex];
            this.Children = new List<ArrangementScopeNode>();
            this.DetermineScope(jolts);
        }
        public ArrangementScopeNode Parent { get; private set; }

        public int JoltIndex { get; private set; }
        public int Joltage { get; private set; }
        public List<ArrangementScopeNode> Children { get; private set; }

        public int GetNumberOfArrangement()
        {
            if (this.Children.Count == 0) { return 1; }

            return this.Children.Sum(child => child.GetNumberOfArrangement());
        }

        private void DetermineScope(int[] jolts)
        {
            if (this.JoltIndex >= jolts.Length - 2) { return; }

            var ixChildren = this.JoltIndex + 1;
            this.Children.Add(new ArrangementScopeNode(this, ixChildren, ref jolts));

            ixChildren++;
            var nextNextJoltage = jolts[ixChildren];
            var difference = nextNextJoltage - this.Joltage;

            if (difference > 3) { return; }

            this.Children.Add(new ArrangementScopeNode(this, ixChildren, ref jolts));

            ixChildren++;

            if (ixChildren < jolts.Length)
            {
                var nextNextNextJoltage = jolts[ixChildren];
                difference = nextNextNextJoltage - this.Joltage;

                if (difference <= 3) { this.Children.Add(new ArrangementScopeNode(this, ixChildren, ref jolts)); }
            }
        }
    }
}