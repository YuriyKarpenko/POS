using System;
using System.Diagnostics;
using System.ServiceModel;
using System.Linq;



namespace POS.Data.Service
{
	public class Programm
	{
		public static void Main()
		{
			using (ServiceHost serviceHost = new ServiceHost(typeof(Service1)))
			{
				IT.Log.Logger.MinLevel = TraceLevel.Warning;
				IT.Log.Logger.MessageSmall += Logger_MessageSmall;
				//Open the ServiceHost to create listeners and start listening for messages.
				//serviceHost.AddServiceEndpoint(
				serviceHost.Open();

				// The service can now be accessed.
				Console.WriteLine("Service started at {0}", serviceHost.BaseAddresses[0]);
				Console.WriteLine("Press ENTER to terminate service.");
				Console.WriteLine();
				Console.ReadLine();
			}
		}

		private static void Logger_MessageSmall(object sender, IT.EventArgs<TraceLevel, string, Exception> e)
		{
			var oldColor = Console.ForegroundColor;
			try
			{
				switch (e.Value1)
				{
					case TraceLevel.Error:
						Console.ForegroundColor = ConsoleColor.Red; break;
					case TraceLevel.Warning:
						Console.ForegroundColor = ConsoleColor.Blue; break;
					default:
						Console.ForegroundColor = ConsoleColor.Yellow; break;
				}

				Console.WriteLine($"{DateTime.Now}: {e.Value2} : {e.Value1} : {e.Value3?.Message}");
			}
			finally
			{
				Console.ForegroundColor = oldColor;
			}
		}
	}
}