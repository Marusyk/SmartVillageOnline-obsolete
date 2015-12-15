using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Dictionaries;

namespace Domain.Mapping.Dictionaries
{
    public class InstitutionMap : EntityTypeConfiguration<Institution>
    {
        public InstitutionMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            Property(t => t.CityID).IsRequired();
            HasMany(p => p.Educations).WithRequired(p => p.Institution).HasForeignKey(p => p.InstitutionID);
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("Institution");
        }
    }
}
