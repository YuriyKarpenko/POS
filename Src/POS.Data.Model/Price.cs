using System;
using System.ComponentModel;

namespace POS.Data.Model
{
	public partial class Price : PersistedUser2Model
	{
		[Browsable(false)]
#if USE_GUID
		public Guid MenuItemId { get; set; }
#else
		public int MenuItemId { get; set; }
#endif
		[Browsable(false)]
#if USE_GUID
		public Guid? PriceListId { get; set; }
#else
		public int? PriceListId { get; set; }
#endif
		public decimal Cost { get; set; }


		public MenuItem MenuItem { get; set; }
		public PriceList PriceList { get; set; }
	}
}
