namespace POS.Data.Model.Mapping
{
	class MenuItemMapping : PersistedModelMapping<MenuItem>
	{
		public MenuItemMapping()
		{
			ToTable("MenuItem");

			Property(e => e.BarCode).HasMaxLength(30);
			Property(e => e.Image).HasColumnType("image");

			HasRequired(e => e.Division)
				.WithMany(e => e.MenuItems)
				.HasForeignKey(e => e.DivisionId)
				.WillCascadeOnDelete(false);

			HasRequired(e => e.MenuGroup)
				.WithMany(e => e.MenuItems)
				.HasForeignKey(e => e.MenuGroupId)
				.WillCascadeOnDelete(false);

			HasRequired(e => e.UserCreated)
				.WithMany(/*e => e.CreatedMenuItems*/)
				.HasForeignKey(e => e.UserCreatedId)
				.WillCascadeOnDelete(false);


			HasMany(e => e.BillItems)
				.WithRequired(i => i.MenuItem)
				.HasForeignKey(e => e.MenuItemId)
				.WillCascadeOnDelete(false);

			HasMany(e => e.Prices)
				.WithRequired(e => e.MenuItem)
				.HasForeignKey(e => e.MenuItemId)
				.WillCascadeOnDelete(false);
		}
	}
}
