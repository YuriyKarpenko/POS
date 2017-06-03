using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;

using IT;
using POS.Data.Model;

namespace POS.Client.ViewModel
{
	public abstract class VM_Dic_Base<T> : VM_Workspace, IVM_Editable where T : class, new()
	{
		internal Tables curDic;

		protected Service.Service1 svc = new Service.Service1Client();

		protected ObservableCollection<T> _items = null;
		public ObservableCollection<T> Items
		{
			get
			{
				if (this._items == null)
				{
					this._items = new ObservableCollection<T>();
				}

				this.Load();

				return this._items;
			}
		}

		public virtual T SelectedItem { get; set; }

		protected VM_Dic_Base(VM_Workspace parent, string caption, Tables curTable) : base(parent, caption)
		{
			curDic = curTable;
		}

		public virtual void Load()
		{
			this.Debug("()");
			try
			{
				itemsClear();
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

		public virtual void Add(T item)
		{
			var str = Serializer_Json.Serialize_ToString(item);
			var res = svc.Insert(curDic, str);
			Contract.Requires(res == 1, $"Проблемы при вставке записи {item}");
		}

		public virtual void Edit(T item)
		{
			var str = Serializer_Json.Serialize_ToString(item);
			var res = svc.Update(curDic, str);
			Contract.Requires(res == 1, $"Проблемы при редактировании записи {item}");
		}

		public virtual void Delete(T item)
		{
			var str = Serializer_Json.Serialize_ToString(item);
			var res = svc.Delete(curDic, str);
			Contract.Requires(res == 1, $"Проблемы при удалении записи {item}");
		}

		protected virtual T newItem()
		{
			return new T();
		}

		protected virtual void itemsClear()
		{
			this._items.Clear();
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

					this.Load();

					//this.Cmd = modifieCmd.Add;
				}
			}
		}

		public virtual void OnDelete_Click(object sender, RoutedEventArgs e)
		{
			if (SelectedItem != null)
			{
				this.Delete(SelectedItem);

				this.Load();
			}
		}

		public virtual void OnEdit_Click(object sender, RoutedEventArgs e)
		{
			if (SelectedItem != null)
			{
				Win_Modal w = new Win_Modal();

				if (w != null)
				{
					w.DataContext = SelectedItem;

					bool? res = w.ShowDialog();

					if (res == true)
					{
						this.Edit(SelectedItem);

						this.Load();
						//Cmd = modifieCmd.Edit;
					}
				}
			}
		}

		public virtual void OnOk_Click(object sender, RoutedEventArgs e)
		{
			//this.svc.Save();

			Load();
			//Cmd = modifieCmd.None; 
		}
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
