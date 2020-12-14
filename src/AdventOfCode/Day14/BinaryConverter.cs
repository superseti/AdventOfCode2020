using System;

namespace AdventOfCode.Day14
{
    public class BinaryConverter
    {
        public string ToBinary(int decimalValue) => Convert.ToString(decimalValue, 2);
        public Int64 ToDecimal(string binaryValue) => Convert.ToInt64(binaryValue, 2);
    }
}