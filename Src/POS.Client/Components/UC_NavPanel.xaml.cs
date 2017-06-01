using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS.Client.Components
{
	//public class SelectedItem : DependencyObject

	/// <summary>
	/// Interaction logic for UC_NavPanel.xaml
	/// </summary>
	public partial class UC_NavPanel : UserControl
	{
		public const string
			sbtnAdd = "btnAdd",
			sbtnDel = "btnDel",
			sbtnEdit = "btnEdit",
			sbtnOk = "btnOk";

		#region Dependency Property
		
		//	Registred new DependencyProperty as SelectedItemProperty
		public readonly static DependencyProperty SelectedItemProperty = DependencyProperty.Register(
			"SelectedItem", typeof(object), typeof(UC_NavPanel)
			, (PropertyMetadata) new FrameworkPropertyMetadata((object)null
				//, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault
				, new PropertyChangedCallback(onSelectedItemChanged)
			)
			//, new ValidateValueCallback()
			);
		static void onSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as UC_NavPanel).newSelectedItem(e.NewValue);
		}

		public object SelectedItem
		{
			get { return GetValue(SelectedItemProperty); }
			set { newSelectedItem(value); SetValue(SelectedItemProperty, value); }
		}

		#endregion

		public UC_NavPanel()
		{
			InitializeComponent();
			init();
		}

		void init() { }

		void newSelectedItem(object dc)
		{ 
			btnDel.IsEnabled = btnEdit.IsEnabled = dc != null;
		}

		#region Buttons events
		
		public event RoutedEventHandler 
			OnOk,
			OnAdd,
			OnEdit,
			OnDelete;

		//public ICommand cmdOk { get; set; }

		private void ButtonOk_Click(object sender, RoutedEventArgs e)
		{
			if (OnOk != null) OnOk(this, new RoutedEventArgs());
		}

		private void ButtonAdd_Click(object sender, RoutedEventArgs e)
		{
			if (OnAdd != null) OnAdd(this, new RoutedEventArgs());
		}

		private void ButtonEdit_Click(object sender, RoutedEventArgs e)
		{
			if (OnEdit != null) OnEdit(this, new RoutedEventArgs());
		}

		private void ButtonDel_Click(object sender, RoutedEventArgs e)
		{
			if (OnDelete != null) OnDelete(this, new RoutedEventArgs());
		}

		#endregion
	}
}
