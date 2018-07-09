using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModels
{
    public class CareerViewModel
    {
        public string Name { get; set; }
        public List<CaracteristicViewModel> JobSkills { get; set; }

        public CareerViewModel()
        {
        }
    }
}
