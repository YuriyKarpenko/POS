using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace POS.Data.Model.Mapping
{
	public abstract class PersistedModelMapping<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : PersistedModel
	{
		protected PersistedModelMapping()
		{
			HasKey(e => e.Id);
			Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(e => e.DateCreated).IsRequired().HasColumnType("datetime");
			Property(e => e.DateLastModified).IsRequired().HasColumnType("datetime");
		}
	}
}
