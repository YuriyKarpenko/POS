using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace POS.Data.Model
{
	public class Bill : PersistedUserModel
	{
		public int BillNumber { get; set; }

		[Browsable(false)]
#if USE_GUID
		public Guid PriceListId { get; set; }
#else
		public int PriceListId { get; set; }
#endif
		public decimal Total { get; set; }
		public int Guests { get; set; }
		public bool Printered { get; set; }


		[Browsable(false)]
		public PriceList PriceList { get; set; }
		[Browsable(false)]
		public ICollection<BillItem> BillItems { get; set; }
	}
}
