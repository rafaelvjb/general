using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagMyCoins.Domain.Entities.Base;

namespace TagMyCoins.Domain.Entities
{
    public class User: BaseEntity
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Entry> Entries { get; set; }
    }
}
