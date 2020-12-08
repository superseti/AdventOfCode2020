using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day07
{
    public class BagContainDetector
    {
        private readonly string detectorPatternBase = "{0} bags contain (.+).";
        private readonly Regex regexElemental = new Regex("(\\d+) (\\w+ \\w+) bags?");

        public int GetContainNumberElements(string rules, string bagContainer)
        {
            var result = new BagContainLevelInfo(null, 1, bagContainer);
            this.AddChildInfo(result, rules);

            return result.GetNumberOfElements() - 1;
        }

        private void AddChildInfo(BagContainLevelInfo parent, string rules)
        {
            var detectorPattern = string.Format(this.detectorPatternBase, parent.Info.BagName);
            var match = new Regex(detectorPattern).Match(rules);

            var matches = this.regexElemental.Matches(match.Groups[1].Value);

            for (int ixMatch = 0; ixMatch < matches.Count; ixMatch++)
            {
                var currentMatch = matches[ixMatch];

                var bagName = currentMatch.Groups[2].Value;

                var currentChild = new BagContainLevelInfo(parent,
                    Convert.ToInt32(currentMatch.Groups[1].Value),
                    bagName);

                parent.Bags.Add(currentChild);
                this.AddChildInfo(currentChild, rules);
            }
        }
    }
}