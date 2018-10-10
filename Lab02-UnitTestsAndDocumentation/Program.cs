﻿using System;

namespace Lab02_UnitTestsAndDocumentation
{
    public class Program
    {
        // There must not be any console readlines or write lines in your external methods
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Console Bank! Choose an action by inputting the corresponding number.");
            Console.WriteLine("1. View Balance" + Environment.NewLine + "2. Withdraw" + Environment.NewLine + "3. Deposit" + Environment.NewLine + "4. Exit");
            string userInput = Console.ReadLine();
            DelegateAction(userInput);
        }

        public static void DelegateAction(string userInput)
        {

        }

        public static int Balance()
        {
            return 5000;
        }
    }
}
