using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace POS.Data.Model
{
	[DataContract(IsReference = true)]
	[KnownType(typeof(PriceList))]
	[KnownType(typeof(User))]
	[KnownType(typeof(BillItem))]
	public partial class Bill : PersistedUserModel
	{
		#region Primitive Properties

		[DataMember]
		public int BillNumber
		{
			get { return _BillNumber; }
			set { Set(nameof(BillNumber), value); }
		}
		private int _BillNumber;

		[DataMember]
		public Guid PriceListId
		{
			get { return _PriceListId; }
			set { Set(nameof(PriceListId), value); }
		}
		private Guid _PriceListId;

		[DataMember]
		public decimal Total
		{
			get { return _Total; }
			set { Set(nameof(Total), value); }
		}
		private decimal _Total;

		[DataMember]
		public int Guests
		{
			get { return _Guests; }
			set { Set(nameof(Guests), value); }
		}
		private int _Guests;

		[DataMember]
		public bool Printered
		{
			get { return _Printered; }
			set { Set(nameof(Printered), value); }
		}
		private bool _Printered;

		#endregion

		#region Navigation Properties

		[DataMember]
		public PriceList PriceList
		{
			get { return _PriceList; }
			set { SetNav(nameof(PriceList), value); }
		}
		private PriceList _PriceList;

		[DataMember]
		public IEnumerable<BillItem> BillItems
		{
			get { return _BillItems; }
			set { SetNav(nameof(BillItems), value); }
		}
		private IEnumerable<BillItem> _BillItems;

		#endregion
	}
}
