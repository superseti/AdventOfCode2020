using System;
using System.Linq;

namespace AdventOfCode.Day19
{
    public class RuleGroup
    {
        private RulesContainer _container;
        public RuleGroup(string groupTxt, RulesContainer container)
        {
            this._container = container;
            this.IxRules = groupTxt
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(idRuleStr => Int32.Parse(idRuleStr))
                .ToArray();
        }
        public int[] IxRules { get; set; }
        public RuleValidationResult IsMessageValid(int index, string message)
        {
            var lastIndex = index;
            for (int ixRule = 0; ixRule < this.IxRules.Length; ixRule++)
            {
                var resultGroup = this._container.GetRule(this.IxRules[ixRule]).IsMessageValid(lastIndex, message);
                if (!resultGroup.Success)
                {
                    return new RuleValidationResult() { };
                }
                lastIndex = resultGroup.FinalIndex;
            }
            return new RuleValidationResult()
            {
                Success = true,
                FinalIndex = lastIndex
            };
        }
    }
}
