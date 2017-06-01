using System;
using System.Collections.Generic;
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
	}
}