using Domain.Entities.Dictionaries;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping.Dictionaries
{
    public class EducationDegreeMap : EntityTypeConfiguration<EducationDegree>
    {
        public EducationDegreeMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            HasMany(p => p.Educations).WithOptional(p => p.EducationDegree).HasForeignKey(p => p.EducationDegreeID);
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("EducationDegree");
        }
    }
}
