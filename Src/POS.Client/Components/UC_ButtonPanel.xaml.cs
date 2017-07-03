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

using IT.WPF;

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
			InitCmd();
		}

		private void InitCmd()
		{
			this.CommandBindings.Add(V.Commands.Nav_Cancel, e => BtnClick(false));
			this.CommandBindings.Add(V.Commands.Nav_Ok, e => BtnClick(true));
		}

		private void BtnClick(bool isOk)
		{
			var w = this.GetVisualParent<Window>();
			if(w != null)
			{
				w.DialogResult = isOk;
				w?.Close();
			}
		}
	}
}
