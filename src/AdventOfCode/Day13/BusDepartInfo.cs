using System;

namespace AdventOfCode.Day13
{
    public class BusDepartInfo
    {
        public BusDepartInfo(Int64 busId, Int64 minutesOffset)
        {
            this.BusId = busId;
            this.MinutesOffset = minutesOffset;
        }

        public Int64 BusId { get; private set; }
        public Int64 MinutesOffset { get; private set; }
    }
}