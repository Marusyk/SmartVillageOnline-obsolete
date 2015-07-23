using System.Data.Entity.ModelConfiguration;
using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Dictionaries;

namespace Domain.Mapping.Dictionaries
{
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            Property(t => t.CityTypeID).IsRequired();
            Property(t => t.RegionID).IsRequired();
            HasMany(a => a.Addresses).WithRequired(p => p.City).HasForeignKey(p => p.CityID);
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("City");
        }
    }
}
