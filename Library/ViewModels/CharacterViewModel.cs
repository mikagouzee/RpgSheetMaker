using Library.CommonObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModels
{
    public class CharacterViewModel
    {

        public string Name { get; set; }
        public string GameName { get; set; }
        public string careername { get => Profession.Name;}
        public string SpeciesName { get; set; }
        public List<CaracteristicViewModel> BaseAttributes { get; set; }
        public List<CaracteristicViewModel> Skills { get; set; }
        public List<CaracteristicViewModel> Stats { get; set; }
        public List<CaracteristicViewModel> spendablePoints { get; set; }
        public CareerViewModel Profession { get; set; }

        public CharacterViewModel() { }

        public CharacterViewModel(Character baseCharac)
        {
            Name = baseCharac.Name;
            GameName = baseCharac.GameName;
            SpeciesName = baseCharac.Species.Name;
            BaseAttributes = MapCaracs(baseCharac.BaseAttributes);
            Skills = MapCaracs(baseCharac.Skills);
            spendablePoints = MapCaracs(baseCharac.SpendablePoints);
            Stats = MapCaracs(baseCharac.Stats);

            Profession = new CareerViewModel
            {
                Name = baseCharac.Profession?.Name,
                JobSkills = baseCharac.Profession != null ?
                    MapCaracs(baseCharac.Profession.JobSkills)
                    : new List<CaracteristicViewModel>()
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

    public class RandomCharacterCreationObject
    {
        public string Name { get; set; }

        public string CareerName { get; set; }

        public string GameName { get; set; }

        public string SpeciesName { get; set; }

        public RandomCharacterCreationObject()
        {
            Name = "Premade default";
            CareerName = "default occupation";
            GameName = "default game";
        }
    }

    public class CharacterCreationObject
    {
        public string Name { get; set; }

        public string CareerName { get; set; }

        public string GameName { get; set; }

        public string SpeciesName { get; set; }

        public List<CaracteristicViewModel> BaseAttributes { get; set; }
        public List<CaracteristicViewModel> Skills { get; set; }
        //public List<CaracteristicViewModel> Stats { get; set; }
        //public List<CaracteristicViewModel> spendablePoints { get; set; }

        public CharacterCreationObject()
        {
            Name = "Default Name";
            CareerName = "Default Career";
            GameName = "Default game";
            SpeciesName = "human";
            BaseAttributes = new List<CaracteristicViewModel>();
            Skills = new List<CaracteristicViewModel>();
            //Stats = new List<CaracteristicViewModel>();
            //spendablePoints = new List<CaracteristicViewModel>();
        }

    }

}
