using System.Linq;

namespace AdventOfCode.Day06
{
    public class AnswersAcumulator
    {
        public int GetCountYesAnswers<T>(string[] answersInfo)
            where T: IGroupAnswerAcumulator, new()
        {
            var grouper = new T();

            return answersInfo
                .Select(info => grouper.GetYesAnswers(info).Length)
                .Sum();
        }
    }
}