using AdventOfCode.Day06;
using Xunit;

namespace AdventOfCode.Tests.Day06
{
    public class GroupAnswerAcumulatorTests
    {
        private GroupAnswerAcumulator sut;

        public GroupAnswerAcumulatorTests()
        {
            this.sut = new GroupAnswerAcumulator();
        }

        [ClassData(typeof(GroupAnswersInfoData))]
        [Theory]
        public void GetYesAnswers_ShouldWorks(string answersInfo, char[] answersExpected)
        {
            var result = this.sut.GetYesAnswers(answersInfo);

            Assert.Equal(answersExpected, result);
        }
    }
}
