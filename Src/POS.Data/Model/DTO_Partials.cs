using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Data.Model
{
	partial class Division
	{
		public Division() { this._id = Guid.NewGuid(); }

		public override string ToString()
		{
			return string.Format("{0}, '{1}'", this.Id, this.Name);
		}
	}

	partial class User
	{
		public User() { this._id = Guid.NewGuid(); }

		public override string ToString()
		{
			return string.Format("{0}, '{1}'", this.Id, this.Name);
		}
	}

	partial class UserGroup
	{
		private Role _role = Role.None;

		public Role Role
		{
			get
			{
				if (this._role == Role.None)
				{
					this._role = this.GetRole();
				}

				return this._role;
			}
		}
		public UserGroup() { this._id = Guid.NewGuid(); }

		private Role GetRole()
		{
			return Role.Administratior;
		}

		public override string ToString()
		{
			return string.Format("{0}, '{1}'", this.Id, this.Name);
		}
	}

	partial class MenuGroup
	{
		public MenuGroup() { this._id = Guid.NewGuid(); }

		public override string ToString()
		{
			return string.Format("{0}, '{1}'", this.Id, this.Name);
		}
	}

	partial class MenuItem
	{
		public MenuItem() { this._id = Guid.NewGuid(); }

		public override string ToString()
		{
			return string.Format("{0}, '{1}'", this.Id, this.Name);
		}
	}

	partial class Bill
	{
		public Bill() { this._id = Guid.NewGuid(); }

		public override string ToString()
		{
			return string.Format("{0}, №={1}", this.Id, this.BillNumber);
		}
	}

	partial class BillItem
	{
		public BillItem() { this._id = Guid.NewGuid(); }

		public override string ToString()
		{
			return string.Format("{0}, '{1}'", this.Id, this.MenuItem);
		}
	}
}
