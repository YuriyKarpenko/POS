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
	public class VM_Main : VM_Workspace_Collection
	{
		protected override List<VM_Command> CreateCommands()
		{
			return new List<VM_Command>
            {
                new VM_Command(
                    Strings.VM_Main_Command_Dics,
                    new RelayCommand(param => this.cmdDics())),

                new VM_Command(
                    Strings.VM_Dic_Command_Dic_User,
                    new RelayCommand(param => this.ShowAllCustomers())),

                new VM_Command(
                    Strings.VM_Dic_Command_Dic_UserGroup,
                    new RelayCommand(param => this.cmdDics()))
            };
		}

		void cmdDics()
		{
			//POS.Data.DTO.UserGroup newUserGroup = new Data.DTO.UserGroup();
			VM_Dictionary workspace = new VM_Dictionary();
			this.Workspaces.Add(workspace);
			this.SetActiveWorkspace(workspace);
		}

		void ShowAllCustomers()
		{
			/*AllCustomersViewModel workspace =
				this.Workspaces.FirstOrDefault(vm => vm is AllCustomersViewModel)
				as AllCustomersViewModel;

			if (workspace == null)
			{
				workspace = new AllCustomersViewModel(_customerRepository);
				this.Workspaces.Add(workspace);
			}

			this.SetActiveWorkspace(workspace);*/
		}

	}
}
