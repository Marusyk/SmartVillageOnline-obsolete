using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Domain.Entities.Dictionaries;

namespace Domain.Mapping.Dictionaries
{
    public class StreetTypeMap : EntityTypeConfiguration<StreetType>
    {
        public StreetTypeMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            HasMany(a => a.Streets).WithRequired(p => p.StreetType).HasForeignKey(p => p.StreetTypeID);
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("StreetType");
        }
    }
}