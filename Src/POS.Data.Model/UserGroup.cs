using System.Collections.Generic;
using System.ComponentModel;

namespace POS.Data.Model
{
	public partial class UserGroup : DictionaryModel
	{
		[Browsable(false)]
		public ICollection<User> Users { get; set; }
	}
}
