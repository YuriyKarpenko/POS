using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;

namespace POS.Client.V
{
	class Cmd2Image : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var cmd = value as RoutedCommand;
			if (cmd != null)
			{
				switch (cmd.Name)
				{
					case nameof(Commands.Nav_Cancel):
					case nameof(Commands.Nav_Delete):
						return App.Current.FindResource("img_Cancel");
					case nameof(Commands.Nav_Ok):
						return App.Current.FindResource("img_Ok");
					case nameof(ApplicationCommands.Save):
					case nameof(Commands.Nav_Save):
						return App.Current.FindResource("img_Save");
					case nameof(Commands.Nav_Insert):
						return App.Current.FindResource("img_Plus");
					case nameof(Commands.Nav_Refresh):
						return App.Current.FindResource("img_Refresh");
					case nameof(Commands.Nav_Edit):
						return App.Current.FindResource("img_Edit");
				}
			}
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
