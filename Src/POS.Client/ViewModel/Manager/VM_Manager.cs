using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using IT;
using IT.WPF;
using V = POS.Client.View;

namespace POS.Client.ViewModel.Manager
{
	class VM_Manager : VM_Workspace_Collection
	{
		public override RoutedUICommand[] Commands
		{
			get
			{
				return new[]
				{
					V.Commands.Dic,
					V.Commands.Dic_UserGroup,
					V.Commands.Dic_User
				};
			}
		}

		public VM_Manager(VM_Workspace parent) : base(parent, "") { }


		protected override void Init_Command_Internal(UserControl uc)
		{
			base.Init_Command_Internal(uc);

			uc.CommandBindings.Add(V.Commands.Dic, ActDicstionaries);
		}

		void ActDicstionaries(RoutedEventArgs e)
		{
			//this.Debug("()");
			try
			{
				var CurrentDic = Workspaces.OfType<VM_Dictionary>()?.FirstOrDefault();
				if (CurrentDic == null)
				{
					CurrentDic = new VM_Dictionary(this);
					this.Workspaces.Add(CurrentDic);
				}
				SetActiveWorkspace(CurrentDic);
			}
			catch (Exception ex)
			{
				this.Error(ex, "()");
				throw;
			}
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
