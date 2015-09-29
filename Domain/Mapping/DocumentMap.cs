using System.Data.Entity.ModelConfiguration;
using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Mapping
{
    public class DocumentMap : EntityTypeConfiguration<Document>
    {
        public DocumentMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(100);
            Property(t => t.Number).HasMaxLength(20);
            Property(t => t.Code).HasMaxLength(10);
            Property(t => t.DateReg).IsRequired();
            HasMany(a => a.Educations).WithOptional(p => p.Document).HasForeignKey(p => p.DocumentID);
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("Document");
        }
    }
}
