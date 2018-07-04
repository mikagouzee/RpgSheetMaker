using Library.CommonObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgSheetMaker.ViewModels
{
    public class CharacterViewModel
    {

        public string Name { get; set; }
        public List<CaracteristicViewModel> BaseAttributes { get; set; }
        public List<CaracteristicViewModel> Skills { get; set; }
        public List<CaracteristicViewModel> Stats { get; set; }
        public List<CaracteristicViewModel> PointsToSpend { get; set; }
        public Career Profession { get; set; }

        public CharacterViewModel() { }

        public CharacterViewModel(Character baseCharac)
        {
            Name = baseCharac.Name;
            BaseAttributes = MapCaracs(baseCharac.BaseAttributes);
            Skills = MapCaracs(baseCharac.Skills);
            PointsToSpend = MapCaracs(baseCharac.SpendablePoints);
            Stats = MapCaracs(baseCharac.Stats);
            Profession = baseCharac.Profession;
        }

        public List<CaracteristicViewModel> MapCaracs(List<Caracteristic> origin)
        {
            List<CaracteristicViewModel> returnValue = new List<CaracteristicViewModel>();

            foreach (var item in origin)
            {
                CaracteristicViewModel dto = new CaracteristicViewModel(item);
                returnValue.Add(dto);
            }

            return returnValue;
        }
    }
}
