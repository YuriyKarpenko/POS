using System.Collections.Generic;
using System.ComponentModel;

namespace POS.Data.Model
{
	public partial class PriceList : DictionaryModel
	{
		[Browsable(false)]
		public ICollection<Bill> Bills { get; set; }
		[Browsable(false)]
		public ICollection<Price> Prices { get; set; }
	}
}
