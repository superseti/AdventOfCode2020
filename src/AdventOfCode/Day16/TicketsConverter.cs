using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day16
{
    public class TicketsConverter
    {
        public IEnumerable<Ticket> GetTickets(string ticketsFields)
        {
            var tickets = ticketsFields.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return tickets.Skip(1).Select(ticketValue => this.GetTicket(ticketValue));
        }

        public Ticket GetTicket(string ticketValue) => new Ticket(ticketValue);
    }
}
