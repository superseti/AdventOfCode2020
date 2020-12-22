using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day20
{
    public class Tile
    {
        public const int Size = 10;
        private static readonly Regex regexId = new Regex("(\\d+)");

        public Tile()
        {

        }

        public Tile(string tileText)
        {
            this.Init(tileText);
        }

        public Int64 Id { get; set; }
        public void Init(string tileText)
        {
            var tileTextLines = tileText.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            this.Id = int.Parse(Tile.regexId.Match(tileTextLines[0]).Groups[1].Value);

            var dataLines = tileTextLines.Skip(1);

            List<bool[]> tempData = new List<bool[]>();
            foreach (var line in dataLines)
            {
                tempData.Add(line.Select(charItem => charItem == '#').ToArray());
            }
            this.Data = tempData.ToArray();
        }
        public bool[][] Data { get; set; }

        public Tile TileLeft { get; set; }
        public Tile TileRight { get; set; }
        public Tile TileUp { get; set; }
        public Tile TileDown { get; set; }
        public bool IsArrangedToAny => this.TileLeft != null || this.TileRight != null || this.TileUp != null || this.TileDown != null;

        public string[] GetPatternWithoutBorders()
        {
            string[] result = this.Data.Select(dataLine => string.Join("", dataLine.Select(data => data ? '#' : '.'))).ToArray();

            if (this.TileUp != null) { result = result.Skip(1).ToArray(); }
            if (this.TileDown != null) { result = result.Take(result.Count() - 1).ToArray(); }
            if (this.TileLeft != null)
            {
                for (int ix = 0; ix < result.Length; ix++)
                {
                    result[ix] = result[ix].Substring(1);
                }
            }
            if (this.TileRight != null)
            {
                for (int ix = 0; ix < result.Length; ix++)
                {
                    result[ix] = result[ix].Substring(0, result[ix].Length - 1);
                }
            }
            return result;
        }
    }
}
