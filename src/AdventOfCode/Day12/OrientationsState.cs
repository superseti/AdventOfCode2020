using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day12
{
    public class OrientationsState
    {
        public OrientationsState()
        {
            this.OrientationMovements = new Dictionary<Orientations, int>
            {
                { Orientations.North, 0 },
                { Orientations.East, 0 },
                { Orientations.West, 0 },
                { Orientations.South, 0 }
            };
        }

        public Dictionary<Orientations, int> OrientationMovements { get; }

        public int GetManhathanDistance() => this.OrientationMovements.Sum(orientation => orientation.Value);
    }
}
