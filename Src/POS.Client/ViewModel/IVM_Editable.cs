using System;
namespace POS.Client.ViewModel
{
	interface IVM_Editable
	{
		void OnAdd_Click(object sender, System.Windows.RoutedEventArgs e);
		void OnDelete_Click(object sender, System.Windows.RoutedEventArgs e);
		void OnEdit_Click(object sender, System.Windows.RoutedEventArgs e);
		void OnOk_Click(object sender, System.Windows.RoutedEventArgs e);
	}
}
