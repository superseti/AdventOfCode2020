using AdventOfCode.Helpers;
using System;

namespace AdventOfCode.Day11
{
    public class EleventhDayResolver : IResolver
    {
        public void ResolveFirst()
        {
            var inputData = new InputDataReader().GetInputDataSplitted(this);
            var info = new SeatLayoutInfo(inputData);

            SeatsTurnHandler handler = new SeatsTurnHandler();
            IBusyChecker chequer = new BusyRulesChecker(info);

            while (handler.HandleTurn(info, chequer)) { }

            Console.WriteLine($"Busy end seats: {info.GetNumberOfSeatsBusy()}");
        }

        public void ResolveSecond()
        {
            throw new NotImplementedException();
        }
    }
}
