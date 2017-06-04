namespace POS.Data.Model.Mapping
{
	class UserMapping : PersistedModelMapping<User>
	{
		public UserMapping()
		{
			ToTable("User");

			Property(e => e.PersonInfo.Card).IsRequired();
			Property(e => e.PersonInfo.FirstName).IsRequired();

			HasRequired(e => e.UserGroup)
				.WithMany(e => e.Users)
				.HasForeignKey(e => e.UserGroupId)
				.WillCascadeOnDelete(false);
		}
	}
}
