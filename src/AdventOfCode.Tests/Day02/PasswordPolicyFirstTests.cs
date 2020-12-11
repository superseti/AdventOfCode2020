using AdventOfCode.Day02;
using Xunit;

namespace AdventOfCode.Tests.Day02
{
    public class PasswordPolicyFirstTests
    {
        private PasswordPolicyFirst sut;

        public PasswordPolicyFirstTests()
        {
            this.sut = new PasswordPolicyFirst();
        }

        [InlineData("1-3 a", "abcde", true)]
        [InlineData("1-3 b", "cdefg", false)]
        [InlineData("2-9 c", "ccccccccc", true)]
        [Theory]
        public void IsPasswordValid_ShouldWork(string policyInfo, string password, bool isValid)
        {
            this.sut.Initialize(policyInfo);

            var result = this.sut.IsPasswordValid(password);

            Assert.Equal(isValid, result);
        }
    }
}
