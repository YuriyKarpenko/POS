namespace POS.Data.Model.Mapping
{
	class PriceMapping : PersistedModelMapping<Price>
	{
		public PriceMapping()
		{
			ToTable("Price");

			HasRequired(e => e.CreatedByUser)
				.WithMany(e => e.CreatedPrices)
				.HasForeignKey(e => e.CreatedByUserId)
				.WillCascadeOnDelete(false);

			HasRequired(e => e.MenuItem)
				.WithMany(e => e.Prices)
				.HasForeignKey(e => e.MenuItemId)
				.WillCascadeOnDelete(false);

			HasOptional(e => e.ModifiedByUser)
				.WithMany(e => e.ModifiedPrices)
				.HasForeignKey(e => e.ModifiedByUserId)
				.WillCascadeOnDelete(false);

			HasOptional(e => e.PriceList)
				.WithMany(e => e.Prices)
				.HasForeignKey(e => e.PriceListId)
				.WillCascadeOnDelete(false);
		}
	}
}
