using System;
using System.Windows;
using System.Windows.Controls;

using IT;

namespace POS.Client.ViewModel
{
	public abstract class VM_Base : NotifyPropertyChangedBase, ILog
	{
		#region static

		static VM_Base()
		{
			try
			{
				var md = new FrameworkPropertyMetadata(PropertyChangedCallback);
				FrameworkElement.DataContextProperty.OverrideMetadata(typeof(ContentControl), md);
			}
			catch (Exception ex)
			{
				//Microsoft.Extensions.Logging.ILogger
				throw;
			}
		}

		static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var vm = e.NewValue as VM_Base;
			if (vm != null)
				vm.Init_Command(d as FrameworkElement);
		}

		#endregion

		protected Window CurrentWindow { get; private set; }
		protected UserControl CurrentUC { get; private set; }

		#region init command

		protected virtual void Init_Command_Internal(Window w)
		{
			this.CurrentWindow = this.CurrentWindow ?? w;
		}

		protected virtual void Init_Command_Internal(UserControl uc)
		{
			this.CurrentUC = this.CurrentUC ?? uc;
		}

		protected virtual void Init_Command_Internal(FrameworkElement fe) { }

		void Init_Command(FrameworkElement e)
		{
			this.Trace("()");
			try
			{
				if (e is Window && CurrentWindow != e)
					this.Init_Command_Internal(e as Window);
				else if (e is UserControl && CurrentUC != e)
					this.Init_Command_Internal(e as UserControl);
				else
					this.Init_Command_Internal(e);

			}
			catch (Exception ex)
			{
				this.Error(ex, "()");
			}
		}

		#endregion

	}
}
