using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace POS.Data.Model
{
	[DataContract(IsReference = true)]
	[KnownType(typeof(BillItem))]
	[KnownType(typeof(Division))]
	[KnownType(typeof(MenuGroup))]
	[KnownType(typeof(Price))]
	[KnownType(typeof(User))]
	public partial class MenuItem : DictionaryModel
	{
		#region Primitive Properties

		[DataMember]
		public Guid? MenuGroupId
		{
			get { return _MenuGroupId; }
			set { Set(nameof(MenuGroupId), value); }
		}
		private Guid? _MenuGroupId;

		[DataMember]
		public Guid DivisionId
		{
			get { return _DivisionId; }
			set { Set(nameof(DivisionId), value); }
		}
		private Guid _DivisionId;

		[DataMember]
		public int? Code
		{
			get { return _Code; }
			set { Set(nameof(Code), value); }
		}
		private int? _Code;

		[DataMember]
		public string BarCode
		{
			get { return _BarCode; }
			set { Set(nameof(BarCode), value); }
		}
		private string _BarCode;

		[DataMember]
		public string Image
		{
			get { return _Image; }
			set { Set(nameof(Image), value); }
		}
		private string _Image;

		[DataMember]
		public Guid UserCreatedId
		{
			get { return _UserCreatedId; }
			set { Set(nameof(UserCreatedId), value); }
		}
		private Guid _UserCreatedId;

		#endregion

		#region Navigation Properties

		[DataMember]
		public IEnumerable<BillItem> BillItems
		{
			get { return _BillItems; }
			set { SetNav(nameof(BillItems), value); }
		}
		private IEnumerable<BillItem> _BillItems;

		[DataMember]
		public Division Division
		{
			get { return _Division; }
			set { SetNav(nameof(Division), value); }
		}
		private Division _Division;

		[DataMember]
		public MenuGroup MenuGroup
		{
			get { return _MenuGroup; }
			set { SetNav(nameof(MenuGroup), value); }
		}
		private MenuGroup _MenuGroup;

		[DataMember]
		public IEnumerable<Price> Prices
		{
			get { return _Prices; }
			set { SetNav(nameof(Prices), value); }
		}
		private IEnumerable<Price> _Prices;

		[DataMember]
		public User UserCreated
		{
			get { return _UserCreated; }
			set { SetNav(nameof(UserCreated), value); }
		}
		private User _UserCreated;

		#endregion
	}
}
