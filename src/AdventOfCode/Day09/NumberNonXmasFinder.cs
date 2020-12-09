using System;
using System.Linq;

namespace AdventOfCode.Day09
{
    public class NumberNonXmasFinder
    {
        public int PreambleSize { get; set; }

        public NumberNonXmasFinderInfo GetNumberNonXmas(Int64[] numbers)
        {
            var decomponer = new Decomponer();
            for (int ixNumber = PreambleSize; ixNumber < numbers.Length; ixNumber++)
            {
                var initIndex = ixNumber - this.PreambleSize;
                var possibleElements = numbers
                    .Skip(initIndex)
                    .Take(this.PreambleSize)
                    .ToArray();
                var nextNumber = numbers[ixNumber];
                if (!decomponer.IsPossibleDecompone(nextNumber, possibleElements))
                {
                    return new NumberNonXmasFinderInfo()
                    {
                        Number = nextNumber,
                        Position = ixNumber
                    };
                }
            }
            return null;
        }
    }
}