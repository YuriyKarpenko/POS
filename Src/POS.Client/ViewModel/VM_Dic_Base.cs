using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;

//using CoderOD.DB35.Common;
namespace POS.Client.ViewModel
{
	internal enum Dics { None, UserGroup, User }
	public enum modifieCmd { None, Add, Delete, Edit, Ok }

	public abstract class VM_Dic_Base<T> : VM_Workspace, IVM_Editable where T : class, new()
	{
		//modifieCmd _cmd = modifieCmd.None;
		//public modifieCmd Cmd
		//{
		//    get { return _cmd; }
		//    set
		//    {
		//        if (_cmd != value) ;
		//        {
		//            _cmd = value;

		//            OnPropertyChanged("Cmd");

		//            this.IsModifed = _cmd != modifieCmd.None;
		//        }
		//    }
		//}

		VM_Workspace parentWorkSpace = null;
		internal Dics curDic = Dics.None;
		//public CoderOD.DB35.ChangeTrackingCollection<POS.Data.DTO.UserGroup> Items { get; protected set; }
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

		protected VM_Dic_Base(VM_Workspace parent, string caption) 
		{
			this.parentWorkSpace = parent;

			this.Caption = caption;

			//this.Cmd = modifieCmd.None;
		}

		public abstract void Load();
		public abstract void Add(T item);
		public abstract void Edit(T item);
		public abstract void Delete(T item);
		//public abstract void Save();

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
}
