using System.Linq;

namespace AdventOfCode.Day20
{
    public class ManipulaterTiles
    {
        public void Rotate(Tile tile)
        {
            if (tile.IsArrangedToAny) { return; }
            var result = tile.Data
                .Select(dataLIne => new bool[tile.Data.Length])
                .ToArray();

            for (int ix = 0; ix < tile.Data.Length; ix++)
            {
                for (int jx = 0; jx < tile.Data.Length; jx++)
                {
                    result[jx][tile.Data.Length - ix - 1] = tile.Data[ix][jx];
                }
            }
            tile.Data = result;
        }
        public void Flip(Tile tile)
        {
            if (tile.IsArrangedToAny) { return; }
            for (int jx = 0; jx < Tile.Size; jx++)
            {
                tile.Data[jx] = tile.Data[jx].Reverse().ToArray();
            }
        }

        public string[] RotatePicture(string[] picture)
        {
            var result = new string[picture.Length];
            for (int ix = 0; ix < picture.Length; ix++)
            {
                result[ix] = picture[ix];
            }

            for (int ix = 0; ix < picture.Length; ix++)
            {
                for (int jx = 0; jx < picture.Length; jx++)
                {
                    result[jx] = result[jx].Substring(0, picture.Length - ix - 1) +
                        picture[ix][jx] +
                        result[jx].Substring(picture.Length - ix, ix);
                }
            }
            return result;
        }
        public string[] FlipPicture(string[] picture)
        {
            var result = new string[picture.Length];

            for (int jx = 0; jx < picture.Length; jx++)
            {
                result[jx] = string.Join("", picture[jx].Reverse());
            }

            return result;
        }
    }
}
