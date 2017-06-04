namespace POS.Data.Model.Mapping
{
	class PriceListMapping : PersistedModelMapping<PriceList>
	{
		public PriceListMapping()
		{
			ToTable("PriceList");

			Property(e => e.Name).IsRequired();

			HasMany(e => e.Bills)
				.WithRequired(e => e.PriceList)
				.HasForeignKey(e => e.PriceListId)
				.WillCascadeOnDelete(false);

			//HasMany(e => e.Prices)
			//	.WithRequired(e => e.PriceList)
			//	.HasForeignKey(e => e.PriceListId)
			//	.WillCascadeOnDelete(false);
		}
	}
}
