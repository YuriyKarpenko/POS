using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Windows;

using IT;
using IT.Log;

namespace POS.Client
{
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			Logger.MinLevel = TraceLevel.Info;
			Logger.MessageSmall += Logger_MessageSmall;

			this.DispatcherUnhandledException += App_DispatcherUnhandledException;
		}

		private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
		{
			Logger.ToLogFmt(this, TraceLevel.Error, e.Exception, $"()");
		}

		private void Logger_MessageSmall(object sender, EventArgs<TraceLevel, string, Exception> e)
		{
			switch (e.Value1)
			{
				case TraceLevel.Error:
					MessageBox.Show(e.Value2 + "\n" + e.Value3?.Message, Ap.AppCaption, MessageBoxButton.OK, MessageBoxImage.Error);
					break;
			}
		}
	}
}
