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
            Property(t => t.Name).IsRequired();
            Property(t => t.Description).IsRequired();
            Property(t => t.IsStatic).IsRequired();
            ToTable("SYS_Dictionary");
        }
    }
}
