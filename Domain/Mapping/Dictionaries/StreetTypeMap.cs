using System.Data.Entity.ModelConfiguration;
using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Mapping
{
    public class StreetTypeMap : EntityTypeConfiguration<StreetType>
    {
        public StreetTypeMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired();
            ToTable("StreetType");
        }
    }
}