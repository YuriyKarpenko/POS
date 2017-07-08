using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace POS.Data.Model
{
	/// <summary>
	/// ������������� �����
	/// </summary>
	public partial class Division : DictionaryModel
	{
		[Display(Name = "�������", Order = 12), Editable(true)]
		public string Printer { get; set; }

		[Browsable(false)]
		public virtual ICollection<MenuItem> MenuItems { get; set; }
	}
}
