using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Data
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public Int64 MaximumStrength { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
