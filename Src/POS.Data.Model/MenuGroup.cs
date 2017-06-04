using System;
using System.Collections.Generic;

namespace POS.Data.Model
{
	public partial class MenuGroup : DictionaryModel
	{
#if USE_GUID
		public Guid? ParentId { get; set; }
#else
		public int? ParentId { get; set; }
#endif
		public int Order { get; set; }


		public MenuGroup Parent { get; set; }
		public ICollection<MenuGroup> Children { get; set; }
		public ICollection<MenuItem> MenuItems { get; set; }

	}
}
