using System;
//using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace POS.Data.Model
{
	/// <summary>
	/// Пользователи
	/// </summary>
	[Serializable]
	public partial class User : PersistedModel
	{
		[Browsable(false)]
		[Required]
#if USE_GUID
		public Guid UserGroupId { get; set; }
#else
		public int UserGroupId { get; set; }
#endif

		[Display(Name = "", Order = 10), Editable(true)]
		public int? Code { get; set; }

		//[EnumDataType(typeof(Role))]
		[Display(Name = "", Order = 10), Editable(true)]
		public Role Role { get; set; }

		[Display(Name = "", Order = 10), Editable(false)]
		public PersonInfo PersonInfo { get; set; }

		[Browsable(false)]
		public virtual UserGroup UserGroup { get; set; }
		//public virtual ICollection<Bill> Bills { get; set; }
		//public virtual ICollection<BillItem> CreatedBillItems { get; set; }
		//public virtual ICollection<BillItem> ModifiedBillItems { get; set; }
		//public virtual ICollection<Price> CreatedPrices { get; set; }
		//public virtual ICollection<Price> ModifiedPrices { get; set; }
		//public virtual ICollection<MenuItem> CreatedMenuItems { get; set; }


		public User()
		{
			Role = Role.None;
			PersonInfo = new Model.PersonInfo();
		}
	}
}
