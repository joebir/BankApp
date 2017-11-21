using Bank.Models;
using Bank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			System.Console.WriteLine("TODO: Welcome Message");
			System.Console.WriteLine("Please enter your account number.");

			bool inputChecker = false;
			string userInput;

			do
			{
				userInput = System.Console.ReadLine();

				if (new AccountService(Int32.Parse(userInput)).GetAccount() != null) inputChecker = true;

				else
				{
					System.Console.Clear();
					System.Console.WriteLine($"Your input was {userInput}. Please enter a valid account number.");
				}
			} while (inputChecker == false);

			var acctServ = new AccountService(Int32.Parse(userInput));
			inputChecker = false;
			System.Console.Clear();

			System.Console.WriteLine("Account number verified. Please enter your PIN.");
			do
			{
				userInput = System.Console.ReadLine();

				if (acctServ.Verify(userInput)) inputChecker = true;

				else
				{
					System.Console.Clear();
					System.Console.WriteLine("Your PIN was invalid. Please try again.");
				}
			} while (inputChecker == false);

			System.Console.Clear();
			inputChecker = false;

			System.Console.WriteLine("Your PIN was verified.");

			System.Console.WriteLine("Please choose a menu option:\n" +
				"1: Check balance\n" +
				"2: Make a deposit\n" +
				"3: Make a withdrawl\n" +
				"4: Log out.");
		}
	}
}
