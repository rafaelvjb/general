using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagMyCoins.Domain.Entities.Base;

namespace TagMyCoins.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public Tag()
        {
            TagId = Guid.NewGuid();
            ChildTags = new List<Tag>();
            Entries = new List<Entry>();
        }
        public Guid TagId { get; set; }
        public string Name { get; set; }

        //AutoRelacionamento
        public Guid ParentTagId { get; set; }
        public virtual Tag ParentTag { get; set; }
        
        public virtual ICollection<Tag> ChildTags { get; set; }

        public virtual ICollection<Entry> Entries { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        
        //Relacionamento com a tabela do Identity
        //public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
