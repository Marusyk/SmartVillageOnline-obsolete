using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Dictionaries;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping.Dictionaries
{
    public class CompaniesMap : EntityTypeConfiguration<Companies>
    {
        public CompaniesMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            HasMany(a => a.Employments).WithOptional(p => p.Company).HasForeignKey(p => p.CompanyID);
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("Companies");
        }
    }
}
