using System;

namespace POS.Data.Model
{
	[Serializable]
	public partial class BillItem : PersistedUser2Model
	{
#if USE_GUID
		public Guid BillId { get; set; }
#else
		public int BillId { get; set; }
#endif
#if USE_GUID
		public Guid MenuItemId { get; set; }
#else
		public int MenuItemId { get; set; }
#endif
		public decimal Quantity { get; set; }


		public Bill Bill { get; set; }
		public MenuItem MenuItem { get; set; }
	}
}
