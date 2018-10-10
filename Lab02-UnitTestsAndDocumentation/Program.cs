using System;

namespace Lab02_UnitTestsAndDocumentation
{
    public class CustomException : Exception
    {
        public CustomException(string message)
            : base(String.Format($"{message}")) { }

    }

    public class Program
    {
        // There must not be any console readlines or write lines in your external methods
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Console Bank! Choose an action by inputting the corresponding number.");
            Console.WriteLine("1. View Balance" + Environment.NewLine + "2. Withdraw" + Environment.NewLine + "3. Deposit" + Environment.NewLine + "4. Exit");
            string userInput = Console.ReadLine();

            DelegateAction(userInput);
            while (DoSomethingElse() == "y")
            {
                Console.WriteLine("1. View Balance" + Environment.NewLine + "2. Withdraw" + Environment.NewLine + "3. Deposit" + Environment.NewLine + "4. Exit");
                DelegateAction(Console.ReadLine());
            }
        }

        public static int balance = 5000;

        public static void DelegateAction(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    Console.WriteLine(ViewBalance().ToString());
                    break;
                case "2":
                    Console.WriteLine("How much would you like to withdraw?");
                    string input = Console.ReadLine();
                    Console.WriteLine(Withdraw(input));
                    break;
                case "3":
                    Console.WriteLine("How much would you like to deposit?");
                    input = Console.ReadLine();
                    Console.WriteLine(Deposit(input));
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Not a valid option!");
                    DelegateAction(Console.ReadLine());
                    break;
            }
        }

        public static string DoSomethingElse()
        {
            Console.WriteLine("Would you like to do something else? y/n");
            string userInput = Console.ReadLine();

            return userInput;
        }

        public static string ViewBalance()
        {
            return $"Your balance is {Program.balance.ToString()}";
        }

        public static dynamic Withdraw(string input)
        {
            try
            {
                object parsed = int.Parse(input);
                if (parsed.GetType() != typeof(int)) throw new FormatException("Those are words. Enter a number.");
                if (Program.balance - (int)parsed < 0) throw new CustomException("You don't have enough money for that.");
            }
            catch (FormatException e)
            {
                throw e;
            }
            catch (CustomException ex)
            {
                return ex.Message;
            }
            finally
            {
                ViewBalance();
            }

            return Program.balance -= int.Parse(input);
        }

        public static dynamic Deposit(string input)
        {
            try
            {
                object parsed = int.Parse(input);
            }
            catch (FormatException e)
            {
                throw e;
            }
            finally
            {
                ViewBalance();
            }

            return Program.balance += int.Parse(input);
        }
    }
}
