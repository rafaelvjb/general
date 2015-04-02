using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagMyCoins.Domain.Entities.Base
{
    public class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public Guid CreatedByUser { get; set; }

        public DateTime UpdatedDate { get; set; }
        public Guid UpdatedByUser { get; set; }
    }
}
