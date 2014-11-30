using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core
{
    public class Student
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsCurrent { get; set; }
    }  
}
