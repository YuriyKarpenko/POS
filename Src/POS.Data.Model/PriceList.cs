using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace POS.Data.Model
{
	/// <summary>
	/// Названия прайс-листов
	/// </summary>
	[Serializable]
	public partial class PriceList : DictionaryModel
	{
		[Browsable(false)]
		public virtual ICollection<Bill> Bills { get; set; }

		[Browsable(false)]
		public virtual ICollection<Price> Prices { get; set; }
	}
}
