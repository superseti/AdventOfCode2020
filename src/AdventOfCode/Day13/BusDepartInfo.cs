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
        public Int64 CurrentDepartureTime { get; private set; }
        public bool IsValidForPattern { get; private set; }

        internal void GoToNextPoint(Int64 nextPoint)
        {
            var requiredNextPoint = (nextPoint / this.BusId) * this.BusId + this.MinutesOffset;
            this.CurrentDepartureTime = (requiredNextPoint / this.BusId) * this.BusId;
            this.IsValidForPattern = this.CurrentDepartureTime == requiredNextPoint;
        }
    }
}
