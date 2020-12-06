using System.Linq;
using System;

namespace AdventOfCode.Day06
{
    public class GroupAnswerIntersectAcumulator : IGroupAnswerAcumulator
    {
        public char[] GetYesAnswers(string answersInfo)
        {
            var numberIndividualAnswers =
                answersInfo.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Count();
            var commonYesAnswers = answersInfo.Replace("\n", "")
                .GroupBy(answer=> answer)
                .Where(grouped => grouped.Count() == numberIndividualAnswers)
                .Select(grouped => grouped.Key)
                .ToArray();
            
            Array.Sort(commonYesAnswers);

            return commonYesAnswers;
        }
    }
}