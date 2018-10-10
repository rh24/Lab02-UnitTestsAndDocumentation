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

            while (userInput != "exit")
            {
                DelegateAction(userInput);
            }
        }

        public static int balance = 5000;

        public static void DelegateAction(string userInput, string exception = "")
        {
            if (exception != "")
            {
                Console.WriteLine(exception);
            }

            switch (userInput)
            {
                case "1":
                    Console.WriteLine(ViewBalance().ToString());
                    break;
                case "2":
                    Console.WriteLine("How much would you like to withdraw?");
                    string input = Console.ReadLine();
                    Withdraw(input);
                    break;
                default:
                    break;
            }
        }

        public static int ViewBalance()
        {
            return Program.balance;
        }

        public static dynamic Withdraw(string input)
        {
            try
            {
                object parsed = int.Parse(input);
                if (parsed.GetType() != typeof(int)) throw new FormatException("Those are words. Enter a number.");
                if (Program.balance - (int)parsed < 0) throw new CustomException("You don't have enough money for that.");
            }
            catch (FormatException ex)
            {
                return ex.Message;
            }
            catch (CustomException ex)
            {
                return ex.Message;
            }
            finally
            {
                ViewBalance();
            }

            return Program.balance - int.Parse(input);
        }

        public static dynamic Deposit(string input)
        {
            try
            {
                object parsed = Convert.ToInt32(input);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                ViewBalance();
            }

            return Program.balance + int.Parse(input);
        }
    }
}
