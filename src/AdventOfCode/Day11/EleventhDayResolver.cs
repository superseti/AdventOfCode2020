using AdventOfCode.Helpers;
using System;

namespace AdventOfCode.Day11
{
    public class EleventhDayResolver : IResolver
    {
        public string ResolveFirst() => this.Resolve(info => new BusyRulesChecker(info));

        public string ResolveSecond() => this.Resolve(info => new BusyRulesCheckerAmplied(info));

        public string Resolve(Func<SeatLayoutInfo, IBusyChecker> checkerCreator)
        {
            var inputData = new InputDataReader().GetInputDataSplitted(this);
            var info = new SeatLayoutInfo(inputData);

            SeatsTurnHandler handler = new SeatsTurnHandler();
            IBusyChecker chequer = checkerCreator(info);

            while (handler.HandleTurn(info, chequer)) { }

            return $"{info.GetNumberOfSeatsBusy()}";
        }
    }
}
