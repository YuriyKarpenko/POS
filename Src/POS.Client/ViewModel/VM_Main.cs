using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Data;
using System.Windows.Input;

using IT;
using IT.WPF;

using V = POS.Client.View;
using System.Windows;

namespace POS.Client.ViewModel
{
	public class VM_Main : VM_Workspace
	{
		private MemCache<string, VM_Workspace> workspaces = new MemCache<string, VM_Workspace>();


		public VM_Workspace Content { get; private set; }

		public VM_Main() : base(null, "") { }


		#region actions

		protected override void Init_Command_Internal(Window w)
		{
			base.Init_Command_Internal(w);

			w.CommandBindings.Add(V.Commands.Main_Manager, ActManager);
		}


		private void ActOptions(ExecutedRoutedEventArgs e)
		{
			//this.Debug("()");
			try
			{
			}
			catch (Exception ex)
			{
				this.Error(ex, "()");
				throw;
			}
		}

		private void ActManager(ExecutedRoutedEventArgs e)
		{
			//this.Debug("()");
			try
			{
				SetContent(workspaces[nameof(Manager.VM_Manager), ()=>new Manager.VM_Manager(this)]);
			}
			catch (Exception ex)
			{
				this.Error(ex, "()");
				throw;
			}
		}

		#endregion

		private void SetContent(VM_Workspace content)
		{
			Content = content;
			OnPropertyChanged(nameof(Content));
		}

	}
}
