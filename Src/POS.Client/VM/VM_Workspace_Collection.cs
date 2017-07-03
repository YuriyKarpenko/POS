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
using System.Windows.Controls;

using IT;
using IT.WPF;

namespace POS.Client.VM
{
	//	работа с коллекциями окон (UserControls)
	public abstract class VM_Workspace_Collection : VM_Workspace
	{
		public Guid ID = Guid.NewGuid();
		#region Fields

		ObservableCollection<VM_Workspace> _workspaces;
		public ObservableCollection<VM_Workspace> Workspaces
		{
			get
			{
				if (_workspaces == null)
				{
					_workspaces = new ObservableCollection<VM_Workspace>();
					//_workspaces.CollectionChanged += this.OnWorkspacesChanged;
				}
				return _workspaces;
			}
		}

		public abstract RoutedUICommand[] Commands { get; }

		#endregion

		public VM_Workspace_Collection(VM_Workspace parent, string caption) : base(parent, caption) { }


		#region Workspaces

		//protected virtual void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
		//{
		//	if (e.NewItems != null && e.NewItems.Count != 0)
		//		foreach (VM_Workspace workspace in e.NewItems)
		//			workspace.RequestClose += this.OnWorkspaceRequestClose;

		//	if (e.OldItems != null && e.OldItems.Count != 0)
		//		foreach (VM_Workspace workspace in e.OldItems)
		//			workspace.RequestClose -= this.OnWorkspaceRequestClose;
		//}

		//protected virtual void OnWorkspaceRequestClose(object sender, EventArgs e)
		//{
		//	this.Workspaces.Remove(sender as VM_Workspace);
		//}
		protected override void Init_Command_Internal(UserControl uc)
		{
			base.Init_Command_Internal(uc);

			uc.CommandBindings.Add(V.Commands.CloseItem, ActCloseUserControl);
		}

		protected virtual void ActCloseUserControl(ExecutedRoutedEventArgs e)
		{
			var ws = e.Parameter as VM_Workspace;
			e.Handled = ws != null && Workspaces.Contains(ws);
			this.Workspaces.Remove(ws);
		}

		#endregion


		protected virtual void SetActiveWorkspace(VM_Workspace workspace)
		{
			Debug.Assert(this.Workspaces.Contains(workspace));

			ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
			if (collectionView != null)
				collectionView.MoveCurrentTo(workspace);
		}

	}
}
