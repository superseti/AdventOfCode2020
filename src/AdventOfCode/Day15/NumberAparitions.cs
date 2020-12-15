namespace AdventOfCode.Day15
{
    public class NumberAparitions
    {
        public int Number { get; set; }
        public int Previous { get; set; }
        public int Last { get; set; }

        public void SetNewAparition(int position)
        {
            this.Previous = this.Last;
            this.Last = position;
        }
    }
}
