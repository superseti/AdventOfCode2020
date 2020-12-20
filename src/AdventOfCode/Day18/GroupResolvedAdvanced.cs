using System;

namespace AdventOfCode.Day18
{
    public class GroupResolvedAdvanced : IComparable<GroupResolvedAdvanced>
    {
        public int Position { get; set; }
        public string Operator { get; set; }
        public GroupResolvedAdvanced ReferencedGroup { get; set; }
        public string Expression { get; set; }
        public bool IsAddUp => this.Operator == "+";
        public bool IsParenthesis => this.Expression.StartsWith("(");

        public int CompareTo(GroupResolvedAdvanced other)
        {
            if (other.Operator == this.Operator) { return other.Position.CompareTo(this.Position); }

            return this.Operator == "+" ? -1 : 1;
        }
    }
}
