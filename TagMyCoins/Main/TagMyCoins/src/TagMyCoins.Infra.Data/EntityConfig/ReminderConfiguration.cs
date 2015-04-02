using System.Data.Entity.ModelConfiguration;
using System.Threading;
using TagMyCoins.Domain.Entities;

namespace TagMyCoins.Infra.Data.EntityConfig
{
    public class ReminderConfiguration : EntityTypeConfiguration<Reminder>
    {
        public ReminderConfiguration()
        {
            HasKey(r => r.ReminderId);

            Property(r => r.Value)
                .IsRequired();
        }
    }
}