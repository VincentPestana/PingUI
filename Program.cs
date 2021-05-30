using System;
using System.Text;

namespace PingUI
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("TODO : Welcome message!");

			// Get input from user AND convert to list
			Console.WriteLine("Hit Escape to stop inputting urls");
			var sbString = new StringBuilder();
			ConsoleKeyInfo userKey;
			do
			{
				string nextUserInputLine = Console.ReadLine();
				sbString.Append(nextUserInputLine + Environment.NewLine);

				// Check when user hits escape
				userKey = Console.ReadKey();
			} while (userKey.Key != ConsoleKey.Escape);
			var test = 0;

			var userInputLines = sbString.ToString().Split(Environment.NewLine);

			// TODO Loop through list running pings AND read the avg time

			// TODO Print nice table with urls/ips and times
		}
	}
}
