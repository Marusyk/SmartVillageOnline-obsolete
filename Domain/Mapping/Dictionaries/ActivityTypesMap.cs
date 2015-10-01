using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Dictionaries;

namespace Domain.Mapping.Dictionaries
{
    public class ActivityTypesMap : EntityTypeConfiguration<ActivityTypes>
    {
        public ActivityTypesMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            HasMany(a => a.Employments).WithOptional(p => p.ActivityTypes).HasForeignKey(p => p.ActivityTypesID);
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("ActivityTypes");
        }
    }
}
