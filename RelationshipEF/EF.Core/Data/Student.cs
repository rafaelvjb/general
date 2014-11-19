using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Data
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public byte Age { get; set; }
        public bool IsCurrent { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }  
}
