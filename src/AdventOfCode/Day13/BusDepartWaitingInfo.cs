namespace AdventOfCode.Day13
{
    public class BusDepartWaitingInfo
    {
        public BusDepartWaitingInfo(int earliestDepart, int busId)
        {
            this.IdBus = busId;
            var module = earliestDepart % this.IdBus;
            var lastDeparture = (earliestDepart / busId) * busId;
            this.TimeStampDepart = lastDeparture + (module == 0 ? 0 : this.IdBus);
            this.MinutesWaiting = this.TimeStampDepart - earliestDepart;
        }

        public int IdBus { get; private set; }
        public int TimeStampDepart { get; private set; }
        public int MinutesWaiting { get; private set; }
    }
}
