using AdventOfCode.Day06;
using Xunit;

namespace AdventOfCode.Tests.Day06
{
    public class GroupAnswerIntersectAcumulatorTests
    {
        private GroupAnswerIntersectAcumulator sut;

        public GroupAnswerIntersectAcumulatorTests()
        {
            this.sut = new GroupAnswerIntersectAcumulator();
        }

        [ClassData(typeof(GroupIntersectAnswersInfoData))]
        [Theory]
        public void GetYesAnswers_ShouldWorks(string answersInfo, char[] answersExpected)
        {
            var result = this.sut.GetYesAnswers(answersInfo);

            Assert.Equal(answersExpected, result);
        }
    }
}
