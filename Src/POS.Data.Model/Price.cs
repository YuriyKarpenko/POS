using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace POS.Data.Model
{
	/// <summary>
	/// Прайс-листы
	/// </summary>
	[Serializable]
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

		[Display(Name = "Стоимость", Order = 10), Editable(true)]
		public decimal Cost { get; set; }


		[Display(Name = "Продукция", Order = 10), Editable(false)]
		public virtual MenuItem MenuItem { get; set; }

		[Display(Name = "Прайс-лист", Order = 10), Editable(false)]
		public virtual PriceList PriceList { get; set; }
	}
}
