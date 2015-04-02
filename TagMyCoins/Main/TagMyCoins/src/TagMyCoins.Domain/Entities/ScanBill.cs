using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TagMyCoins.Domain.Entities.Base;

namespace TagMyCoins.Domain.Entities
{
    public class ScanBill : BaseEntity
    {
        public ScanBill()
        {
            ScanBillId = Guid.NewGuid();
        }

        public Guid ScanBillId { get; set; }
        public string Value { get; set; }
    }
}
