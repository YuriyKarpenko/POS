using System.Runtime.Serialization;

namespace POS.Data.Model
{
	[DataContract(IsReference = true)]
	[KnownType(typeof(Bill))]
	[KnownType(typeof(User))]
	[KnownType(typeof(MenuItem))]
	public partial class BillItem : PersistedUser2Model
	{
		#region Primitive Properties

		[DataMember]
		public System.Guid BillId
		{
			get { return _BillId; }
			set { Set(nameof(BillId), value); }
		}
		private System.Guid _BillId;

		[DataMember]
		public System.Guid MenuItemId
		{
			get { return _MenuItemId; }
			set { Set(nameof(MenuItemId), value); }
		}
		private System.Guid _MenuItemId;

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
		public Bill Bill
		{
			get { return _Bill; }
			set { SetNav(nameof(Bill), value); }
		}
		private Bill _Bill;

		[DataMember]
		public MenuItem MenuItem
		{
			get { return _MenuItem; }
			set { SetNav(nameof(MenuItem), value); }
		}
		private MenuItem _MenuItem;

		#endregion
	}
}
