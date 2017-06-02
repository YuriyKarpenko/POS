using System;
using System.Data.Entity.ModelConfiguration;

namespace POS.Data.Model.Mapping
{
	public abstract class PersistedModelMapping<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : PersistedModel
	{
		protected PersistedModelMapping()
		{
			HasKey(e => e.Id);
			Property(e => e.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
			Property(e => e.DateCreated).IsRequired().HasColumnType("datetime2");
			Property(e => e.DateLastModified).IsRequired().HasColumnType("datetime2");
		}
	}
}
