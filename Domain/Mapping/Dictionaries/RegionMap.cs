using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Dictionaries;

namespace Domain.Mapping.Dictionaries
{
    public class RegionMap : EntityTypeConfiguration<Region>
    {
        public RegionMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            Property(t => t.CountryID).IsRequired();
            HasMany(a => a.Districts).WithRequired(p => p.Region).HasForeignKey(p => p.RegionID);
            HasMany(a => a.Cities).WithRequired(p => p.Region).HasForeignKey(p => p.RegionID);
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("Region");
        }
    }
}
