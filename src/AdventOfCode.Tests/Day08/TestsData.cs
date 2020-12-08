using System.Collections;
using System.Collections.Generic;

namespace AdventOfCode.Tests.Day08
{
    public class ProgramLinesData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "acc +8", 1, "acc", 8, "acc", 8 };
            yield return new object[] { @"acc +8
nop +139
nop +383
jmp +628
acc -6
acc +29
acc +9
jmp +457
acc +29
acc +38
nop +451
jmp +44
acc +24
nop +260
acc +20
jmp +24
acc +36
acc +41
acc +31
acc +42
jmp +35
acc +21
nop -216", 23, "acc", 8, "nop", -216 };
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }

    public class ExecutingLinesData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { @"acc +8
nop +139
nop +383
", 1, 8};
            yield return new object[] { @"jmp +8
nop +139
nop +383
nop +383
nop +383
nop +383
nop +383
nop +383
nop +383
nop +383
", 8, 0 };
            yield return new object[] { @"nop +8
jmp +139
acc +383
nop +383
nop +383
nop +383
nop +383
nop +383
nop +383
nop +383
", 1, 0 };
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }

    public class ExecutingNonLoopAndLoopLinesData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6", 5, false };
            yield return new object[] { @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
nop -4
acc +6", 8 , true};
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
    
    public class ChangeWizardData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6", 7, 8 };
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
