using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day16
{
    public class FieldDetector
    {
        public IEnumerable<FieldDetected> DetectFields(string rulesField, string ticketsField)
        {
            var rules = new TicketRules(rulesField);
            var tickets = new TicketsConverter()
                .GetTickets(ticketsField)
                .Where(ticket => rules.IsValid(ticket))
                .ToList();

            Dictionary<int, List<TicketRule>> fields =
                new Dictionary<int, List<TicketRule>>();
            for (int ixField = 0; ixField < rules.Rules.Count; ixField++)
            {
                fields.Add(ixField, new List<TicketRule>(rules.Rules));
            }

            while (fields.Any(field => field.Value.Count() > 1))
            {
                var fieldsPending = fields.Where(field => field.Value.Count() > 1).ToArray();
                var numbersPending = fieldsPending.Select(field => field.Value.Count()).ToArray();

                foreach (var fieldPending in fieldsPending)
                {
                    var possibleRules = this.DetectField(tickets, fieldPending);
                    bool determineUnique = possibleRules.Count() < 2;
                    if (determineUnique)
                    {
                        this.RemovePosibleField(fields, possibleRules.First());
                    }
                    fields[fieldPending.Key] = possibleRules;
                    if (determineUnique)
                    {
                        break;
                    }
                }
            }

            return fields.Select(field => new FieldDetected()
            {
                Position = field.Key,
                Rule = field.Value.First()
            });
        }

        private void RemovePosibleField(Dictionary<int, List<TicketRule>> fields, TicketRule ruleTarget)
        {
            for (int ixField = 0; ixField < fields.Count(); ixField++)
            {
                var currentCount = fields[ixField].Count;
                if (currentCount == 1) { continue; }
                //var current = fields[ixField].ToList();
                fields[ixField].RemoveAll(rule => rule.Name == ruleTarget.Name);
                
                var newCount = fields[ixField].Count;
                if (currentCount != newCount && newCount == 1)
                {
                    this.RemovePosibleField(fields, fields[ixField].First());
                }
                //fields[ixField] = current;
            }
        }

        private List<TicketRule> DetectField(List<Ticket> tickets, KeyValuePair<int, List<TicketRule>> fieldPending)
        {
            List<TicketRule> possibleRules = new List<TicketRule>(fieldPending.Value);
            foreach (var ticket in tickets)
            {
                var possibleRulesInTicket = this.GetPossibleRules(fieldPending.Value, ticket.Values[fieldPending.Key]);

                possibleRules.RemoveAll(rule =>
                    possibleRulesInTicket.FirstOrDefault(ruleInTicket => ruleInTicket.Name == rule.Name) == null);//= possibleRules.Intersect(possibleRulesInTicket);
                if (possibleRules.Count() == 1)
                {
                    break;
                }
            }
            return possibleRules;
        }

        private IEnumerable<TicketRule> GetPossibleRules(IEnumerable<TicketRule> rules, TicketValue ticketValue)
        {
            return rules.Where(rule => rule.IsValid(ticketValue.Value));
        }
    }
}
