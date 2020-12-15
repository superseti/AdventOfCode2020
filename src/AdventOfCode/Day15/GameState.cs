using System.Collections.Generic;

namespace AdventOfCode.Day15
{
    public class GameState
    {
        public Dictionary<int, NumberAparitions> NumberAparitions { get; private set; } = new Dictionary<int, NumberAparitions>();
        public NumberAparitions LastNumber { get; set; }
    }
}