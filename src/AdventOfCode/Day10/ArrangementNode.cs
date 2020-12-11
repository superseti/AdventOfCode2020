using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day10
{
    class ArrangementNode
    {
        public ArrangementNode(ArrangementNode parent, int joltIndex, int[] jolts)
        {
            this.Parent = parent;
            this.Children = new List<ArrangementNode>();
            this._jolts = jolts;
            this.JoltIndex = joltIndex;
            this.Joltage = jolts[this.JoltIndex];
            this.DetermineChildren(jolts);
        }

        public ArrangementNode Parent;

        private int[] _jolts;

        public List<ArrangementNode> Children;

        public int JoltIndex { get; private set; }
        public int Joltage { get; private set; }

        //public ArrangementNode[] Children { get; private set; }

        public int NumberOfArrangements { get; private set; }

        public int GetNumberOfArrangements()
        {
            if (this.Children.Count == 0) { return 1; }
            return this.Children.Sum(child => child.GetNumberOfArrangements());
        }

        public string Cadena => this.Parent?.Cadena + "-" + this.Joltage;

        private void DetermineChildren(int[] jolts)
        {
            void actionFor(int ixJolt)
            {
                var currentJolt = jolts[ixJolt];
                var difference = currentJolt - this.Joltage;
                if (difference > 3) { return; }

                ArrangementNode node = new ArrangementNode(this, ixJolt, jolts);

                this.NumberOfArrangements += node.NumberOfArrangements;
                this.Children.Add(node);
            }

            var limit = Math.Min(this.JoltIndex + 4, jolts.Length);

            for (int ixJolt = this.JoltIndex + 1; ixJolt < limit; ixJolt++)
            {
                actionFor(ixJolt);
            }

            if (this.JoltIndex == jolts.Length - 1)
            {
                var cadena = this.Cadena;
                using (var writer = new StreamWriter("c:\\temp\\jolts.txt", true))
                {
                    writer.WriteLine(cadena);
                }
            }

            //Parallel.For(this.JoltIndex + 1, limit, actionFor);

            if (this.NumberOfArrangements == 0 && this.JoltIndex == jolts.Length - 1)
            {
                this.NumberOfArrangements = 1;
            }
        }
    }
}