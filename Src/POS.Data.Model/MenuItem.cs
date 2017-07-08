using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace POS.Data.Model
{
	/// <summary>
	/// Меню в группе
	/// </summary>
	[Serializable]
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

		[Display(Name = "Код товара", Order = 10), Editable(true)]
		public int? Code { get; set; }

		[Display(Name = "Штрих-код", Order = 10), Editable(true)]
		public string BarCode { get; set; }

		[Display(Name = "Изображение", Order = 10), Editable(true)]
		public byte[] Image { get; set; }

		[Browsable(false)]
#if USE_GUID
		public Guid UserCreatedId { get; set; }
#else
		public int UserCreatedId { get; set; }
#endif


		[Display(Name = "Подразделение кухни", Order = 10), Editable(false)]
		public virtual Division Division { get; set; }

		[Display(Name = "Группа меню", Order = 10), Editable(false)]
		public virtual MenuGroup MenuGroup { get; set; }

		//[Browsable(false)]
		//public virtual ICollection<BillItem> BillItems { get; set; }

		[Browsable(false)]
		public virtual ICollection<Price> Prices { get; set; }

		[Display(Name = "Создал", Order = 10), Editable(false)]
		public virtual User UserCreated { get; set; }
	}
}
