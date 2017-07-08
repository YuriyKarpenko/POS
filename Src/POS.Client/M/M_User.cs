using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using POS.Data.Model;

namespace POS.Client.M
{
	class M_User 
	{
		public IEnumerable<UserGroup> UserGroups { get; }

		public M_ValidationWrapper<User> User { get; }
		public M_ValidationWrapper<PersonInfo> PInfo { get; }

		public int UserGroupId
		{
			get { return (int)User.Value[nameof(UserGroupId)]; }
			set { User.Value[nameof(UserGroupId)] = value; }
		}

		public M_User(User user, IEnumerable<UserGroup> uGroups) 
		{
			UserGroups = uGroups;
			User = new M.M_ValidationWrapper<Data.Model.User>(user);
			PInfo = new M.M_ValidationWrapper<PersonInfo>(user.PersonInfo);
		}
	}
}
