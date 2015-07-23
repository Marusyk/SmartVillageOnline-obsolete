﻿using System.Data.Entity.ModelConfiguration;
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
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            Property(t => t.StreetTypeID).IsRequired();
            HasMany(a => a.Addresses).WithOptional(p => p.Street).HasForeignKey(p => p.StreetID);
            Property(t => t.LastUpdUS).IsRequired().HasMaxLength(50);
            ToTable("Street");
        }
    }
}