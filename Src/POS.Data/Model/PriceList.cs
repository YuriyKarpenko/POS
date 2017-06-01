using System.Collections.Generic;
using System.Runtime.Serialization;

namespace POS.Data.Model
{
	[DataContract(IsReference = true)]
	[KnownType(typeof(Bill))]
	[KnownType(typeof(Price))]
	public partial class PriceList : DictionaryModel
	{
		#region Primitive Properties

		#endregion

		#region Navigation Properties

		[DataMember]
		public IEnumerable<Bill> Bills
		{
			get { return _Bills; }
			set { SetNav(nameof(Bills), value); }
		}
		private IEnumerable<Bill> _Bills;

		[DataMember]
		public IEnumerable<Price> Prices
		{
			get { return _Prices; }
			set { SetNav(nameof(Prices), value); }
		}
		private IEnumerable<Price> _Prices;

		#endregion
	}
}
