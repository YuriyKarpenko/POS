using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Newtonsoft.Json;

using IT;
using IT.WPF;
using V = POS.Client.View;
using POS.Data.Model;

namespace POS.Client.ViewModel
{
	public abstract class VM_Dic_Base<T> : VM_Workspace where T : class, new()
	{
		internal Tables curDic;

		//protected ObservableCollection<T> _items = null;
		//public ObservableCollection<T> Items
		//{
		//	get
		//	{
		//		if (this._items == null)
		//		{
		//			this._items = new ObservableCollection<T>();
		//		}

		//		this.Load();

		//		return this._items;
		//	}
		//}

		//public virtual T SelectedItem { get; set; }
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
				//Items.List.Clear();
				var str = ServiceClient.Instance.Dictionary_Get(curDic);
				var coll = JsonConvert.DeserializeObject<IEnumerable<T>>(str);
				_items.AddRange(coll);
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
			uc.CommandBindings.Add(V.Commands.Nav_Ok, ActOk);
			uc.CommandBindings.Add(V.Commands.Nav_Update, ActEdit, CanSelected);
		}

		protected virtual void CanSelected(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = Items.HasSelected;
		}

		public virtual void ActAdd(object sender, ExecutedRoutedEventArgs e)
		{
			var item = this.newItem();

			Win_Modal w = new Win_Modal();
			if (w.ShowDialog(item, null) == true)
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
				Win_Modal w = new Win_Modal();
				if (w.ShowDialog(Items.SelectedItem, null) == true)
				{
					ApplyAction(DataAction.Update, Items.SelectedItem);

					Items.Reset();
				}
			}
		}

		public virtual void ActOk(object sender, ExecutedRoutedEventArgs e)
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
