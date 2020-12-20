using System;
using System.Linq;

namespace AdventOfCode.Day19
{
    public class Rule
    {
        private readonly RulesContainer _container;
        private char letter;

        public Rule(string ruleLine, RulesContainer container)
        {
            this._container = container;
            this.Init(ruleLine);
        }

        private void Init(string ruleLine)
        {
            var ruleTextData = ruleLine.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            this.IdRule = int.Parse(ruleTextData[0]);
            var ruleText = ruleTextData[1].TrimStart();
            if (ruleText.StartsWith("\""))
            {
                this.letter = ruleText.Replace("\"", string.Empty)[0];
            }
            else
            {
                var groupsTexts = ruleText.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                this.Groups = groupsTexts
                    .Select(groupText => new RuleGroup(groupText, this._container))
                    .ToArray();
            }
        }

        public int IdRule { get; private set; }

        public RuleGroup[] Groups { get; private set; }

        public bool IsMessageValid(string message)
        {
            var result = this.IsMessageValid(0, message);
            return result.Success && result.FinalIndex == message.Length;
        }

        internal RuleValidationResult IsMessageValid(int index, string message)
        {
            if (this.Groups != null)
            {
                foreach (var group in this.Groups)
                {
                    var resultGroup = group.IsMessageValid(index, message);
                    if (resultGroup.Success) { return resultGroup; }
                }
                return new RuleValidationResult()
                {
                    Success = false
                };
            }

            var isValid = message.Length > index && message[index] == this.letter;

            var result = new RuleValidationResult()
            {
                Success = isValid,
                FinalIndex = index + 1
            };

            return result;
        }
    }
}