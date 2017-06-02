using System.Collections.Generic;

namespace POS.Data.Model
{
	public partial class Division : DictionaryModel
	{
		public string Printer { get; set; }

		public ICollection<MenuItem> MenuItems { get; set; }
	}
}
