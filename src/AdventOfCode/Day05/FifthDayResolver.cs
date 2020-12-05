using AdventOfCode.Helpers;
using System;
using System.Linq;

namespace AdventOfCode.Day05
{
    public class FifthDayResolver : IResolver
    {
        public void ResolveFirst()
        {
            var seatsInfoInput = new InputDataReader().GetInputDataSplitted(this);
            ColumnSeatResolver columnResolver = new ColumnSeatResolver();
            RowSeatResolver rowResolver = new RowSeatResolver();

            var seatInfos = seatsInfoInput
                .Select(info => new SeatInfo(info, columnResolver, rowResolver))
                .OrderByDescending(info => info.Id);

            var seatInfoHighest = seatInfos.First();

            Console.WriteLine($"Column: {seatInfoHighest.Column}, Row {seatInfoHighest.Row}. Id: {seatInfoHighest.Id}");
        }

        public void ResolveSecond()
        {
            var seatsInfoInput = new InputDataReader().GetInputDataSplitted(this);
            ColumnSeatResolver columnResolver = new ColumnSeatResolver();
            RowSeatResolver rowResolver = new RowSeatResolver();

            var seatInfos = seatsInfoInput
                .Select(info => new SeatInfo(info, columnResolver, rowResolver))
                .OrderBy(info => info.Id)
                .ToArray();

            var firstId = seatInfos[0].Id;

            for (int ixSeat = 0; ixSeat < seatInfos.Length; ixSeat++)
            {
                var expectedId = firstId + ixSeat;
                if (seatInfos[ixSeat].Id != expectedId)
                {
                    var mySeatId = seatInfos[ixSeat].Id - 1;
                    Console.WriteLine($"My seatId: {mySeatId}");
                    return;
                }
            }
        }
    }
}
