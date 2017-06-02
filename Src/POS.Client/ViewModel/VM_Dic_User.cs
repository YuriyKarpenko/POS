using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

//using CoderOD.DB35.Common;

namespace POS.Client.ViewModel
{
	public class VM_Dic_User:VM_Dic_Base<POS.Data.Model.User>
	{
		public VM_Dic_User(VM_Workspace parent)	: base(parent, "Пользователи")
		{	curDic = Dics.User;	}

		public override void Load()
		{
			this.itemsClear();
			//foreach(var item in rep.List)
			//this._items.Add(this.svc.UserGroupGet(null));
		}

		public override void Add(POS.Data.Model.User item)
		{
			//rep.Insert(()item);
		}

		public override void Edit(POS.Data.Model.User item)
		{
			//rep.Update((POS.Data.Model.User)item);
		}

		public override void Delete(POS.Data.Model.User item)
		{
			//rep.Delete(id);
		}

		public override void OnEdit_Click(object sender, RoutedEventArgs e)
		{
			if (SelectedItem == null) return;

			var item = SelectedItem;
			Win_Modal w = new Win_Modal();

			//	Необходимо, чтобы [UserGroup] принадлежал коллекции [UserGroups]
			//(item as Data.Types.User).UserGroup = (item as Data.Types.User).UserGroup
			//    .Where(x => x.Id == (item as Data.Types.User).UserGroup.Id).Single();

			w.DataContext = item;
			if (w == null || item == null) return;
			bool? res = w.ShowDialog();
			if (res == true)
			{
				Edit(item);
				Load();
				//Cmd = modifieCmd.Edit;
			}
		}

		public class UserFacade : Data.Model.User
		{
			public List_Current_Helper<Data.Model.UserGroup> Helper { get; protected set; }
			public UserFacade(Data.Model.User user)
			{
				this.CreatedBillItems = user.CreatedBillItems;
				this.ModifiedBillItems = user.ModifiedBillItems;
				this.Bills = user.Bills;
				this.Card = user.Card;
				this.Checks = user.Checks;
				this.Code = user.Code;
				this.Hidden = user.Hidden;
				this.Id = user.Id;
				this.CreatedMenuItems = user.CreatedMenuItems;
				this.Name = user.Name;
				this.SexMale = user.SexMale;
				//this.TrackingState = user.TrackingState;
				this.UserGroup = user.UserGroup;
				this.UserGroupId = user.UserGroupId;
				//this.UserGroups = user.UserGroups;
				//Helper = new List_Current_Helper<Data.Types.UserGroup>(user.UserGroup, user.UserGroup);
			}
		}

	}
}
