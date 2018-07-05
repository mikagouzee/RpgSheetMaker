using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgSheetMaker.ViewModels
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
