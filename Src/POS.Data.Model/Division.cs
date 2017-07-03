using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace POS.Data.Model
{
	public partial class Division : DictionaryModel
	{
		[Display(Name = "Принтер", Order = 12), Editable(true)]
		public string Printer { get; set; }

		[Browsable(false)]
		public ICollection<MenuItem> MenuItems { get; set; }
	}
}
