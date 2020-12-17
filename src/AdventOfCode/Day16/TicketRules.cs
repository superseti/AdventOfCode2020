using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day16
{
    public class TicketRules
    {
        public TicketRules(string ruleValues)
        {
            this.Rules = new List<TicketRule>();

            var matches = new Regex("(.+): (\\d+)-(\\d+) or (\\d+)-(\\d+)").Matches(ruleValues);

            for (int ixMatch = 0; ixMatch < matches.Count; ixMatch++)
            {
                var currentMatch = matches[ixMatch];
                this.Rules.Add(new TicketRule(currentMatch.Groups[1].Value,
                    int.Parse(currentMatch.Groups[2].Value),
                    int.Parse(currentMatch.Groups[3].Value),
                    int.Parse(currentMatch.Groups[4].Value),
                    int.Parse(currentMatch.Groups[5].Value)));
            }
        }

        public List<TicketRule> Rules { get; private set; }


        internal bool IsValid(int number) => this.Rules.Any(rule => rule.IsValid(number));
        internal bool IsValid(Ticket ticket) => ticket.Values.All(value => this.IsValid(value.Value));
    }
}