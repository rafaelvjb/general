using System.Data.Entity.ModelConfiguration;
using System.Threading;
using TagMyCoins.Domain.Entities;

namespace TagMyCoins.Infra.Data.EntityConfig
{
    public class RepetitionConfiguration : EntityTypeConfiguration<Repetition>
    {
        public RepetitionConfiguration()
        {
            HasKey(r => r.RepetitionId);

            Property(r => r.Value)
                .IsRequired();
        }
    }
}