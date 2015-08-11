using System.Data.Entity.ModelConfiguration;
using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Mapping.Dictionaries
{
    public class NationalityMap : EntityTypeConfiguration<Nationality>
    {
        public NationalityMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            HasMany(a => a.Persons).WithRequired(p => p.Nationality).HasForeignKey(p => p.NationalityId);
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("Nationality");
        }
    }
}
