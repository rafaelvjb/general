using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagMyCoins.Domain.Entities.Base;
using TagMyCoins.Domain.Enumerators;
//using TagMyCoins.Infra.CrossCutting.Identity;

namespace TagMyCoins.Domain.Entities
{
    public class Entry : BaseEntity
    {
        public Entry()
        {
            EntryId = Guid.NewGuid();
            Tags = new List<Tag>();
        }

        public Guid EntryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime EntryDate { get; set; }
        public EnumTypeTransaction TypeTransaction { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        
        //Relacionamento com a tabela do Identity
        //public virtual ApplicationUser ApplicationUser { get; set; }
    }
}