using System;

namespace AdventOfCode.Day10
{
    class ArrangementNode
    {
        private ArrangementNode _parent;
        private int[] _jolts;

        public ArrangementNode(ArrangementNode parent, int joltIndex, int[] jolts)
        {
            this._parent = parent;
            this._jolts = jolts;
            this.JoltIndex = joltIndex;
            this.Joltage = jolts[this.JoltIndex];
            this.DetermineChildren();
        }

        public int JoltIndex { get; private set; }
        public int Joltage { get; private set; }

        public int NumberOfArrangements { get; private set; }

        public string Cadena => this._parent?.Cadena + "-" + this.Joltage;

        private void DetermineChildren()
        {
            if (this.JoltIndex == this._jolts.Length - 1)
            {
                this.AddArrangment(1);
                return;
            }

            void actionFor(int ixJolt)
            {
                var currentJolt = this._jolts[ixJolt];
                var difference = currentJolt - this.Joltage;
                if (difference > 3) { return; }

                new ArrangementNode(this, ixJolt, this._jolts);
            }

            var limit = Math.Min(this.JoltIndex + 4, this._jolts.Length);

            for (int ixJolt = this.JoltIndex + 1; ixJolt < limit; ixJolt++)
            {
                actionFor(ixJolt);
            }

            //Parallel.For(this.JoltIndex + 1, limit, actionFor);
        }

        private void AddArrangment(int numberOfArrangements)
        {
            this.NumberOfArrangements += numberOfArrangements;
            if (this._parent != null)
            {
                this._parent.AddArrangment(numberOfArrangements);
            }
        }
    }
}