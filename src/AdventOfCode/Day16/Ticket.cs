using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day16
{
    public class Ticket
    {
        public Ticket(string ticketValue)
        {
            this.Values = new List<TicketValue>();
            var values = ticketValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int ixValue = 0; ixValue < values.Count(); ixValue++)
            {
                this.Values.Add(new TicketValue()
                {
                    Value = int.Parse(values[ixValue])
                });
            }
        }

        public List<TicketValue> Values { get; private set; }
    }
}
