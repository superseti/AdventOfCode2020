namespace AdventOfCode.Day05
{
    public class SeatInfo
    {
        public SeatInfo(string seatInfo, ColumnSeatResolver columnResolver, RowSeatResolver rowResolver)
        {
            var columnInfo = seatInfo.Substring(7);
            var rowInfo = seatInfo.Substring(0,7);
            this.Column = columnResolver.Resolve(columnInfo);
            this.Row = rowResolver.Resolve(rowInfo);
            this.Id = this.Column + (this.Row * 8);
        }

        public int Column { get; private set; }
        public int Row { get; private set; }
        public int Id { get; private set; }
    }
}
