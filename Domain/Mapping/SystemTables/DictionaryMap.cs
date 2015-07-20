using Domain.Entities.SystemTables;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Mapping.SystemTables
{
    public class DictionaryMap : EntityTypeConfiguration<SYS_Dictionary>
    {
        public DictionaryMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            Property(t => t.Description).IsRequired().HasMaxLength(250);
            Property(t => t.IsStatic).IsRequired();
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("SYS_Dictionary");
        }
    }
}
