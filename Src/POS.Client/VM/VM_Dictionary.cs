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
					V.Commands.Dic_UserGroup,
					V.Commands.Dic_User
				};
			}
		}

		protected override void Init_Command_Internal(UserControl uc)
		{
			base.Init_Command_Internal(uc);

			uc.CommandBindings.Add(V.Commands.Dic_Division, ActDivision);
			uc.CommandBindings.Add(V.Commands.Dic_User, ActUsers);
			uc.CommandBindings.Add(V.Commands.Dic_UserGroup, ActUserGroups);
		}

		void ActDivision(RoutedEventArgs e)
		{
			//this.Debug("()");
			try
			{
				CurrentDic = Workspaces.OfType<VM_Dic_Division>()?.FirstOrDefault();

				if (CurrentDic == null)
				{
					CurrentDic = new VM_Dic_Division(this);
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

		void ActUserGroups(RoutedEventArgs e)
		{
			//this.Debug("()");
			try
			{
				CurrentDic = Workspaces.OfType<VM_Dic_UserGroup>()?.FirstOrDefault();
				if (CurrentDic == null)
				{
					CurrentDic = new VM_Dic_UserGroup(this);
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

		void ActUsers(RoutedEventArgs e)
		{
			//this.Debug("()");
			try
			{
				CurrentDic = Workspaces.OfType<VM_Dic_User>()?.FirstOrDefault();

				if (CurrentDic == null)
				{
					CurrentDic = new VM_Dic_User(this);
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

		#endregion

	}
}
