using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Data.Model
{
	public class Bill : PersistedUserModel
	{
		[Required]
		public int BillNumber { get; set; }
		[Required]
#if USE_GUID
		public Guid PriceListId { get; set; }
#else
		public int PriceListId { get; set; }
#endif
		[Required]
		public decimal Total { get; set; }
		[Required]
		public int Guests { get; set; }
		[Required]
		public bool Printered { get; set; }


		[Required]
		public PriceList PriceList { get; set; }
		public ICollection<BillItem> BillItems { get; set; }
	}
}
