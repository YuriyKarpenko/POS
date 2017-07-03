using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace POS.Data.Model
{
	public partial class MenuGroup : DictionaryModel
	{
		[Browsable(false)]
#if USE_GUID
		public Guid? ParentId { get; set; }
#else
		public int? ParentId { get; set; }
#endif
		public int Order { get; set; }


		public MenuGroup Parent { get; set; }
		[Browsable(false)]
		public ICollection<MenuGroup> Children { get; set; }
		[Browsable(false)]
		public ICollection<MenuItem> MenuItems { get; set; }

	}
}
