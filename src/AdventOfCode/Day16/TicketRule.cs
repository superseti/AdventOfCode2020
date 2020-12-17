using System.Collections.Generic;

namespace AdventOfCode.Day16
{
    public class TicketRule
    {
        public TicketRule(string name, int from1, int to1, int from2, int to2)
        {
            this.Name = name;
            this.From1 = from1;
            this.To1 = to1;
            this.From2 = from2;
            this.To2 = to2;
        }

        public string Name { get; private set; }
        public int From1 { get; private set; }
        public int To1 { get; private set; }
        public int From2 { get; private set; }
        public int To2 { get; private set; }
        public IEnumerable<int> ValidNumbers { get; private set; }

        public bool IsValid(int number) => (this.From1 <= number && number <= this.To1) || (this.From2 <= number && number <= this.To2);
    }
}
