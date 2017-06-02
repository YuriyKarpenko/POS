namespace POS.Data.Model.Mapping
{
	class UserMapping : PersistedModelMapping<User>
	{
		public UserMapping()
		{
			ToTable("User");

			HasRequired(e => e.UserGroup)
				.WithMany(e => e.Users)
				.HasForeignKey(e => e.UserGroupId)
				.WillCascadeOnDelete(false);
		}
	}
}
