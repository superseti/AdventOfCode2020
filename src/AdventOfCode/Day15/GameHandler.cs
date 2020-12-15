namespace AdventOfCode.Day15
{
    public class GameHandler
    {
        private GameState state;

        public int CurrentNumber => this.state.LastNumber.Number;

        public void Init(int[] initialNumbers)
        {
            this.state = new GameState();
            foreach (var number in initialNumbers)
            {
                this.AddNumber(number);
            }
        }

        private void AddNumber(int number)
        {
            var newPosition = (this.state.LastNumber?.Last).GetValueOrDefault() + 1;

            NumberAparitions aparition;
            if (!this.state.NumberAparitions.TryGetValue(number, out aparition))
            {
                aparition = new NumberAparitions()
                {
                    Number = number,
                    Last = newPosition
                };
                this.state.NumberAparitions.Add(number, aparition);
            }
            else
            {
                aparition.SetNewAparition(newPosition);
            }
            this.state.LastNumber = aparition;
        }

        public int GetNextNumber()
        {
            if (this.state.LastNumber.Previous == 0)
            {
                return 0;
            }
            return this.state.LastNumber.Last - this.state.LastNumber.Previous;
        }

        public void AdvanceNextNumber() => this.AddNumber(this.GetNextNumber());

        public void AdvanceTillCycle(int cycle)
        {
            while (this.state.LastNumber.Last < cycle)
            {
                this.AdvanceNextNumber();
            }
        }
    }
}
