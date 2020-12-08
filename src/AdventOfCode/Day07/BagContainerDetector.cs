using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day07
{
    public class BagContainerDetector
    {
        private readonly string detectorPatternBase = "(\\w+ \\w+) bags contain.+\\d+ {0} bags?";

        public string[] GetBagContainers(string rules, string bagCarried)
        {
            var result = new List<string>();

            this.AddContainers(result, rules, bagCarried);

            return result.Distinct().ToArray();
        }

        private void AddContainers(List<string> containers, string rules, string bagCarried)
        {
            var detectorPattern = string.Format(this.detectorPatternBase, bagCarried);
            var matches = new Regex(detectorPattern).Matches(rules);

            if (matches.Count == 0) { return; }

            for (int ixMatch = 0; ixMatch < matches.Count; ixMatch++)
            {
                var currentMatch = matches[ixMatch];
                for (int ixGroup = 1; ixGroup < currentMatch.Groups.Count; ixGroup++)
                {
                    var container = currentMatch.Groups[ixGroup].Value;
                    containers.Add(container);
                    this.AddContainers(containers, rules, container);
                }
            }
        }
    }
}
