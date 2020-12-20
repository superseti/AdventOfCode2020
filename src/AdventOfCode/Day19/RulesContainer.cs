using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day19
{
    public class RulesContainer
    {
        private Dictionary<int, Rule> rules;
        public void Init(string[] rulesTxt)
        {
            this.rules = rulesTxt
                .Select(ruleTxt => new Rule(ruleTxt, this))
                .ToDictionary(rule => rule.IdRule);
        }

        public Rule GetRule(int ixRule) => this.rules[ixRule];

        public bool IsMessageValid(string message) => this.GetRule(0).IsMessageValid(message);
    }
}
