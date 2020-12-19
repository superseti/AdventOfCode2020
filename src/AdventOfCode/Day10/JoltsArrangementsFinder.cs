using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day10
{
    public class JoltsArrangementsFinder
    {
        public JoltsArrangementsFinder(int[] jolts)
        {
            var nodes = this.GetNodes(jolts);

            this.NumberOfArrangements = 1;

            while (nodes.Count > 0)
            {
                var node = nodes[0];
                //this.NumberOfArrangements += node.JoltsPositionsJumpeables.Count;
                var restNodes = this.GetNonCoincidentNodes(nodes, node);
                var resConnections = restNodes.Sum(nodex => nodex.JoltsPositionsJumpeables.Count);
                this.NumberOfArrangements += Math.Pow(2, resConnections) * node.JoltsPositionsJumpeables.Count;

                nodes.RemoveAt(0);
            }
        }

        private List<ArrangementScopeNode> GetNodes(int[] jolts)
        {
            Array.Sort(jolts);
            List<ArrangementScopeNode> nodes = new List<ArrangementScopeNode>();

            for (int ixJoly = 0; ixJoly < jolts.Length; ixJoly++)
            {
                var node = new ArrangementScopeNode(ixJoly, jolts);
                if (node.JoltsPositionsJumpeables.Count > 0)
                {
                    nodes.Add(node);
                }
            }
            return nodes;
        }

        private IEnumerable<ArrangementScopeNode> GetNonCoincidentNodes(List<ArrangementScopeNode> nodes, ArrangementScopeNode currentNode)
        {
            return nodes
                .Skip(1)
                .Where(node => currentNode.JoltsPositionsJumpeables.All(ixJolt => !node.JoltsPositionsJumpeables.Contains(ixJolt)));
        }


        public double NumberOfArrangements { get; private set; }
    }
}
