using System.Data.Entity.ModelConfiguration;
using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Mapping
{
    class HouseMap : EntityTypeConfiguration<House>
    {
        public HouseMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.HouseNr).IsRequired().HasMaxLength(10);
            Property(t => t.KadastrNr).HasMaxLength(30);
            Property(t => t.BuildNr).IsRequired().HasMaxLength(10);
            Property(t => t.AddressID).IsRequired();
            Property(t => t.PhoneNr).HasMaxLength(12);
            Property(t => t.PhoneCode).HasMaxLength(5);
            Property(t => t.FaxNr).HasMaxLength(12);
            Property(t => t.Code).HasMaxLength(50);
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("House");
        }
    }
}
