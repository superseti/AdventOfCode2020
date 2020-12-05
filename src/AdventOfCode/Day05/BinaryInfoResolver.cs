using System;

namespace AdventOfCode.Day05
{
    public abstract class BinaryInfoResolver
    {
        public string StringValue1 { get; protected set; }
        public string StringValue0 { get; protected set; }

        public int Resolve(string info)
        {
            var binaryData = info.Replace(this.StringValue1, "1").Replace(this.StringValue0, "0");
            return Convert.ToInt32(binaryData, 2);
        }
    }
}