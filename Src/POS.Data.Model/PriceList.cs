using System.Collections.Generic;

namespace POS.Data.Model
{
	public partial class PriceList : DictionaryModel
	{
		public ICollection<Bill> Bills { get; set; }
		public ICollection<Price> Prices { get; set; }
	}
}
