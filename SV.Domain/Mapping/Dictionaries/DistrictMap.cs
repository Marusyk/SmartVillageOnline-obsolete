using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Dictionaries;

namespace Domain.Mapping.Dictionaries
{
    public class DistrictMap : EntityTypeConfiguration<District>
    {
        public DistrictMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            Property(t => t.RegionID).IsRequired();
            HasMany(a => a.Cities).WithOptional(p => p.District).HasForeignKey(p => p.DistrictID);
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("District");
        }
    }
}
