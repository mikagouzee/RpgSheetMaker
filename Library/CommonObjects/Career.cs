using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CommonObjects
{
    public class Career
    {
        public string Name { get; set; }
        public List<Caracteristic> JobSkills { get; set; }

        public Career()
        {
            JobSkills = new List<Caracteristic>();
        }

        public Career(string name)
            : this()
        {
            Name = name;
        }
    }
}
