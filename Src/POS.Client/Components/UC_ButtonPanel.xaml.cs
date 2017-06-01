using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS.Client.Components
{
	/// <summary>
	/// Логика взаимодействия для UC_ButtonPanel.xaml
	/// </summary>
	public partial class UC_ButtonPanel : UserControl
	{
		public UC_ButtonPanel()
		{
			InitializeComponent();
		}

		private void buttonOk_Click(object sender, RoutedEventArgs e)
		{
			DependencyObject o = this.Parent;

			while (o != null && !(o is Window))
			{
				o = (o as FrameworkElement).Parent;
			}

			if (o != null)
			{
				(o as Window).DialogResult = true;
				(o as Window).Close();
			}
		}
	}
}
