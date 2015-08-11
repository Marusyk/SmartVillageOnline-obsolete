﻿using System.Data.Entity.ModelConfiguration;
using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Mapping.Dictionaries
{
    public class PassAuthorityMap : EntityTypeConfiguration<PassAuthority>
    {
        public PassAuthorityMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            HasMany(a => a.Persons).WithRequired(p => p.PassAuthority).HasForeignKey(p => p.PassAuthorityId);
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("PassAuthority");
        }
    }
}
