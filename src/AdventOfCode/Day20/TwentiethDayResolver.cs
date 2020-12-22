using AdventOfCode.Helpers;

namespace AdventOfCode.Day20
{
    public class TwentiethDayResolver : IResolver
    {
        public string ResolveFirst()
        {
            var inputData = new InputDataReader().GetInputDataSplittedByBlankLine(this);
            var arrangator = new TilesArrangator();
            arrangator.Init(inputData);

            return arrangator.GetCornersCheckSum().ToString();
        }

        public string ResolveSecond()
        {
            var inputData = new InputDataReader().GetInputDataSplittedByBlankLine(this);
            var arrangator = new TilesArrangator();
            arrangator.Init(inputData);
            arrangator.ArrangeTiles();


            return new MonsterFinder().GetWaterRoughness(arrangator.TopLeftTile).ToString();
        }
    }
}
