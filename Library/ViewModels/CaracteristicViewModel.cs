using Library.CommonObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModels
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
            Score = baseCarac.Validate(baseCarac.CurrentValue) ?
                baseCarac.CurrentValue:
                baseCarac.Minimum;
        }


        public bool EqualsCaracteristic(Caracteristic carac)
        {
            return this.Name.ToLower() == carac.Name.ToLower();
        }

    }
}
