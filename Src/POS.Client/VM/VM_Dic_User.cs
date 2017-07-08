using System.Windows.Input;

using POS.Data.Model;

namespace POS.Client.VM
{
	public class VM_Dic_User : VM_Dic_Base<Data.Model.User>
	{
		UserGroup[] userGroups;
		public UserGroup[] UserGroups => userGroups ?? (userGroups = ServiceClient.Instance.Dictionary_Get<UserGroup>(Data.Model.Tables.UserGroup, null));

		public VM_Dic_User(VM_Workspace parent) : base(parent, "Пользователи", Data.Model.Tables.User) { }

		public override void ActAdd(object sender, ExecutedRoutedEventArgs e)
		{
			var item = newItem();
			if (VM_Dialog.Show<UC.UC_Edit_User>($"Редактирование {curDic}", new M.M_User(item, UserGroups)))
			{
				ApplyAction(Data.Model.DataAction.Insert, item);
				Items.Reset();
			}
		}

		public override void ActEdit(object sender, ExecutedRoutedEventArgs e)
		{
			if (Items.HasSelected)
			{
				if (VM_Dialog.Show<UC.UC_Edit_User>($"Редактирование {curDic}", new M.M_User(Items.SelectedItem, UserGroups)))
				{
					ApplyAction(Data.Model.DataAction.Update, Items.SelectedItem);
					Items.Reset();
				}
			}
		}
	}
}
