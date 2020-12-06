using System.Collections;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Day06
{
    class GroupAnswersInfoData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "abc", new char[] { 'a', 'b', 'c' } };
            yield return new object[] { "a\nb\nc", new char[] { 'a', 'b', 'c' } };
            yield return new object[] { "ab\nac", new char[] { 'a', 'b', 'c' } };
            yield return new object[] { "a\na\na\na", new char[] { 'a' } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    class AnswersInfoData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 
                new string[] { "abc", "a\nb\nc\n", "ab\nac\n", "a\na\na\na\n", "b" }, 11 
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    class AnswersIntersectInfoData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 
                new string[] { "abc", "a\nb\nc\n", "ab\nac\n", "a\na\na\na\n", "b" }, 6 
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    class GroupIntersectAnswersInfoData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "abc", new char[] { 'a', 'b', 'c' } };
            yield return new object[] { "a\nb\nc", new char[0] };
            yield return new object[] { "ab\nac", new char[] { 'a' } };
            yield return new object[] { "a\na\na\na", new char[] { 'a' } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}