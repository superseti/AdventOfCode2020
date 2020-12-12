using AdventOfCode.Day11;
using Xunit;

namespace AdventOfCode.Tests.Day11
{
    public class SeatsTurnHandlerTests
    {
        private readonly SeatsTurnHandler sut;
        public SeatsTurnHandlerTests()
        {
            this.sut = new SeatsTurnHandler();
        }

        [ClassData(typeof(OccupedSeatsData))]
        [Theory]
        public void HandleTurn_ShouldWork(string[] input, int expectedBusySeats)
        {
            SeatLayoutInfo info = new SeatLayoutInfo(input);
            IBusyChecker chequer = new BusyRulesChecker(info);

            this.sut.HandleTurn(info, chequer);

            var busySeats = info.GetNumberOfSeatsBusy();

            Assert.Equal(expectedBusySeats, busySeats);
        }

        [ClassData(typeof(OccupedSeatsV2Data))]
        [Theory]
        public void HandleTurn_With5_ShouldWork(string[] input, int expectedBusySeats)
        {
            SeatLayoutInfo info = new SeatLayoutInfo(input);
            IBusyChecker chequer = new BusyRulesChecker(info);

            this.sut.HandleTurn(info, chequer);

            var busySeats = info.GetNumberOfSeatsBusy();

            Assert.Equal(expectedBusySeats, busySeats);
        }

    }
}
