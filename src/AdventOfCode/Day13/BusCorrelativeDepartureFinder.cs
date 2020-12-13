using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day13
{
    public class BusCorrelativeDepartureFinder
    {
        public Int64 FindCorrelativeDeparture(string listBusIds)
        {
            List<BusDepartInfo> buses = this.GetBusesDepartures(listBusIds);

            var maxIdBus = buses
                .OrderByDescending(bus => bus.BusId)
                .First();

            var firstBus = buses.First();

            var reducedInfo = buses;

            while (reducedInfo.Count > 2)
            {
                reducedInfo = this.BusInfoReduce(reducedInfo);
            }

            return this.GetFirstValidTime(reducedInfo[1], firstBus);

        }

        private Int64 GetFirstValidTime(BusDepartInfo info, BusDepartInfo infoReference)
        {
            for (Int64 ixTime = 1; ixTime < info.BusId * infoReference.BusId; ixTime++)
            {
                var result = (info.BusId * ixTime) - info.MinutesOffset;
                var isValid = (result + infoReference.MinutesOffset) % infoReference.BusId == 0;
                if (isValid) { return result; }
            }
            return 0;
        }

        private bool IsValid(List<BusDepartInfo> buses) => buses.All(bus => bus.IsValidForPattern);
        private void GoToNextPoint(Int64 nextPoint, List<BusDepartInfo> buses) => buses.ForEach(bus => bus.GoToNextPoint(nextPoint));

        private List<BusDepartInfo> GetBusesDepartures(string listBusIds)
        {
            List<BusDepartInfo> buses = new List<BusDepartInfo>();

            var busesPattern = listBusIds
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int ixBus = 0; ixBus < busesPattern.Count(); ixBus++)
            {
                var busIdStr = busesPattern[ixBus];
                if (busIdStr == "x") { continue; }

                buses.Add(new BusDepartInfo(Convert.ToInt32(busIdStr), ixBus));
            }
            return buses;
        }

        private List<BusDepartInfo> BusInfoReduce(List<BusDepartInfo> info)
        {
            List<BusDepartInfo> result = info.Take(1).ToList();
            result.AddRange(info.Skip(3));

            BusDepartInfo second = info[1];
            BusDepartInfo third = info[2];

            var firstVlidCoincident = this.GetFirstValidTime(second, third);

            var busId = second.BusId * third.BusId;
            var minutesOffset = busId - (firstVlidCoincident % busId);
            var busReduced = new BusDepartInfo(busId, minutesOffset);
            result.Add(busReduced);

            return result;
        }
    }
}