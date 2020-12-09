using System;
using System.Linq;

namespace AdventOfCode.Day09
{
    public class ElementsFinder
    {
        public Int64[] GetElementsToAdd(Int64 number, Int64[] inputData)
        {
            for (int ixNumber = 0; ixNumber < inputData.Length - 1; ixNumber++)
            {
                var seed = inputData[ixNumber];
                var newPreamble = inputData.Skip(ixNumber + 1).ToArray();

                var elements = this.GetElementsToAdd(number, newPreamble, seed);
                if (elements != null)
                {
                    return elements.Prepend(seed).ToArray(); ;
                }
            }
            return null;
        }

        private Int64[] GetElementsToAdd(Int64 number, Int64[] preamble, Int64 seed)
        {
            if (preamble.Length == 0) { return null; }

            var numberToSearch = number - seed;

            var firstNumber = preamble[0];
            if (firstNumber == numberToSearch)
            {
                return new Int64[] { firstNumber };
            }
            if (firstNumber > numberToSearch) { return null; }

            var newSeed = firstNumber;
            var newPreamble = preamble.Skip(1).ToArray();

            var numbersElements = this.GetElementsToAdd(numberToSearch, newPreamble, newSeed);

            if (numbersElements != null)
            {
                return numbersElements.Prepend(firstNumber).ToArray();
            }

            return null;
        }
    }
}
