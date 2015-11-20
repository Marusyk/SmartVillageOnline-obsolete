using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Dictionaries;

namespace Domain.Mapping.Dictionaries
{
    public class PositionMap : EntityTypeConfiguration<Position>
    {
        public PositionMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            HasMany(a => a.Employments).WithOptional(p => p.Position).HasForeignKey(p => p.PositionID);
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("Position");
        }
    }
}
