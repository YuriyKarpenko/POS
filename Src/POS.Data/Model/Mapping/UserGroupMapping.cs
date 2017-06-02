namespace POS.Data.Model.Mapping
{
	class UserGroupMapping : PersistedModelMapping<UserGroup>
	{
		public UserGroupMapping()
		{
			ToTable("UserGroup");
		}
	}
}
