﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Data.EF.Extensions;
using AspNetCore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Data.EF.Configurations
{
    public class AnnouncementConfiguration : DbEntityConfiguration<Announcement>
    {
        public override void Configure(EntityTypeBuilder<Announcement> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasMaxLength(255).HasColumnType("varchar(255)").IsRequired();
            // etc.
        }
    }
}
