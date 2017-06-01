using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace POS.Client.ViewModel
{
	public class VM_UserGroupEdit : VM_Workspace
	{
		//POS.Data.Repositorys.RepUserGroup repUserGroup = null;
		POS.Data.Model.UserGroup curentRecord = null;

		public VM_UserGroupEdit(POS.Data.Model.UserGroup rec)
		{
			//this.repUserGroup = repos;
		}
	}
}
