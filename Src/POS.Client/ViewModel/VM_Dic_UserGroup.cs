using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using CoderOD.DB35.Common;

namespace POS.Client.ViewModel
{
	internal class VM_Dic_UserGroup :VM_Dic_Base<POS.Data.Model.UserGroup>
	{
		public VM_Dic_UserGroup(VM_Workspace parent)
			: base(parent, "Группы пользователей")
		{
			curDic = Dics.UserGroup;
		}

		public override void Load()
		{
			this.itemsClear();

			foreach (var item in this.svc.UserGroupGet(null))
			{
				this._items.Add(item);
			}
		}

		public override void Delete(POS.Data.Model.UserGroup item){this.svc.UserGroupDel(item);}

		public override void Add(POS.Data.Model.UserGroup item){ this.svc.UserGroupIns(item);}

		public override void Edit(POS.Data.Model.UserGroup item){this.svc.UserGroupUpd(item);}
	}
}
