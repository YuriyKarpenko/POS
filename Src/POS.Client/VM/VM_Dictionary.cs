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
using System.Windows.Controls;

using IT;
using IT.WPF;

using V = POS.Client.V;

namespace POS.Client.VM
{
	public class VM_Dictionary : VM_Workspace_Collection
	{
		public VM_Workspace CurrentDic { get; private set; }

		public override string Caption => CurrentDic?.Caption ?? base.Caption;

		public VM_Dictionary(VM_Workspace parent) : base(parent, "Справочники") { }


		#region actions

		public override RoutedUICommand[] Commands
		{
			get
			{
				return new[]
				{
					V.Commands.Dic_Division,

					V.Commands.Dic_MenuGroup,
					V.Commands.Dic_MenuItem,

					V.Commands.Dic_PriceList,
					V.Commands.Dic_Price,

					V.Commands.Dic_UserGroup,
					V.Commands.Dic_User
				};
			}
		}

		protected override void Init_Command_Internal(UserControl uc)
		{
			base.Init_Command_Internal(uc);

			uc.CommandBindings.Add(V.Commands.Dic_Division, ActDivision);

			//uc.CommandBindings.Add(V.Commands.Dic_MenuGroup, ActMenuGroup);
			//uc.CommandBindings.Add(V.Commands.Dic_MenuItem, Act);

			uc.CommandBindings.Add(V.Commands.Dic_PriceList, ActPriceList);
			uc.CommandBindings.Add(V.Commands.Dic_Price, ActPrice);

			uc.CommandBindings.Add(V.Commands.Dic_UserGroup, ActUserGroups);
			uc.CommandBindings.Add(V.Commands.Dic_User, ActUsers);
		}

		void Act_Dic<TViewModel>(Func<VM_Workspace, VM_Workspace> createVm) where TViewModel : VM_Workspace
		{
			this.Debug("()");
			try
			{
				CurrentDic = Workspaces.OfType<TViewModel>()?.FirstOrDefault();

				if (CurrentDic == null)
				{
					CurrentDic = createVm(this);
					this.Workspaces.Add(CurrentDic);
				}

				SetActiveWorkspace(CurrentDic);
			}
			catch (Exception ex)
			{
				this.Error(ex, $"<{typeof(TViewModel).Name}>()");
				throw;
			}
		}

		void ActDivision(RoutedEventArgs e) { Act_Dic<VM_Dic_Division>(i => new VM_Dic_Division(i)); }

		void ActPriceList(RoutedEventArgs e) { Act_Dic<VM_Dic_PriceList>(i => new VM_Dic_PriceList(i)); }
		void ActPrice(RoutedEventArgs e) { Act_Dic<VM_Dic_Price>(i => new VM_Dic_Price(i)); }

		void ActUserGroups(RoutedEventArgs e) { Act_Dic<VM_Dic_UserGroup>(i => new VM_Dic_UserGroup(i)); }
		void ActUsers(RoutedEventArgs e) { Act_Dic<VM_Dic_User>(i => new VM_Dic_User(i)); }

		#endregion

	}
}
