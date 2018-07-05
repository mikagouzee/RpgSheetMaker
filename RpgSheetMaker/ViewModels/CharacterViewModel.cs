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
        public List<CaracteristicViewModel> spendablePoints { get; set; }
        public CareerViewModel Profession { get; set; }

        public CharacterViewModel() { }

        public CharacterViewModel(Character baseCharac)
        {
            Name = baseCharac.Name;
            BaseAttributes = MapCaracs(baseCharac.BaseAttributes);
            Skills = MapCaracs(baseCharac.Skills);
            spendablePoints = MapCaracs(baseCharac.SpendablePoints);
            Stats = MapCaracs(baseCharac.Stats);
            Profession = new CareerViewModel
            {
                Name = baseCharac.Profession.Name,
                JobSkills = MapCaracs(baseCharac.Profession.JobSkills)
            };
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
