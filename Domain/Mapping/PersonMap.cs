using System.Data.Entity.ModelConfiguration;
using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Mapping
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.FirstName).IsRequired();
            Property(t => t.Name).IsRequired();
            Property(t => t.LastName).IsRequired();
            Property(t => t.DateBith).IsRequired();
            Property(t => t.Sex).IsRequired();
            Property(t => t.IdentificationCode).HasMaxLength(10);
            Property(t => t.PassSeria).HasMaxLength(2);
            Property(t => t.CatalogId).IsRequired();
            ToTable("Person");
        }
    }
}
