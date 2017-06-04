namespace POS.Data.Model.Mapping
{
	class MenuGroupMapping : PersistedModelMapping<MenuGroup>
	{
		public MenuGroupMapping()
		{
			ToTable("MenuGroup");

			Property(e => e.Name).IsRequired();

			HasOptional(e => e.Parent)
				.WithMany(e => e.Children)
				.HasForeignKey(e => e.ParentId)
				.WillCascadeOnDelete(false);

			HasMany(e => e.Children)
				.WithOptional()
				.HasForeignKey(e => e.ParentId)
				.WillCascadeOnDelete(false);

			//HasMany(e => e.MenuItems)
			//	.WithOptional(e => e.MenuGroup)
			//	.HasForeignKey(e => e.MenuGroupId)
			//	.WillCascadeOnDelete(false);

		}
	}
}
