using System.Collections.Generic;

namespace POS.Data.Model
{
	public partial class UserGroup : PersistedModel
	{
		public string Name { get; set; }


		public ICollection<User> Users { get; set; }
	}
}
