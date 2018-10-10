using Xunit;
using System;
using static Lab02_UnitTestsAndDocumentation.Program;

namespace Lab02_Tests
{
    public class UnitTest1
    {
        [Fact]
        public static void CheckBalance()
        {
            Assert.IsType<int>(ViewBalance());
        }

        [Theory]
        // [InlineData(2000, CheckBalance(), 3000)]
        // How would I do something like that?
        [InlineData(2000, "3000")]
        public static void CheckWithdrawal(int expected, string input)
        {
            Assert.Equal(expected, Withdraw(input));
        }

        [Theory]
        [InlineData("this is a string, not a parsable number")]
        public static void CheckFailedWithdrawal(string input)
        {
            Assert.Throws<FormatException>(Withdraw(input));
        }
    }
}
