using System.Collections;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Day19
{
    public class RulesTestsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new string[]{
"0: 4 1 5",
"1: 2 3 | 3 2",
"2: 4 4 | 5 5",
"3: 4 5 | 5 4",
"4: \"a\"",
"5: \"b\"" }, "ababbb", true};

            yield return new object[] {
                new string[]{
"0: 4 1 5",
"1: 2 3 | 3 2",
"2: 4 4 | 5 5",
"3: 4 5 | 5 4",
"4: \"a\"",
"5: \"b\"" }, "bababa", false};
            yield return new object[] {
                new string[]{
"0: 4 1 5",
"1: 2 3 | 3 2",
"2: 4 4 | 5 5",
"3: 4 5 | 5 4",
"4: \"a\"",
"5: \"b\"" }, "aaaabbb", false};
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
