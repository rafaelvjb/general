using System.Data.Entity.ModelConfiguration;
using TagMyCoins.Domain.Entities;

namespace TagMyCoins.Infra.Data.EntityConfig
{
    public class ScanBillConfiguration:EntityTypeConfiguration<ScanBill>
    {
        public ScanBillConfiguration()
        {
            HasKey(s => s.ScanBillId);

            Property(r => r.Value)
                .IsRequired();
        } 
    }
}