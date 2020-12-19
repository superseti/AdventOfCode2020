using System.Collections;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Day17
{
    class ActiveCubesData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {new string[]{
".#.",
"..#",
"###"}, 11};
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
