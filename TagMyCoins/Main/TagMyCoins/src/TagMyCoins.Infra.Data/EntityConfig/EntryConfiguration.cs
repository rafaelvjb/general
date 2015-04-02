using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagMyCoins.Domain.Entities;

namespace TagMyCoins.Infra.Data.EntityConfig
{
    public class EntryConfiguration : EntityTypeConfiguration<Entry>
    {
        public EntryConfiguration()
        {
            HasKey(e => e.EntryId);

            Property(e => e.Amount)
                .IsRequired();

            Property(e => e.EntryDate)
                .IsRequired();

            Property(e => e.TypeTransaction)
                .IsRequired();

            Property(e => e.Notes)
                .IsOptional()
                .HasMaxLength(250);

            HasMany(e => e.Tags)
                .WithMany(t => t.Entries)
                .Map(et =>
                {
                    et.MapLeftKey("EntryId");
                    et.MapRightKey("TagId");
                    et.ToTable("EntryTag");
                });

            Property(e => e.UserId)
                .IsRequired();


            ToTable("Entries");
        }
    }
}