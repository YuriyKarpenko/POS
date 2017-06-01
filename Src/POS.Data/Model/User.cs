using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace POS.Data.Model
{
	[DataContract(IsReference = true)]
	[KnownType(typeof(Bill))]
	[KnownType(typeof(BillItem))]
	[KnownType(typeof(MenuItem))]
	[KnownType(typeof(UserGroup))]
	public partial class User : DictionaryModel
	{
		#region Primitive Properties

		[DataMember]
		public Guid UserGroupId
		{
			get { return _UserGroupId; }
			set { Set(nameof(UserGroupId), value); }
		}
		private Guid _UserGroupId;

		[DataMember]
		public int? Code
		{
			get { return _Code; }
			set { Set(nameof(Code), value); }
		}
		private Nullable<int> _Code;

		[DataMember]
		public string Card
		{
			get { return _Card; }
			set { Set(nameof(Card), value); }
		}
		private string _Card;

		[DataMember]
		public bool? SexMale
		{
			get { return _SexMale; }
			set { Set(nameof(SexMale), value); }
		}
		private bool _SexMale;

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
		public IEnumerable<BillItem> BillItems
		{
			get { return _BillItems; }
			set { SetNav(nameof(BillItems), value); }
		}
		private IEnumerable<BillItem> _BillItems;

		[DataMember]
		public IEnumerable<BillItem> BillItems1
		{
			get { return _BillItems1; }
			set { SetNav(nameof(BillItems1), value); }
		}
		private IEnumerable<BillItem> _BillItems1;

		[DataMember]
		public IEnumerable<MenuItem> MenuItems
		{
			get { return _MenuItems; }
			set { SetNav(nameof(MenuItems), value); }
		}
		private IEnumerable<MenuItem> _MenuItems;

		[DataMember]
		public UserGroup UserGroup
		{
			get { return _UserGroup; }
			set { SetNav(nameof(UserGroup), value); }
		}
		private UserGroup _UserGroup;

		#endregion
	}
}
