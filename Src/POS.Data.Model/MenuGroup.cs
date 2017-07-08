using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace POS.Data.Model
{
	/// <summary>
	/// Дерево групп меню
	/// </summary>
	[Serializable]
	public partial class MenuGroup : DictionaryModel
	{
		[Browsable(false)]
#if USE_GUID
		public Guid? ParentId { get; set; }
#else
		public int? ParentId { get; set; }
#endif
		[Display(Name = "Прядок отображения", Order = 10), Editable(false)]
		public int Order { get; set; }


		public virtual  MenuGroup Parent { get; set; }

		[Browsable(false)]
		public virtual ICollection<MenuGroup> Children { get; set; }

		//[Browsable(false)]
		//public virtual ICollection<MenuItem> MenuItems { get; set; }

	}
}
