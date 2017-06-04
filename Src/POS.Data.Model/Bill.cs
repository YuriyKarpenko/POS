using System;
using System.Collections.Generic;

namespace POS.Data.Model
{
	public class Bill : PersistedUserModel
	{
		public int BillNumber { get; set; }
#if USE_GUID
		public Guid PriceListId { get; set; }
#else
		public int PriceListId { get; set; }
#endif
		public decimal Total { get; set; }
		public int Guests { get; set; }
		public bool Printered { get; set; }


		public PriceList PriceList { get; set; }
		public ICollection<BillItem> BillItems { get; set; }
	}
}
