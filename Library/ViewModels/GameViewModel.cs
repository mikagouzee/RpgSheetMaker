using Library.CommonObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModels
{
    public class GameViewModel
    {
        public string Name { get; set; }
        public List<string> jobs { get; set; }
        public List<string> species { get; set; }
        public string rules { get; set; }

        public GameViewModel()
        {
            jobs = new List<string>();
            species = new List<string>();
        }


    }
}
