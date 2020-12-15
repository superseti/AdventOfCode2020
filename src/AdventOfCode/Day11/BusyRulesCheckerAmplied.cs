namespace AdventOfCode.Day11
{
    public class BusyRulesCheckerAmplied : IBusyChecker
    {
        public BusyRulesCheckerAmplied(SeatLayoutInfo info)
        {
            this.Info = info;
        }
        public int LimitBusyAround => 5;
        public SeatLayoutInfo Info { get; private set; }

        public bool IsSeatReadyToBusy(int line, int column)
        {
            return this.IsSeatReadyToBusyByLeft(line, column) &&
                this.IsSeatReadyToBusyByRight(line, column) &&
                this.IsSeatReadyToBusyByDown(line, column) &&
                this.IsSeatReadyToBusyByUp(line, column) &&
                this.IsSeatReadyToBusyByUpLeft(line, column) &&
                this.IsSeatReadyToBusyByUpRight(line, column) &&
                this.IsSeatReadyToBusyByDownLeft(line, column) &&
                this.IsSeatReadyToBusyByDownRight(line, column);
        }

        private bool IsSeatReadyToBusyByDownRight(int line, int column)
        {
            return this.IsSeatReadyToBusyBy(line, column, 1, 1);
        }

        private bool IsSeatReadyToBusyByDownLeft(int line, int column)
        {
            return this.IsSeatReadyToBusyBy(line, column, 1, -1);
        }

        private bool IsSeatReadyToBusyByUpRight(int line, int column)
        {
            return this.IsSeatReadyToBusyBy(line, column, -1, 1);
        }

        private bool IsSeatReadyToBusyByUpLeft(int line, int column)
        {
            return this.IsSeatReadyToBusyBy(line, column, -1, -1);
        }

        private bool IsSeatReadyToBusyByUp(int line, int column)
        {
            return this.IsSeatReadyToBusyBy(line, column, -1, 0);
        }

        private bool IsSeatReadyToBusyByDown(int line, int column)
        {
            return this.IsSeatReadyToBusyBy(line, column, 1, 0);
        }

        private bool IsSeatReadyToBusyByRight(int line, int column)
        {
            return this.IsSeatReadyToBusyBy(line, column, 0, 1);
        }

        private bool IsSeatReadyToBusyByLeft(int line, int column)
        {
            return this.IsSeatReadyToBusyBy(line, column, 0, -1);
        }

        private bool IsSeatReadyToBusyBy(int line, int column, int lineDiff, int columnDiff)
        {
            Location currentLocation = new Location()
            {
                Column = column + columnDiff,
                Line = line + lineDiff
            };

            while (!this.Info.IsOutOfRange(currentLocation))
            {
                if (this.Info.IsFloor(currentLocation.Line, currentLocation.Column))
                {
                    currentLocation.Column += columnDiff;
                    currentLocation.Line += lineDiff;
                    continue;
                }
                return this.Info.IsSeatEmpty(currentLocation.Line, currentLocation.Column);
            }
            return true;
        }

        public bool ShouldBeEmpty(int line, int column)
        {
            var numberSeenBusy =
                (this.IsSeatReadyToBusyByDown(line, column) ? 0 : 1) +
                (this.IsSeatReadyToBusyByUp(line, column) ? 0 : 1) +
                (this.IsSeatReadyToBusyByLeft(line, column) ? 0 : 1) +
                (this.IsSeatReadyToBusyByRight(line, column) ? 0 : 1) +
                (this.IsSeatReadyToBusyByUpLeft(line, column) ? 0 : 1) +
                (this.IsSeatReadyToBusyByUpRight(line, column) ? 0 : 1);

            if (numberSeenBusy > this.LimitBusyAround) { return true; }

            numberSeenBusy += (this.IsSeatReadyToBusyByDownLeft(line, column) ? 0 : 1);
            if (numberSeenBusy > this.LimitBusyAround) { return true; }

            numberSeenBusy += (this.IsSeatReadyToBusyByDownRight(line, column) ? 0 : 1);

            return numberSeenBusy >= this.LimitBusyAround;
        }
    }
}
