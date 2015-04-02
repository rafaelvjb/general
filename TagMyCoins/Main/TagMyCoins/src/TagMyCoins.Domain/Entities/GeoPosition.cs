using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TagMyCoins.Domain.Entities.Base;

namespace TagMyCoins.Domain.Entities
{
    public class GeoPosition : BaseEntity
    {
        public GeoPosition()
        {
            GeoPositionId = Guid.NewGuid();
        }

        public Guid GeoPositionId { get; set; }
        public string Value { get; set; }
    }
}
