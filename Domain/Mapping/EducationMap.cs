using Domain.Entities.Dictionaries;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping.Dictionaries
{
    public class EducationMap : EntityTypeConfiguration<Education>
    {
        public EducationMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.PersonID).IsRequired();
            Property(t => t.InstitutionID).IsRequired();
            Property(t => t.Description).HasMaxLength(500);
            Property(t => t.LastUpdUS).HasMaxLength(50);
            ToTable("Education");
        }
    }
}
