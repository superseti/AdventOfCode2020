using System;
using System.Linq;

namespace AdventOfCode.Day04
{
    class PassportInfo
    {
        public PassportInfo(string passportsInfo)
        {
            var data = passportsInfo
                .Replace("\n", " ")
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            this.Fields = data.Select(info => new PassportField(info)).ToArray();
        }

        public PassportField[] Fields { get; private set; }
    }
}
