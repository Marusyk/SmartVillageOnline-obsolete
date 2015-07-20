using System.Data.Entity.ModelConfiguration;
using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Mapping
{
    public class StreetTypeMap : EntityTypeConfiguration<StreetType>
    {
        public StreetTypeMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            HasMany(a => a.Streets).WithRequired(p => p.StreetType).HasForeignKey(p => p.StreetTypeID).WillCascadeOnDelete(false);
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("StreetType");
        }
    }
}