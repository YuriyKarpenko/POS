using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows;

namespace POS.Client.ViewModel
{
	public class VM_Dictionary : VM_Workspace_Collection
	{
		#region Propertyes

		/*ObservableCollection<VM_Workspace> _workspaces;
		public ObservableCollection<VM_Workspace> DicWorkspaces
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
		}	//	*/
		
		//VM_Dic_Base _CurrentDic = null;
		//public VM_Dic_Base CurrentDic { get { return _CurrentDic; } }
		public VM_Workspace CurrentDic { get; private set; }

		#endregion

		public override string Caption
		{
			get
			{
				return CurrentDic == null ? base.Caption : CurrentDic.Caption;
			}
			protected set
			{
				base.Caption = value;
			}
		}

		public VM_Dictionary()
		{
			this.Caption = "Справочники";
			//cmdOk = new RelayCommand(p => this.execOk());
			//this.Items = new ChangeTrackingCollection<Data.DTO.UserGroup>();
			//Items = new CoderOD.DB35.ChangeTrackingCollection<CoderOD.DB35.Common.DtoEntityBaseG> { "qqq", "wwwwwww" };
			//Items.CollectionChanged+=new NotifyCollectionChangedEventHandler(Items_CollectionChanged);
		}

		#region cmd

		protected override List<VM_Command> CreateCommands()
		{
			return new List<VM_Command>
            {
                new VM_Command(
                    Strings.VM_Dic_Command_Dic_Division,
                    new RelayCommand(param => this.cmdDivision())),

                new VM_Command(
                    Strings.VM_Dic_Command_Dic_UserGroup,
                    new RelayCommand(param => this.cmdUserGroups())),

                new VM_Command(
                    Strings.VM_Dic_Command_Dic_User,
                    new RelayCommand(param => this.cmdUsers()))
            };
		}

		void cmdDivision()
		{
			CurrentDic =(VM_Dic_Division)Workspaces.FirstOrDefault(item => item.GetType().Name == "VM_Dic_Division");

			if (CurrentDic == null)
			{
				CurrentDic = new VM_Dic_Division(this);
				this.Workspaces.Add(CurrentDic);
			}

			SetActiveWorkspace(CurrentDic);
		}

		void cmdUserGroups()
		{
			CurrentDic =(VM_Dic_UserGroup)Workspaces.FirstOrDefault(item => item.GetType().Name == "VM_Dic_UserGroup");
			if (CurrentDic == null)
			{
				CurrentDic = new VM_Dic_UserGroup(this);
				this.Workspaces.Add(CurrentDic);
			}
			SetActiveWorkspace(CurrentDic);
		}

		void cmdUsers()
		{
			CurrentDic =(VM_Dic_User)Workspaces.FirstOrDefault(item => item.GetType().Name == "VM_Dic_User");

			if (CurrentDic == null)
			{
				CurrentDic = new VM_Dic_User(this);
				this.Workspaces.Add(CurrentDic);
			}

			SetActiveWorkspace(CurrentDic);
		}

		#endregion

	}
}
