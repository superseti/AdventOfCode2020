using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day18
{
    public class GroupResolver : IGroupResolver
    {
        private readonly Regex parenthesisDetector = new Regex("\\((?:[^)(]+|\\((?:[^)(]+|\\([^)(]*\\))*\\))*\\)");
        private readonly Regex numberDetector = new Regex("^(\\d+)");
        private readonly Regex operatorDetector = new Regex("^\\s?(\\*|\\+) ");
        private readonly Dictionary<string, Func<Int64, Int64, Int64>> operators;

        public GroupResolver()
        {
            this.operators = new Dictionary<string, Func<Int64, Int64, Int64>>
            {
                { "*", this.Multiply },
                { "+", this.Sum }
            };
        }
        public Int64 Resolve(string expression)
        {
            Int64 result = 0;

            var pendingExpression = expression;
            var operatorCode = "+";

            while (!string.IsNullOrEmpty(pendingExpression))
            {
                var group = this.ResolveGroup(pendingExpression);
                result = this.operators[operatorCode](result, group.Number);

                pendingExpression = group.PendingExpression;
                var operatorMatch = this.operatorDetector.Match(pendingExpression);
                pendingExpression = pendingExpression.Substring(operatorMatch.Value.Length);

                if (operatorMatch.Success) { operatorCode = operatorMatch.Groups[1].Value; }
            }

            return result;
        }

        private Int64 Multiply(Int64 numberA, Int64 numberB) => numberA * numberB;
        private Int64 Sum(Int64 numberA, Int64 numberB) => numberA + numberB;

        private GroupResolved ResolveGroup(string expression)
        {
            Int64 result;

            Match firstPartMatch;

            if (expression.StartsWith("("))
            {
                firstPartMatch = this.parenthesisDetector.Match(expression);
                var parenthesisContent = firstPartMatch.Value.Substring(1, firstPartMatch.Value.Length - 2);
                result = this.Resolve(parenthesisContent);
            }
            else
            {
                firstPartMatch = this.numberDetector.Match(expression);
                result = int.Parse(firstPartMatch.Value);
            }

            return new GroupResolved()
            {
                Number = result,
                PendingExpression = expression.Substring(firstPartMatch.Value.Length)
            };
        }
    }
}
