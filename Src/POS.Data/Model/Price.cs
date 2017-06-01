using System;
using System.Runtime.Serialization;

namespace POS.Data.Model
{
	[DataContract(IsReference = true)]
	[KnownType(typeof(MenuItem))]
	[KnownType(typeof(PriceList))]
	public partial class Price : BaseModel
	{
		#region Primitive Properties

		[DataMember]
		public Guid PriceListId
		{
			get { return _PriceListId; }
			set { Set(nameof(PriceListId), value); }
		}
		private Guid _PriceListId;

		[DataMember]
		public Guid MenuItemId
		{
			get { return _MenuItemId; }
			set { Set(nameof(MenuItemId), value); }
		}
		private Guid _MenuItemId;

		[DataMember]
		public decimal Amount
		{
			get { return _Amount; }
			set { Set(nameof(Amount), value); }
		}
		private decimal _Amount;

		#endregion

		#region Navigation Properties

		[DataMember]
		public MenuItem MenuItem
		{
			get { return _MenuItem; }
			set { SetNav(nameof(MenuItem), value); }
		}
		private MenuItem _MenuItem;

		[DataMember]
		public PriceList PriceList
		{
			get { return _PriceList; }
			set { Set(nameof(PriceList), value); }
		}
		private PriceList _PriceList;

		#endregion
	}
}
