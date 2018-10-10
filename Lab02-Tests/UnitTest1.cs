using Xunit;
using System;
using static Lab02_UnitTestsAndDocumentation.Program;
using Lab02_UnitTestsAndDocumentation;

namespace Lab02_Tests
{
    public class UnitTest1
    {
        [Fact]
        public static void CheckBalance()
        {
            Assert.IsType<string>(ViewBalance());
        }

        [Theory]
        // [InlineData(2000, CheckBalance(), 3000)]
        // How would I do something like that?
        [InlineData(2000, "3000")]
        public static void CheckWithdrawal(int expected, string input)
        {
            Assert.Equal(expected, Withdraw(input));
        }

        // This test is taking too long!
        // It was taking too long because my catch returns the user to DelegateAction, prompting the user again.
        // I think it was caught in an infinite loop.
        [Theory]
        [InlineData("this is a string, not a parsable number")]
        public static void CheckFailedWithdrawal(string input)
        {
            Action badWithdrawal = () => Withdraw(input);
            Assert.Throws<FormatException>(badWithdrawal);
        }

        [Theory]
        [InlineData("6000")]
        public static void CheckOverdrawn(string input)
        {
            var message = "You don't have enough money for that.";

            Assert.Equal(message, Withdraw(input));
        }

        [Theory]
        [InlineData("1000")]
        public static void CheckDeposit(string input)
        {
            Assert.Equal(6000, Deposit(input));
        }

        [Theory]
        [InlineData("Hello")]
        public static void BadDeposit(string input)
        {
            Assert.Throws<FormatException>(() => Deposit(input));
        }
    }
}
