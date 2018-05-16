using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Data.EF.Extensions;
using AspNetCore.Data.Entities;

namespace AspNetCore.Data.EF.Configurations
{
    public class LanguageConfiguration : DbEntityConfiguration<Language>
    {
        public override void Configure(EntityTypeBuilder<Language> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasMaxLength(255).HasColumnType("varchar(255)").IsRequired();
            // etc.
        }
    }
}
