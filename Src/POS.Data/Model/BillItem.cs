using System;
using System.ComponentModel.DataAnnotations;

namespace POS.Data.Model
{
	public partial class BillItem : PersistedUser2Model
	{
		[Required]
#if USE_GUID
		public Guid BillId { get; set; }
#else
		public int BillId { get; set; }
#endif
		[Required]
#if USE_GUID
		public Guid MenuItemId { get; set; }
#else
		public int MenuItemId { get; set; }
#endif
		[Required]
		public decimal Quantity { get; set; }


		public Bill Bill { get; set; }
		public MenuItem MenuItem { get; set; }
	}
}
