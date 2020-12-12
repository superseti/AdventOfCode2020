namespace AdventOfCode.Day11
{
    public class BusyRulesChecker : IBusyChecker
    {
        public BusyRulesChecker(SeatLayoutInfo info)
        {
            this.Info = info;
        }

        public int LimitBusyAround => 4;
        public SeatLayoutInfo Info { get; private set; }

        public bool IsSeatReadyToBusy(int line, int column)
        {
            return this.IsSeatReadyToBusyByLeft(line, column) &&
                this.IsSeatReadyToBusyByRight(line, column) &&
                this.IsSeatReadyToBusyByDown(line, column) &&
                this.IsSeatReadyToBusyByUp(line, column);
        }

        public bool ShouldBeEmpty(int line, int column)
        {
            var locations = new Location[] {
            new Location(){Line = line,Column = column -1 },
            new Location(){Line = line,Column = column + 1 },
            new Location(){Line = line -1 ,Column = column },
            new Location(){Line = line + 1,Column = column},
            new Location(){Line = line -1 ,Column = column -1 },
            new Location(){Line = line + 1,Column = column +1 },
            new Location(){Line = line +1 ,Column = column -1 },
            new Location(){Line = line -1,Column = column +1 },
            };

            var numberBusySeatsAroud = 0;

            for (int ixLocation = 0;
                ixLocation < locations.Length && numberBusySeatsAroud <= this.LimitBusyAround;
                ixLocation++)
            {
                var currentLocation = locations[ixLocation];
                if (!this.Info.IsOutOfRange(currentLocation) &&
                    this.Info.IsSeatBusy(currentLocation.Line, currentLocation.Column))
                {
                    numberBusySeatsAroud++;
                }

            }

            return numberBusySeatsAroud >= this.LimitBusyAround;
        }
        private bool IsSeatReadyToBusyByLeft(int line, int column)
        {
            if (column == 0) { return true; }
            var leftColumn = column - 1;
            if (!this.Info.IsFloorOrEmptySeat(line, leftColumn)) { return false; }

            if (line > 0)
            {
                var upLine = line - 1;
                if (!this.Info.IsFloorOrEmptySeat(upLine, leftColumn)) { return false; }
            }
            if (line < this.Info.LineCount - 1)
            {
                var downLine = line + 1;
                if (!this.Info.IsFloorOrEmptySeat(downLine, leftColumn)) { return false; }
            }
            return true;
        }
        private bool IsSeatReadyToBusyByRight(int line, int column)
        {
            if (column == this.Info.ColumnCount - 1) { return true; }

            var rightColumn = column + 1;
            if (!this.Info.IsFloorOrEmptySeat(line, rightColumn)) { return false; }

            if (line > 0)
            {
                var upLine = line - 1;
                if (!this.Info.IsFloorOrEmptySeat(upLine, rightColumn)) { return false; }
            }
            if (line < this.Info.LineCount - 1)
            {
                var downLine = line + 1;
                if (!this.Info.IsFloorOrEmptySeat(downLine, rightColumn)) { return false; }
            }
            return true;
        }
        private bool IsSeatReadyToBusyByUp(int line, int column)
        {
            if (line == 0) { return true; }

            var upLine = line - 1;
            return this.Info.IsFloorOrEmptySeat(upLine, column);
        }
        private bool IsSeatReadyToBusyByDown(int line, int column)
        {
            if (line == this.Info.LineCount - 1) { return true; }

            var downLine = line + 1;
            return this.Info.IsFloorOrEmptySeat(downLine, column);
        }
    }
}
