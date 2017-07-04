using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Newtonsoft.Json;

using IT;
using IT.WPF;
using V = POS.Client.V;
using POS.Data.Model;

namespace POS.Client.VM
{
	public abstract class VM_Dic_Base<T> : VM_Workspace where T : class, IPersistedModel, new()
	{
		internal Tables curDic;

		public SelectorPropertyWPF<T> Items { get; private set; }

		protected VM_Dic_Base(VM_Workspace parent, string caption, Tables curTable) : base(parent, caption)
		{
			curDic = curTable;

			InitData();
		}


		private void InitData()
		{
			Items = new SelectorPropertyWPF<T>(LoadAsync);
		}

		protected virtual void LoadAsync(ObservableCollection<T> _items)
		{
			this.Debug("()");
			try
			{
				var where = new Dictionary<string, object>();
				//where.Add("Id", 1);
				var str = ServiceClient.Instance.Dictionary_Get(curDic, where);
				if (!string.IsNullOrEmpty(str))
				{
					var coll = JsonConvert.DeserializeObject<IEnumerable<T>>(str);
					_items.AddRange(coll);
				}
			}
			catch (Exception ex)
			{
				this.Error(ex, "()");
				//throw;
			}
		}

		protected virtual int ApplyAction(DataAction act, T item)
		{
			//this.Debug("()");
			try
			{
				var res = ServiceClient.Instance.Dictionary_Set(curDic, act, item);
				Contract.Requires(res == 1, $"Проблемы при '{act}' записи '{item}'");
				return res;
			}
			catch (Exception ex)
			{
				this.Error(ex, $"({curDic}, {act}, {item})");
				//throw;
			}
			return 0;
		}

		protected virtual T newItem()
		{
			return new T();
		}

		#region actions

		protected override void Init_Command_Internal(UserControl uc)
		{
			base.Init_Command_Internal(uc);

			uc.CommandBindings.Add(V.Commands.Nav_Delete, ActDelete, CanSelected);
			uc.CommandBindings.Add(V.Commands.Nav_Insert, ActAdd);
			uc.CommandBindings.Add(V.Commands.Nav_Refresh, ActRefresh);
			uc.CommandBindings.Add(V.Commands.Nav_Edit, ActEdit, CanSelected);
		}

		protected virtual void CanSelected(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = Items.HasSelected;
		}

		public virtual void ActAdd(object sender, ExecutedRoutedEventArgs e)
		{
			var item = this.newItem();

			if (VM_Dialog.Show<UC.UC_EditItem>($"Добавление {curDic}", new { Value = item }))
			{
				ApplyAction(DataAction.Insert, item);

				this.Items.Reset();
			}
		}

		public virtual void ActDelete(object sender, ExecutedRoutedEventArgs e)
		{
			if (Items.HasSelected)
			{
				ApplyAction(DataAction.Delete, Items.SelectedItem);

				Items.Reset();
			}
		}

		public virtual void ActEdit(object sender, ExecutedRoutedEventArgs e)
		{
			if (Items.HasSelected)
			{
				//var vm = new CM_Property_Value(Items.SelectedItem) { IsEditMode = true };
				if (VM_Dialog.Show<UC.UC_EditItem>($"Редактирование {curDic}", new { Value = Items.SelectedItem }))
				{
					ApplyAction(DataAction.Update, Items.SelectedItem);

					Items.Reset();
				}
			}
		}

		public virtual void ActRefresh(object sender, ExecutedRoutedEventArgs e)
		{
			Items.Reset();
		}

		#endregion
	}

	#region real dictionaries

	public class VM_Dic_Division : VM_Dic_Base<Division>
	{
		public VM_Dic_Division(VM_Workspace parent) : base(parent, "Цех", Tables.Division) { }
	}

	internal class VM_Dic_UserGroup : VM_Dic_Base<UserGroup>
	{
		public VM_Dic_UserGroup(VM_Workspace parent) : base(parent, "Группы пользователей", Tables.UserGroup) { }
	}


	#endregion
}
