namespace POS.Data.Model.Mapping
{
	class PriceListMapping : PersistedModelMapping<PriceList>
	{
		public PriceListMapping()
		{
			ToTable("PriceList");

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
