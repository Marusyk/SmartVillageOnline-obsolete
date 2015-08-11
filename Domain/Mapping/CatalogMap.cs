using System.Data.Entity.ModelConfiguration;
using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Mapping
{
    public class CatalogMap: EntityTypeConfiguration<Catalog>
    {
        public CatalogMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            HasMany(a => a.Persons).WithRequired(p => p.Catalog).HasForeignKey(p => p.CatalogId);
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("Catalog");
        }
    }
}
