using System;
using System.Net.NetworkInformation;
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
			var sbOutput = new StringBuilder();
			ConsoleKeyInfo userKey;
			do
			{
				string nextUserInputLine = Console.ReadLine();
				sbString.Append(nextUserInputLine + Environment.NewLine);

				// Check when user hits escape
				userKey = Console.ReadKey();
			} while (userKey.Key != ConsoleKey.Escape);
			
			var userInputLines = sbString.ToString().Split(Environment.NewLine);

			// TODO Loop through list running pings AND read the avg time
			foreach (var line in userInputLines)
			{
				if (string.IsNullOrEmpty(line))
					continue;

				// TODO Figure out if url or IP address

				// Check if its actually a url first
				Uri uriResult;
				bool result = Uri.TryCreate(line, UriKind.Absolute, out uriResult)
					&& (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

				// TODO Make request
				Ping pingSender = new Ping();
				PingOptions options = new PingOptions();

				// Use the default Ttl value which is 128,
				// but change the fragmentation behavior.
				options.DontFragment = true;

				// Create a buffer of 32 bytes of data to be transmitted.
				string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
				byte[] buffer = Encoding.ASCII.GetBytes(data);
				int timeout = 120;
				PingReply reply = pingSender.Send(line, timeout, buffer, options);
				if (reply.Status != IPStatus.Success)
				{
					// Ping didnt happen
					sbOutput.Append($"{line} : Failed|");
				}
				else
				{
					// Ping happened
					sbOutput.Append($"{line} : {reply.RoundtripTime}|");
				}
			}

			// TODO Print nice table with urls/ips and times
			foreach (var outLine in sbOutput.ToString().Split("|"))
			{
				Console.WriteLine(outLine);
			}

			Console.WriteLine("Enter to exit");
			Console.ReadLine();
		}
	}
}
