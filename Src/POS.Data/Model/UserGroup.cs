using System.Collections.Generic;
using System.Runtime.Serialization;

namespace POS.Data.Model
{
	[DataContract(IsReference = true)]
	[KnownType(typeof(User))]
	public partial class UserGroup : BaseModel
	{
		#region Primitive Properties

		[DataMember]
		public string Name
		{
			get { return _Name; }
			set { Set(nameof(Name), value); }
		}
		private string _Name;

		#endregion

		#region Navigation Properties

		[DataMember]
		public IEnumerable<User> Users
		{
			get { return _Users; }
			set { SetNav(nameof(Users), value); }
		}
		private IEnumerable<User> _Users;

		#endregion
	}
}
