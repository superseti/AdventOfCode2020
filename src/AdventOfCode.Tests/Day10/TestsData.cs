using System;
using System.Collections;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Day10
{
    public class JoltsDifferencesData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new Object[] { new int[] { 16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4 }, 22, 5, 7 };
            yield return new Object[] { new int[] { 28, 33, 18, 42, 31, 14, 46, 20, 48, 47, 24, 23, 49, 
                                                    45, 19, 38, 39, 11, 1, 32, 25, 35, 8, 17, 7, 9, 4, 2,
                                                    34, 10, 3 }, 52, 10, 22 };
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }

    public class JoltsArrangesData: IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new Object[] { new int[] { 16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4 }, 8 };
            yield return new Object[] { new int[] { 28, 33, 18, 42, 31, 14, 46, 20, 48, 47, 24, 23, 49,
                                                    45, 19, 38, 39, 11, 1, 32, 25, 35, 8, 17, 7, 9, 4, 2,
                                                    34, 10, 3 }, 19208 };
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
