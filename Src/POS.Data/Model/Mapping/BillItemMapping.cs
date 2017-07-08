namespace POS.Data.Model.Mapping
{
	class BillItemMapping : PersistedModelMapping<BillItem>
	{
		public BillItemMapping()
		{
			ToTable("BillItem");

			Property(e => e.Quantity).HasPrecision(18, 3);

			HasRequired(e => e.Bill)
				.WithMany(e => e.BillItems)
				.HasForeignKey(e => e.BillId)
				.WillCascadeOnDelete(false);

			HasRequired(e => e.MenuItem)
				.WithMany(/*e => e.BillItems*/)
				.HasForeignKey(e => e.MenuItemId)
				.WillCascadeOnDelete(false);
		}
	}
}
