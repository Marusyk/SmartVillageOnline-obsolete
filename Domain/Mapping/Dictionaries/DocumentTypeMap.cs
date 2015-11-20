using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Dictionaries;

namespace Domain.Mapping.Dictionaries
{
    public class DocumentTypeMap : EntityTypeConfiguration<DocumentType>
    {
        public DocumentTypeMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            Property(t => t.Code).HasMaxLength(20);
            HasMany(p => p.Documents).WithOptional(p => p.DocumentType).HasForeignKey(p => p.DocumentTypeID);
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("DocumentType");
        }
    }
}
