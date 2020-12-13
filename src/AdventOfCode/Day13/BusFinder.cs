using System;
using System.Linq;

namespace AdventOfCode.Day13
{
    public class BusFinder
    {
        public int EarliestTimeStampDepart { get; set; }
        public BusDepartWaitingInfo FindBus(string listBusIds)
        {
            var busesInfo = listBusIds
                .Replace("x", "")
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(busIdStr => Convert.ToInt32(busIdStr))
                .Select(busId => new BusDepartWaitingInfo(this.EarliestTimeStampDepart, busId))
                .OrderBy(busInfo => busInfo.MinutesWaiting);

            return busesInfo.First();
        }
    }
}
