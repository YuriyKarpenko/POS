using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace POS.Data.Model
{
	/// <summary>
	/// счет
	/// </summary>
	[Serializable]
	public class Bill : PersistedUserModel
	{
		[Display(Name = "№ счета", Order = 10), Editable(false)]
		public int BillNumber { get; set; }

		[Browsable(false)]
#if USE_GUID
		public Guid PriceListId { get; set; }
#else
		public int PriceListId { get; set; }
#endif

		[Display(Name = "Число гостей", Order = 10), Editable(true)]
		public int Guests { get; set; }

		[Display(Name = "Итого", Order = 10), Editable(false)]
		public decimal Total { get; set; }

		[Display(Name = "Скидка", Order = 10), Editable(false)]
		public decimal Discount { get; set; }

		[Display(Name = "Распечатан", Order = 10), Editable(false)]
		public bool Printered { get; set; }


		[Browsable(false)]
		public virtual PriceList PriceList { get; set; }

		[Browsable(false)]
		public virtual ICollection<BillItem> BillItems { get; set; }
	}
}
