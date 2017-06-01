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
	public partial class V_Edit_List : UserControl
	{
		public V_Edit_List()
		{
			InitializeComponent();
		}

		IVM_Editable vm
		{
			get
			{
				if (this.DataContext is IVM_Editable) return this.DataContext as IVM_Editable;
				return null;
			}
		}

		private void On_Click(object sender, RoutedEventArgs e)
		{
			switch ((e.OriginalSource as FrameworkElement).Name)
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

		private void DockPanel_Selected(object sender, SelectionChangedEventArgs e)
		{
			navPanel.SelectedItem = e.AddedItems.Count > 0 ? e.AddedItems[0] : null;
		}

		private void Listbox_DoubleClick(object sender, MouseButtonEventArgs e)
		{
			vm.OnEdit_Click(sender, e);
		}

	}
}
