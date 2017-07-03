using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace POS.Data.Model
{
	[Serializable]
	public partial class User : PersistedModel
	{
		[Browsable(false)]
#if USE_GUID
		public Guid UserGroupId { get; set; }
#else
		public int UserGroupId { get; set; }
#endif
		public int? Code { get; set; }
		public Role Role { get; set; }

		public PersonInfo PersonInfo { get; set; }

		public UserGroup UserGroup { get; set; }
		//public ICollection<Bill> Bills { get; set; }
		//public ICollection<BillItem> CreatedBillItems { get; set; }
		//public ICollection<BillItem> ModifiedBillItems { get; set; }
		//public ICollection<Price> CreatedPrices { get; set; }
		//public ICollection<Price> ModifiedPrices { get; set; }
		//public ICollection<MenuItem> CreatedMenuItems { get; set; }


		public User()
		{
			Role = Role.None;
		}
	}
}
