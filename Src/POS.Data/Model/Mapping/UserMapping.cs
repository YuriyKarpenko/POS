namespace POS.Data.Model.Mapping
{
	class UserMapping : PersistedModelMapping<User>
	{
		public UserMapping()
		{
			ToTable("User");

			//this.Property(e=>e.Role).

			HasRequired(e => e.UserGroup)
				.WithMany(e => e.Users)
				.HasForeignKey(e => e.UserGroupId)
				.WillCascadeOnDelete(false);
		}
	}
}
