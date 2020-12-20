using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day18
{
    public class GroupResolverAdvanced : IGroupResolver
    {
        private readonly Regex parenthesisDetectorWithOperator = new Regex(@"^\s?(\*|\+)?\s?(\((?:[^)(]+|\((?:[^)(]+|\([^)(]*\))*\))*\))");
        private readonly Regex numberDetectorWithOperator = new Regex("^\\s?(\\*|\\+)?\\s?(\\d+)");
        private readonly Regex parenthesisDetector = new Regex(@"^\s?\(((?:[^)(]+|\((?:[^)(]+|\([^)(]*\))*\))*)\)");
        private readonly Regex numberDetector = new Regex("^(\\d+)");
        private readonly Regex operatorDetector = new Regex("^\\s?(\\*|\\+) ");
        private readonly Dictionary<string, Func<Int64, Int64, Int64>> operators;

        public GroupResolverAdvanced()
        {
            this.operators = new Dictionary<string, Func<Int64, Int64, Int64>>
            {
                { "*", this.Multiply },
                { "+", this.Sum }
            };
        }
        public Int64 Resolve(string expression)
        {
            var groupResuls = new List<Int64>();
            var groups = this.GetGroups(expression);

            Int64 result = 1;

            while (groups.Any(group => group.IsAddUp))
            {
                var addGroup = groups.First(group => group.IsAddUp);
                var resultGroup = this.ResolveGroup(addGroup.ReferencedGroup.Expression);
                
                groups.Remove(addGroup.ReferencedGroup);

                while (addGroup != null)
                {
                    groups.Remove(addGroup);
                    resultGroup += this.ResolveGroup(addGroup.Expression);
                    addGroup = groups.FirstOrDefault(group => group.IsAddUp && group.ReferencedGroup == addGroup);
                }

                groupResuls.Add(resultGroup);
            }

            groups.ForEach(group => groupResuls.Add(this.ResolveGroup(group.Expression)));

            groupResuls.ForEach(resultGroup => result = result * resultGroup);

            return result;
            //Int64 result = 0;

            //var pendingExpression = expression;
            //var operatorCode = "+";

            //while (!string.IsNullOrEmpty(pendingExpression))
            //{
            //    var group = this.ResolveGroup(pendingExpression);
            //    result = this.operators[operatorCode](result, group.Number);

            //    pendingExpression = group.PendingExpression;
            //    var operatorMatch = this.operatorDetector.Match(pendingExpression);
            //    pendingExpression = pendingExpression.Substring(operatorMatch.Value.Length);

            //    if (operatorMatch.Success) { operatorCode = operatorMatch.Groups[1].Value; }
            //}

            //return result;
        }

        private Int64 Multiply(Int64 numberA, Int64 numberB) => numberA * numberB;
        private Int64 Sum(Int64 numberA, Int64 numberB) => numberA + numberB;

        private Int64 ResolveGroup(string expression)
        {
            Int64 result;

            Match firstPartMatch = this.parenthesisDetector.Match(expression);

            if (firstPartMatch.Success)
            {
                var parenthesisContent = firstPartMatch.Groups[1].Value;//.Substring(1, firstPartMatch.Value.Length - 2);
                result = this.Resolve(parenthesisContent);
            }
            else
            {
                firstPartMatch = this.numberDetector.Match(expression);
                result = int.Parse(firstPartMatch.Value);
            }

            return result;
        }

        private List<GroupResolvedAdvanced> GetGroups(string expression)
        {
            List<GroupResolvedAdvanced> groups = new List<GroupResolvedAdvanced>();
            var pendingExpression = expression;

            while (!string.IsNullOrEmpty(pendingExpression))
            {
                var match = this.parenthesisDetectorWithOperator.Match(pendingExpression);
                if (!match.Success)
                {
                    match = this.numberDetectorWithOperator.Match(pendingExpression);
                }

                pendingExpression = pendingExpression.Substring(match.Value.Length);

                GroupResolvedAdvanced currentGroup = new GroupResolvedAdvanced()
                {
                    Operator = match.Groups[1].Value,
                    Expression = match.Groups[2].Value,
                    ReferencedGroup = groups.LastOrDefault()
                };
                groups.Add(currentGroup);
            }

            return groups;
        }
    }
}
