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
            Property(t => t.BuildNr).HasMaxLength(10);
            Property(t => t.FlatNr).HasMaxLength(10);
            HasMany(a => a.Houses).WithRequired(p => p.Address).HasForeignKey(p => p.AddressID);
            HasMany(a => a.PersonBirthAddress).WithOptional(p => p.AddressBith).HasForeignKey(p => p.AddressBirthId);
            HasMany(a => a.PersonLiveAddress).WithOptional(p => p.AddressLive).HasForeignKey(p => p.AddressLiveId);
            Property(t => t.LastUpdUS).HasMaxLength(50);
            ToTable("Address");
        }
    }
}
