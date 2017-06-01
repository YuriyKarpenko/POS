using System.Collections.Generic;
using System.Runtime.Serialization;

namespace POS.Data.Model
{
	[DataContract(IsReference = true)]
	[KnownType(typeof(MenuItem))]
	public partial class Division : DictionaryModel
	{
		#region Primitive Properties

		[DataMember]
		public string Printer
		{
			get { return _Printer; }
			set { Set(nameof(Printer), value); }
		}
		private string _Printer;

		#endregion

		#region Navigation Properties

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
