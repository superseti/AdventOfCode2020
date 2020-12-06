using System.Linq;
using System;

namespace AdventOfCode.Day06
{
    public class GroupAnswerAcumulator: IGroupAnswerAcumulator
    {
        public char[] GetYesAnswers(string answersInfo)
        {
            var result = answersInfo.Replace("\n","").Distinct().ToArray();
            Array.Sort(result);

            return result;
        }
    }
}