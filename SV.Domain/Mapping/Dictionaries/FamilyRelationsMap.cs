using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Dictionaries;

namespace Domain.Mapping.Dictionaries
{
    public class FamilyRelationsMap : EntityTypeConfiguration<FamilyRelations>
    {
        public FamilyRelationsMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            HasMany(a => a.Peoples).WithOptional(p => p.FamilyRelations).HasForeignKey(p => p.FamilyRelationID);
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("FamilyRelations");
        }
    }
}
