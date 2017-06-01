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

using POS.Client.Components;
using POS.Client.ViewModel;

namespace POS.Client.View
{
	/// <summary>
	/// Interaction logic for V_Doctionnary.xaml
	/// </summary>
	public partial class V_Dictionary : UserControl
	{
		public V_Dictionary()
		{
			InitializeComponent();
		}

		VM_Dic_Base<object> vm
		{
			get
			{
				if (this.DataContext is VM_Dic_Base<object>) 
				{
					return this.DataContext as VM_Dic_Base<object>;
				}
				return null;
			}
		}

		private void On_Click(object sender, RoutedEventArgs e)
		{
			switch ((e.OriginalSource as ContentControl).Name)
			{
				case UC_NavPanel.sbtnAdd: 
					vm.OnAdd_Click(sender, e);
					break;
				case UC_NavPanel.sbtnDel:
					vm.OnDelete_Click(sender, e);
					break;
				case UC_NavPanel.sbtnEdit:
					vm.OnEdit_Click(sender, e);
					break;
				case UC_NavPanel.sbtnOk:
					vm.OnOk_Click(sender, e);
					break;
			}
		}
	}
}
