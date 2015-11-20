using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Domain.Entities.Dictionaries;

namespace Domain.Mapping.Dictionaries
{
    public class CityTypeMap : EntityTypeConfiguration<CityType>
    {
        public CityTypeMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            HasMany(a => a.Cities).WithRequired(p => p.CityType).HasForeignKey(p => p.CityTypeID);
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("CityType");
        }
    }
}

