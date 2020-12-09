using System;

namespace AdventOfCode.Day09
{
    public class Decomponer
    {
        public bool IsPossibleDecompone(Int64 NumberToDecompone, Int64[] possibleElements)
        {
            for (int ixFirst = 0; ixFirst < possibleElements.Length - 1; ixFirst++)
            {
                for (int ixSecond = ixFirst + 1; ixSecond < possibleElements.Length; ixSecond++)
                {
                    if (possibleElements[ixFirst] + possibleElements[ixSecond] == NumberToDecompone)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
