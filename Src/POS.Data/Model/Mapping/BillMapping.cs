namespace POS.Data.Model.Mapping
{
	class BillMapping : PersistedModelMapping<Bill>
	{
		public BillMapping()
		{
			ToTable("Bill");

			Property(e => e.Total).HasPrecision(18, 3);

			HasRequired(e => e.PriceList)
				.WithMany(e => e.Bills)
				.HasForeignKey(e => e.PriceListId)
				.WillCascadeOnDelete(false);

			HasMany(e => e.BillItems)
				.WithOptional(e => e.Bill)
				.HasForeignKey(e => e.BillId)
				.WillCascadeOnDelete(false);
		}
	}
}
