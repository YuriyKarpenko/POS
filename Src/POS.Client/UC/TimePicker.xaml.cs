﻿using System;
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

namespace POS.Client.UC
{
	/// <summary>
	/// Interaction logic for TimePicker.xaml
	/// </summary>
	public partial class TimePicker : UserControl
	{

		public TimePicker()
		{
			InitializeComponent();
		}

		#region Value

		public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(TimeSpan), typeof(TimePicker),
			new UIPropertyMetadata(DateTime.Now.TimeOfDay, new PropertyChangedCallback(OnValueChanged)));

		private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
		{
			TimePicker control = obj as TimePicker;
			control.Hours = ((TimeSpan)e.NewValue).Hours;
			control.Minutes = ((TimeSpan)e.NewValue).Minutes;
			control.Seconds = ((TimeSpan)e.NewValue).Seconds;
		}

		public TimeSpan Value
		{
			get { return (TimeSpan)GetValue(ValueProperty); }
			set { SetValue(ValueProperty, value); }
		}

		#endregion

		#region Hours

		public int Hours
		{
			get { return (int)GetValue(HoursProperty); }
			set { SetValue(HoursProperty, value); }
		}

		public static readonly DependencyProperty HoursProperty = DependencyProperty.Register("Hours", typeof(int), typeof(TimePicker),
			new UIPropertyMetadata(0, new PropertyChangedCallback(OnTimeChanged)));

		#endregion

		#region Minutes

		public int Minutes
		{
			get { return (int)GetValue(MinutesProperty); }
			set { SetValue(MinutesProperty, value); }
		}

		public static readonly DependencyProperty MinutesProperty = DependencyProperty.Register("Minutes", typeof(int), typeof(TimePicker),
			new UIPropertyMetadata(0, new PropertyChangedCallback(OnTimeChanged)));

		#endregion

		#region MyRegion


		public int Seconds
		{
			get { return (int)GetValue(SecondsProperty); }
			set { SetValue(SecondsProperty, value); }
		}

		public static readonly DependencyProperty SecondsProperty = DependencyProperty.Register("Seconds", typeof(int), typeof(TimePicker), 
			new UIPropertyMetadata(0, new PropertyChangedCallback(OnTimeChanged)));

		#endregion



		private static void OnTimeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
		{
			TimePicker control = obj as TimePicker;
			control.Value = new TimeSpan(control.Hours, control.Minutes, control.Seconds);
		}

		private void Down(object sender, KeyEventArgs args)
		{
			switch (((Grid)sender).Name)
			{
				case "sec":
					if (args.Key == Key.Up)
						this.Seconds++;
					if (args.Key == Key.Down)
						this.Seconds--;
					break;

				case "min":
					if (args.Key == Key.Up)
						this.Minutes++;
					if (args.Key == Key.Down)
						this.Minutes--;
					break;

				case "hour":
					if (args.Key == Key.Up)
						this.Hours++;
					if (args.Key == Key.Down)
						this.Hours--;
					break;
			}
		}
	}
}
