using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace POS.Data.Model
{
	public partial class MenuItem : DictionaryModel
	{
		[Browsable(false)]
#if USE_GUID
		public Guid DivisionId { get; set; }
#else
		public int DivisionId { get; set; }
#endif
		[Browsable(false)]
#if USE_GUID
		public Guid MenuGroupId { get; set; }
#else
		public int MenuGroupId { get; set; }
#endif
		public int? Code { get; set; }
		public string BarCode { get; set; }
		public byte[] Image { get; set; }
		[Browsable(false)]
#if USE_GUID
		public Guid UserCreatedId { get; set; }
#else
		public int UserCreatedId { get; set; }
#endif


		public Division Division { get; set; }
		public MenuGroup MenuGroup { get; set; }
		[Browsable(false)]
		public ICollection<BillItem> BillItems { get; set; }
		[Browsable(false)]
		public ICollection<Price> Prices { get; set; }
		public User UserCreated { get; set; }
	}
}
