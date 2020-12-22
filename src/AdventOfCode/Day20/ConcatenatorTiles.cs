using System;
using System.Collections.Generic;

namespace AdventOfCode.Day20
{
    public class ConcatenatorTiles
    {
        public string[] Concatenate(Tile topLeftTile)
        {
            List<string> result = new List<string>();
            var currentTile = topLeftTile;
            while (currentTile != null)
            {
                var lineTile = this.ConcatenateLine(currentTile);
                result.AddRange(lineTile);
                currentTile = currentTile.TileDown;
            }

            return result.ToArray();
        }

        private List<string> ConcatenateLine(Tile tileInitial)
        {
            var currentTile = tileInitial;

            Func<Tile> getNexTile = () => tileInitial.TileLeft != null ? currentTile.TileLeft : currentTile.TileRight;

            var result = new List<string>();

            while (currentTile != null)
            {
                var currentPattern = currentTile.GetPatternWithoutBorders();
                for (int ixc = 0; ixc < currentPattern.Length; ixc++)
                {
                    if (result.Count == ixc)
                    {
                        result.Add(currentPattern[ixc]);
                    }
                    else
                    {
                        result[ixc] = result[ixc] + currentPattern[ixc];
                    }
                }
                currentTile = getNexTile();
            }

            return result;
        }
    }
}