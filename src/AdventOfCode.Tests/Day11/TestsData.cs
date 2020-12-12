using System.Collections;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Day11
{
    class OccupedSeatsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {new string[]{
                "L.LL.LL.LL",
"LLLLLLL.LL",
"L.L.L..L..",
"LLLL.LL.LL",
"L.LL.LL.LL",
"L.LLLLL.LL",
"..L.L.....",
"LLLLLLLLLL",
"L.LLLLLL.L",
"L.LLLLL.LL" }, 71};

            yield return new object[] {new string[]{
                "#.##.##.##",
"#######.##",
"#.#.#..#..",
"####.##.##",
"#.##.##.##",
"#.#####.##",
"..#.#.....",
"##########",
"#.######.#",
"#.#####.##" }, 20};
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
    
    class OccupedSeatsV2Data : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {new string[]{
                "#.L#.L#.L#",
"#LLLLLL.LL",
"L.L.L..#..",
"##L#.#L.L#",
"L.L#.#L.L#",
"#.L####.LL",
"..#.#.....",
"LLL###LLL#",
"#.LLLLL#.L",
"#.L#LL#.L#" }, 26};
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
