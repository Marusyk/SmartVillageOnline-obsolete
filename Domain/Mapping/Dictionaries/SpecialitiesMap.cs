using Domain.Entities.Dictionaries;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping.Dictionaries
{
    public class SpecialitiesMap : EntityTypeConfiguration<Specialities>
    {
        public SpecialitiesMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("Specialities");
        }
    }
}
