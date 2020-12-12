using System.Linq;

namespace AdventOfCode.Day11
{
    public class SeatLayoutInfo
    {
        private readonly char[][] seats;
        private readonly char[][] seatsClone;
        private readonly char emptySeatLabel = 'L';
        private readonly char busySeatLabel = '#';
        private readonly char floorLabel = '.';

        public SeatLayoutInfo(string[] seatLines)
        {
            this.ColumnCount = seatLines[0].Length;
            this.LineCount = seatLines.Length;
            this.seats = seatLines.Select(seatLine => seatLine.ToArray()).ToArray();
            this.seatsClone = new char[this.LineCount][];
            this.CreateClone(this.seats, this.seatsClone);
        }

        public int ColumnCount { get; private set; }
        public int LineCount { get; private set; }

        public bool IsSeatEmpty(int line, int column) => this.seats[line][column] == this.emptySeatLabel;
        public bool IsFloor(int line, int column) => this.seats[line][column] == this.floorLabel;
        public bool IsSeatBusy(int line, int column) => this.seats[line][column] == this.busySeatLabel;
        public bool IsFloorOrEmptySeat(int line, int column) => this.IsFloor(line, column) || this.IsSeatEmpty(line, column);

        public void SetBookingState(int line, int column, bool busy)
        {
            this.seatsClone[line][column] = busy ? this.busySeatLabel : this.emptySeatLabel;
        }

        public int GetNumberOfSeatsBusy()
        {
            var busySeats = 0;

            for (int ixLine = 0; ixLine < this.LineCount; ixLine++)
            {
                for (int ixColumn = 0; ixColumn < this.ColumnCount; ixColumn++)
                {
                    if (this.IsSeatBusy(ixLine, ixColumn))
                    {
                        busySeats++;
                    }
                }
            }
            return busySeats;
        }

        public bool ExistsPendingChanges()
        {
            for (int ixLine = 0; ixLine < this.LineCount; ixLine++)
            {
                for (int ixColumn = 0; ixColumn < this.ColumnCount; ixColumn++)
                {
                    if (this.seats[ixLine][ixColumn] != this.seatsClone[ixLine][ixColumn])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ApplyPendingChanges()
        {
            if (!this.ExistsPendingChanges()) { return false; }
            this.CreateClone(this.seatsClone, this.seats);

            return true;
        }

        private void CreateClone(char[][] input, char[][] output)
        {
            for (int ixLine = 0; ixLine < this.LineCount; ixLine++)
            {
                output[ixLine] = (char[])input[ixLine].Clone();
            }
        }

        public bool IsOutOfRange(Location location)
        {
            return location.Line < 0 || location.Line >= this.LineCount ||
                location.Column < 0 || location.Column >= this.ColumnCount;
        }
    }
}
