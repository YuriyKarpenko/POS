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

namespace POS.Client.ViewModel
{
	public abstract class VM_Workspace_Collection : VM_Workspace
	{
		#region Fields

		ObservableCollection<VM_Workspace> _workspaces;
		public ObservableCollection<VM_Workspace> Workspaces
		{
			get
			{
				if (_workspaces == null)
				{
					_workspaces = new ObservableCollection<VM_Workspace>();
					_workspaces.CollectionChanged += this.OnWorkspacesChanged;
				}
				return _workspaces;
			}
		}

		ReadOnlyCollection<VM_Command> _commands;
		public ReadOnlyCollection<VM_Command> Commands
		{
			get
			{
				if (_commands == null)
				{
					List<VM_Command> cmds = this.CreateCommands();
					_commands = new ReadOnlyCollection<VM_Command>(cmds);
				}
				return _commands;
			}
		}

		#endregion

		#region Commadns

		protected abstract List<VM_Command> CreateCommands();

		#endregion

		#region Workspaces

		protected virtual void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.NewItems != null && e.NewItems.Count != 0)
				foreach (VM_Workspace workspace in e.NewItems)
					workspace.RequestClose += this.OnWorkspaceRequestClose;

			if (e.OldItems != null && e.OldItems.Count != 0)
				foreach (VM_Workspace workspace in e.OldItems)
					workspace.RequestClose -= this.OnWorkspaceRequestClose;
		}

		protected virtual void OnWorkspaceRequestClose(object sender, EventArgs e)
		{
			this.Workspaces.Remove(sender as VM_Workspace);
		}

		#endregion

		#region Private Helpers

		protected virtual void SetActiveWorkspace(VM_Workspace workspace)
		{
			Debug.Assert(this.Workspaces.Contains(workspace));

			ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
			if (collectionView != null)
				collectionView.MoveCurrentTo(workspace);
		}

		#endregion // Private Helpers

	}
}
