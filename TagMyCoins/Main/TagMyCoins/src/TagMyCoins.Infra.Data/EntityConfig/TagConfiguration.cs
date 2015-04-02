using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagMyCoins.Domain.Entities;

namespace TagMyCoins.Infra.Data.EntityConfig
{
    public class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            HasKey(t => t.TagId);

            Property(t => t.Name)
                .IsRequired();

            Property(t => t.ParentTagId)
                .IsOptional();

            HasOptional(t => t.ParentTag)
                .WithMany(t => t.ChildTags)
                .HasForeignKey(i => i.ParentTagId);

            Property(e => e.UserId)
                .IsRequired();

            ToTable("Tags");
        }
    }
}
