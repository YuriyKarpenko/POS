using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace POS.Data.Model
{
	[DataContract(IsReference = true)]
	[KnownType(typeof(MenuGroup))]
	[KnownType(typeof(MenuItem))]
	public partial class MenuGroup : DictionaryModel
	{
		#region Primitive Properties

		[DataMember]
		public Guid? ParentId
		{
			get { return _ParentId; }
			set { Set(nameof(ParentId), value); }
		}
		private Guid? _ParentId;

		[DataMember]
		public int Order
		{
			get { return _Order; }
			set { Set(nameof(Order), value); }
		}
		private int _Order;

		#endregion

		#region Navigation Properties

		[DataMember]
		public IEnumerable<MenuGroup> Childrens
		{
			get { return _Childrens; }
			set { SetNav(nameof(Childrens), value); }
		}
		private IEnumerable<MenuGroup> _Childrens;

		[DataMember]
		public MenuGroup Parent
		{
			get { return _Parent; }
			set { SetNav(nameof(Parent), value); }
		}
		private MenuGroup _Parent;

		[DataMember]
		public IEnumerable<MenuItem> MenuItems
		{
			get { return _MenuItems; }
			set { SetNav(nameof(MenuItems), value); }
		}
		private IEnumerable<MenuItem> _MenuItems;

		#endregion

	}
}
