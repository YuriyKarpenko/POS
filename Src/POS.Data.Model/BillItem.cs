using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace POS.Data.Model
{
	/// <summary>
	/// ������ �����
	/// </summary>
	[Serializable]
	public partial class BillItem : PersistedUser2Model
	{
		[Browsable(false)]
#if USE_GUID
		public Guid BillId { get; set; }
#else
		public int BillId { get; set; }
#endif
		[Browsable(false)]
#if USE_GUID
		public Guid MenuItemId { get; set; }
#else
		public int MenuItemId { get; set; }
#endif

		[Display(Name = "���-��", Order = 10), Editable(false)]
		public decimal Quantity { get; set; }


		[Display(Name = "����", Order = 10), Editable(false)]
		public virtual Bill Bill { get; set; }

		[Display(Name = "�������", Order = 10), Editable(false)]
		public virtual MenuItem MenuItem { get; set; }
	}
}
