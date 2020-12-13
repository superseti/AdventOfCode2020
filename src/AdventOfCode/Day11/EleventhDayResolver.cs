using AdventOfCode.Helpers;
using System;

namespace AdventOfCode.Day11
{
    public class EleventhDayResolver : IResolver
    {
        public string ResolveFirst()
        {
            var inputData = new InputDataReader().GetInputDataSplitted(this);
            var info = new SeatLayoutInfo(inputData);

            SeatsTurnHandler handler = new SeatsTurnHandler();
            IBusyChecker chequer = new BusyRulesChecker(info);

            while (handler.HandleTurn(info, chequer)) { }

            return $"{info.GetNumberOfSeatsBusy()}";
        }

        public string ResolveSecond()
        {
            throw new NotImplementedException();
        }
    }
}
