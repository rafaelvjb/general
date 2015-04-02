using System.Data.Entity.ModelConfiguration;
using System.Threading;
using TagMyCoins.Domain.Entities;

namespace TagMyCoins.Infra.Data.EntityConfig
{
    public class GeoPositionConfiguration : EntityTypeConfiguration<GeoPosition>
    {
        public GeoPositionConfiguration()
        {
            HasKey(g => g.GeoPositionId);

            Property(g => g.Value)
                .IsRequired();
        }
    }
}