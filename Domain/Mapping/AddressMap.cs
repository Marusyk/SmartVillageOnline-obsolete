using System.Data.Entity.ModelConfiguration;
using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.CityID).IsRequired();
            Property(t => t.StreetID).IsRequired();
            ToTable("Address");
        }
    }
}
