using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AspNetCore.Data.EF.Extensions;
using AspNetCore.Data.Entities;

namespace AspNetCore.Data.EF.Configurations
{
    public class PostTagConfiguration : DbEntityConfiguration<PostTag>
    {
        public override void Configure(EntityTypeBuilder<PostTag> entity)
        {
            //entity.HasKey(c => c.Id);
            entity.Property(c => c.TagId).HasMaxLength(255).HasColumnType("varchar(255)").IsRequired();
            // etc.
        }
    }
}