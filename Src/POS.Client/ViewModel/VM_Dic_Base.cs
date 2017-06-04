using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using IT;
using IT.WPF;
using V = POS.Client.View;
using POS.Data.Model;

namespace POS.Client.ViewModel
{
	public abstract class VM_Dic_Base<T> : VM_Workspace, IVM_Editable where T : class, new()
	{
		internal Tables curDic;

		protected Service.Service1 svc = new Service.Service1Client();

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
				var str = svc.Sel_ById(curDic, null, IdColumn.Id);
				var coll = Serializer_Json.Deserialize<IEnumerable<T>>(str);
				_items.AddRange(coll);
			}
			catch (Exception ex)
			{
				this.Error(ex, "()");
				throw;
			}
		}

		protected virtual void Add(T item)
		{
			var res = ApplyAction(DataAction.Insert, item);
			Contract.Requires(res == 1, $"Проблемы при вставке записи {item}");
		}

		protected virtual void Edit(T item)
		{
			var res = ApplyAction(DataAction.Update, item);
			Contract.Requires(res == 1, $"Проблемы при редактировании записи {item}");
		}

		protected virtual void Delete(T item)
		{
			var res = ApplyAction(DataAction.Delete, item);
			Contract.Requires(res == 1, $"Проблемы при удалении записи {item}");
		}

		protected virtual int ApplyAction(DataAction act, T item)
		{
			//this.Debug("()");
			try
			{
				var str = Serializer_Json.Serialize_ToString(item);
				var res = svc.ApplyAction(curDic, act, str);
				return res;
			}
			catch (Exception ex)
			{
				this.Error(ex, $"({act}, {item})");
				throw;
			}
		}

		protected virtual T newItem()
		{
			return new T();
		}

		#region actions

		protected override void Init_Command_Internal(UserControl uc)
		{
			base.Init_Command_Internal(uc);

			uc.CommandBindings.Add(V.Commands.Nav_Delete, OnDelete_Click, CanSelected);
			uc.CommandBindings.Add(V.Commands.Nav_Insert, OnAdd_Click);
			uc.CommandBindings.Add(V.Commands.Nav_Ok, OnOk_Click);
			uc.CommandBindings.Add(V.Commands.Nav_Update, OnEdit_Click, CanSelected);
		}

		protected virtual void CanSelected(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = Items.HasSelected;
		}

		public virtual void OnAdd_Click(object sender, RoutedEventArgs e)
		{
			var item = this.newItem();

			Win_Modal w = new Win_Modal();

			if (w != null)
			{
				w.DataContext = item;

				bool? res = w.ShowDialog();

				if (res == true)
				{
					this.Add(item);

					this.Items.Reset();

					//this.Cmd = modifieCmd.Add;
				}
			}
		}

		public virtual void OnDelete_Click(object sender, RoutedEventArgs e)
		{
			if (Items.SelectedItem != null)
			{
				this.Delete(Items.SelectedItem);

				Items.Reset();
			}
		}

		public virtual void OnEdit_Click(object sender, RoutedEventArgs e)
		{
			if (Items.HasSelected)
			{
				Win_Modal w = new Win_Modal();

				if (w != null)
				{
					w.DataContext = Items.SelectedItem;

					bool? res = w.ShowDialog();

					if (res == true)
					{
						this.Edit(Items.SelectedItem);

						Items.Reset();
						//Cmd = modifieCmd.Edit;
					}
				}
			}
		}

		public virtual void OnOk_Click(object sender, RoutedEventArgs e)
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
