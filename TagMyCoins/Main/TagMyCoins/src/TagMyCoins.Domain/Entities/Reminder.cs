using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TagMyCoins.Domain.Entities.Base;

namespace TagMyCoins.Domain.Entities
{
    public class Reminder : BaseEntity
    {
        public Reminder()
        {
            ReminderId = Guid.NewGuid();
        }

        public Guid ReminderId { get; set; }
        public string Value { get; set; }
    }
}
