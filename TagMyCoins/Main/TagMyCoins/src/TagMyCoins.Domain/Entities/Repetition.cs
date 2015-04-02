using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TagMyCoins.Domain.Entities.Base;

namespace TagMyCoins.Domain.Entities
{
    public class Repetition : BaseEntity
    {
        public Repetition()
        {
            RepetitionId = Guid.NewGuid();
        }
        public Guid RepetitionId { get; set; }
        public string Value { get; set; }
    }
}
