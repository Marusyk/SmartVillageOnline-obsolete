using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{
    public class PersonDocumentsMap : EntityTypeConfiguration<PersonDocuments>
    {
        public PersonDocumentsMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.DocumentID).IsRequired();
            Property(t => t.PersonID).IsRequired();
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("PersonDocuments");
        }
    }
}
