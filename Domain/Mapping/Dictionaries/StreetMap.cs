using System.Data.Entity.ModelConfiguration;
using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Mapping
{
    public class StreetMap : EntityTypeConfiguration<Street>
    {
        public StreetMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired();
            Property(t => t.StreetTypeID).IsRequired();
            ToTable("Street");
        }
    }
}