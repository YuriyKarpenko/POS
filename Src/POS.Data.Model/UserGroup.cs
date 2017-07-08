using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace POS.Data.Model
{
	/// <summary>
	/// ������ �������������
	/// </summary>
	[Serializable]
	public partial class UserGroup : DictionaryModel
	{
		[Browsable(false)]
		public virtual ICollection<User> Users { get; set; }
	}
}
