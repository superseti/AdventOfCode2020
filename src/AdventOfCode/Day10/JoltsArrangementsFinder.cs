using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day10
{
    public class JoltsArrangementsFinder
    {
        public JoltsArrangementsFinder(int[] jolts)
        {
            this.Info = new JoltsInfo(jolts);

            List<ArrangementScopeNode> nodes = new List<ArrangementScopeNode>();
            //List<int> jolstJumpleables = new List<int>();

            for (int ixJoly = 0; ixJoly < jolts.Length; ixJoly++)
            {
                var node = new ArrangementScopeNode(ixJoly, jolts);
                if (node.JoltsJumpeables.Count > 0)
                {
                    nodes.Add(node);
                    //jolstJumpleables.AddRange(node.JoltsJumpeables);
                }
            }

            var elementsCount = nodes
                .SelectMany(node => node.JoltsJumpeables)
                .GroupBy(item => item)
                .Where(group => group.Count() == 1)
                .Count(); //jolstJumpleables.Distinct().Count();

            this.NumberOfArrangements = 1;
            if (elementsCount > 0)
            {
                //var numberOfElements = nodes.Sum(node => node.NumberOfItemsJumpeables);
                this.NumberOfArrangements = Math.Pow(2, elementsCount);
            }

            var withTwoElements = nodes.Where(node => node.JoltsJumpeables.Count == 2);

            if (withTwoElements.Count() > 0)
            {
                var elements = withTwoElements.SelectMany(node => node.JoltsJumpeables);
                var nonIncluded = nodes.Where(node => node.JoltsJumpeables.Intersect(elements).Count() == 0);
                elementsCount = withTwoElements.Count() + nonIncluded.Count();
                
                this.NumberOfArrangements += Math.Pow(2, elementsCount); //this.GetFactorial(elementsCount);
            }

            //for (int ixJumpeable = 1; ixJumpeable <= itemsJumpable; ixJumpeable++)
            //{
            //    this.NumberOfArrangements *= ixJumpeable;
            //}

            //this.NumberOfArrangements = new ArrangementScopeNode(null, 0, ref jolts).GetNumberOfArrangement();
        }

        private int GetFactorial(int number)
        {
            var result = 1;
            for (int ixNumber = number; ixNumber > 1; ixNumber--)
            {
                result *= ixNumber;
            }
            return result;
        }

        public JoltsInfo Info { get; private set; }

        public double NumberOfArrangements { get; private set; }
    }
}
