using AdventOfCode.Helpers;
using System;

namespace AdventOfCode.Day12
{
    public class TwelfthDayResolver : IResolver
    {
        public void ResolveFirst()
        {
            var inputData = new InputDataReader().GetInputDataSplitted(this);
            var ship = new Ship<InstructionsInterpreter>();
            ship.ReadInstructions(inputData);


            Console.WriteLine($"Manhathan Distance: {ship.GetManhathanDistance()}");
        }

        public void ResolveSecond()
        {
            var inputData = new InputDataReader().GetInputDataSplitted(this);
            var ship = new Ship<InstructionsInterpreterWayPoint>();
            ship.ReadInstructions(inputData);


            Console.WriteLine($"Manhathan Distance: {ship.GetManhathanDistance()}");
        }
    }
}
