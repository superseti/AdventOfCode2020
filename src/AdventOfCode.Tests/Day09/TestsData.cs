using System;
using System.Collections;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Day09
{
    public class DecomponerData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 10, new Int64[] { 5, 6 }, false };
            yield return new object[] { 10, new Int64[] { 4, 6 }, true };
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }

    public class ComponerData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 10, new Int64[] { 4, 6 }, 4, 6 };
            yield return new object[] { 127, new Int64[] { 35,
20 ,
15 ,
25 ,
47 ,
40 ,
62 ,
55 ,
65 ,
95 ,
102,
117,
150,
182,
127,
219,
299,
277,
309,
576}, 15, 47 };
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}