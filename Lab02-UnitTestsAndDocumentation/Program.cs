using System;

namespace Lab02_UnitTestsAndDocumentation
{
    public class Program
    {
        // There must not be any console readlines or write lines in your external methods
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Console Bank! Choose an action by inputting the corresponding number.");
            Console.WriteLine("1. View Balance" + Environment.NewLine + "2. Withdraw" + Environment.NewLine + "3. Deposit" + Environment.NewLine + "4. Exit");
            DelegateAction();
        }

        public static int balance = 5000;

        public static void DelegateAction(string exception = "")
        {
            if (exception != "")
            {
                Console.WriteLine(exception);
            }

            Console.WriteLine("1. View Balance" + Environment.NewLine + "2. Withdraw" + Environment.NewLine + "3. Deposit" + Environment.NewLine + "4. Exit");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    ViewBalance();
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

        public static int Withdraw(string input)
        {
            try
            {
                int input = int.Parse(input);
            }
            catch (FormatException e)
            {
                DelegateAction("Those are words. Enter a valid number.");
            }

            return Program.balance - input;
        }
    }
}
