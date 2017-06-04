namespace POS.Data.Model.Mapping
{
	class DivisionMapping : PersistedModelMapping<Division>
	{
		public DivisionMapping()
		{
			ToTable("Division");

			Property(e => e.Name).IsRequired();

			//HasMany(e => e.MenuItems)
			//	.WithOptional(e => e.Division)
			//	.HasForeignKey(e => e.DivisionId)
			//	.WillCascadeOnDelete(false);
		}
	}
}
