using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day20
{
    public class TilesArrangator
    {
        private readonly ManipulaterTiles manipulator = new ManipulaterTiles();
        private readonly LinesUpChecker checker = new LinesUpChecker();
        private Tile[] _tiles;

        public void Init(string[] tilesText)
        {
            this._tiles = tilesText.Select(tileText => new Tile(tileText)).ToArray();
        }

        public Tile TopLeftTile => this._tiles.First(tile => tile.TileUp == null && tile.TileLeft == null);

        public Int64 GetCornersCheckSum()
        {
            this.ArrangeTiles();
            var tileTopLeft = this._tiles.Single(tile => tile.TileUp == null && tile.TileLeft == null);
            var tileTopRight = this._tiles.Single(tile => tile.TileUp == null && tile.TileRight == null);
            var tileDownLeft = this._tiles.Single(tile => tile.TileDown == null && tile.TileLeft == null);
            var tileDownRight = this._tiles.Single(tile => tile.TileDown == null && tile.TileRight == null);

            return tileTopLeft.Id * tileTopRight.Id * tileDownLeft.Id * tileDownRight.Id;
        }

        public void ArrangeTiles()
        {
            var notArrangedTiles = new List<Tile>(this._tiles.Skip(1)) { };
            var arrangedTiles = new List<Tile>() { this._tiles[0] };

            while (notArrangedTiles.Count() > 0)
            {
                List<Tile> arrangedInCycle = new List<Tile>();
                foreach (var currentArranged in arrangedTiles)
                {
                    foreach (var currentNotArranged in notArrangedTiles)
                    {
                        var result = this.checker.AreValid(currentArranged, currentNotArranged, this.manipulator);
                        if (result.Success && !arrangedInCycle.Contains(currentNotArranged))
                        {
                            arrangedInCycle.Add(currentNotArranged);
                        }
                    }
                }
                arrangedInCycle.ForEach(item => notArrangedTiles.Remove(item));
                arrangedInCycle.ForEach(item => arrangedTiles.Add(item));

            }
        }
    }
}