using AdventOfCode.Day06;
using Xunit;

namespace AdventOfCode.Tests.Day06
{
    public class AnswersAcumulatorTests
    {
        private AnswersAcumulator sut;

        public AnswersAcumulatorTests()
        {
            this.sut = new AnswersAcumulator();
        }

        [ClassData(typeof(AnswersInfoData))]
        [Theory]
        public void GetYesAnswers_ShouldWork(string[] answersInfo, int expectedCount)
        {
            var result = this.sut.GetCountYesAnswers<GroupAnswerAcumulator>(answersInfo);

            Assert.Equal(expectedCount, result);
        }

        [ClassData(typeof(AnswersIntersectInfoData))]
        [Theory]
        public void GetYesAnswersIntersect_ShouldWork(string[] answersInfo, int expectedCount)
        {
            var result = this.sut.GetCountYesAnswers<GroupAnswerIntersectAcumulator>(answersInfo);

            Assert.Equal(expectedCount, result);
        }
    }
}
