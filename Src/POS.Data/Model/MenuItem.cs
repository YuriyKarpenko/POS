using System;
using System.Collections.Generic;

namespace POS.Data.Model
{
	public partial class MenuItem : DictionaryModel
	{
#if USE_GUID
		public Guid DivisionId { get; set; }
#else
		public int DivisionId { get; set; }
#endif
#if USE_GUID
		public Guid MenuGroupId { get; set; }
#else
		public int MenuGroupId { get; set; }
#endif
		public int? Code { get; set; }
		public string BarCode { get; set; }
		public string Image { get; set; }
#if USE_GUID
		public Guid UserCreatedId { get; set; }
#else
		public int UserCreatedId { get; set; }
#endif


		public Division Division { get; set; }
		public MenuGroup MenuGroup { get; set; }
		public ICollection<BillItem> BillItems { get; set; }
		public ICollection<Price> Prices { get; set; }
		public User UserCreated { get; set; }
	}
}
