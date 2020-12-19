using System.Collections.Generic;

namespace AdventOfCode.Day17
{
    public class CubesState
    {
        private bool[][][] cubesTemp;
        private bool[][][] cubes;

        public int GetNumberOfCubesActives(Location location)
        {
            return 0;
        }

        public bool IsActive(Location location) => this.cubes[location.Layer][location.Column][location.Line];

        private List<Location> GetNeighbors(Location location)
        {
            List<Location> locations = new List<Location>();
            for (int ix = -1; ix < 2; ix++)
            {
                for (int iy = -1; iy < 2; iy++)
                {
                    for (int iz = -1; iz < 2; iz++)
                    {
                        if (ix == 0 && iy == 0 && iz == 0) { break; }

                        locations.Add(new Location()
                        {
                            Line = location.Line + ix,
                            Column = location.Column + iy,
                            Layer = location.Layer + iz
                        });
                    }
                }
            }
            return locations;
        }
    }
}
