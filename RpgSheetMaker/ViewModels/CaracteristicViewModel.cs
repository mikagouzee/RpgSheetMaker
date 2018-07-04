using Library.CommonObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgSheetMaker.ViewModels
{
    public class CaracteristicViewModel
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public CaracteristicViewModel()
        {

        }

        public CaracteristicViewModel(Caracteristic baseCarac)
        {
            Name = baseCarac.Name;
            Score = baseCarac.CurrentValue;
        }
    }
}
