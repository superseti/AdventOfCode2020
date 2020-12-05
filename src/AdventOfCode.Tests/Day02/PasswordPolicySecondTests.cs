using AdventOfCode.Day02;
using Xunit;

namespace AdventOfCode.Tests.Day02
{
    public class PasswordPolicySecondTests
    {
        private PasswordPolicySecond sut;

        public PasswordPolicySecondTests()
        {
            this.sut = new PasswordPolicySecond();
        }

        [InlineData("1-3 a", "abcde", true)]
        [InlineData("1-3 b", "cdefg", false)]
        [InlineData("2-9 c", "ccccccccc", false)]
        [Theory]
        public void IsPasswordValid_ShouldWorks(string policyInfo, string password, bool isValid)
        {
            this.sut.Initialize(policyInfo);

            var result = this.sut.IsPasswordValid(password);

            Assert.Equal(isValid, result);
        }
    }
}
