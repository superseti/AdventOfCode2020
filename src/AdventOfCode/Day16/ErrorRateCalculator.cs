using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day16
{
    public class ErrorRateCalculator
    {
        private readonly TicketRules rules;
        public ErrorRateCalculator(string ruleValues)
        {
            this.rules = new TicketRules(ruleValues);
        }

        public int GetErrorRate(Ticket ticket)
        {
            var numbers = ticket.Values.Select(value => value.Value);
            return numbers.Where(number => !this.rules.IsValid(number)).Sum();
        }
        public int GetErrorsRate(IEnumerable<Ticket> tickets)
        {
            return tickets
                .Select(ticket => this.GetErrorRate(ticket))
                .Sum();
        }
    }
}
