using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace POS.Data.Service
{
	public class Log
	{
		private static string GetFileName()
		{
			var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");

			if (!Directory.Exists(fileName))
			{
				Directory.CreateDirectory(fileName);
			}

			return Path.Combine(fileName, DateTime.Today.ToString("yyyy_MM_dd")+".log");
		}

		public static void ToLog(bool isError, string formatString, params object[] args)
		{
			StringBuilder sb = new StringBuilder("\r\n\r\n" + DateTime.Now.ToLongTimeString());

			if(isError)
			{
				sb.Append("\tError : ");
			}

			sb.Append("\t" + string.Format(formatString, args).Replace("\r\n", "\t\r\n"));

			File.AppendAllText(Log.GetFileName(), sb.ToString());
		}

		public static void ToLog(string formatString, params object[] args)
		{
			Log.ToLog(false, formatString, args);
		}
	}
}