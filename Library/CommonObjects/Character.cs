using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CommonObjects
{
    public class Character
    {
        public string Name { get; set; }
        public string GameName { get; set; }

        public List<Caracteristic> BaseAttributes { get; set; }
        public List<Caracteristic> Skills { get; set; }
        public List<Caracteristic> Stats { get; set; }
        public List<Caracteristic> SpendablePoints { get; set; }

        public Career Profession { get; set; }

        public Character()
        {
            BaseAttributes = new List<Caracteristic>();
            Skills = new List<Caracteristic>();
            Stats = new List<Caracteristic>();
            SpendablePoints = new List<Caracteristic>();
        }

        public Character(string name)
            : this()
        {
            Name = name;
        }

        public Character(CharacterCreationObject premade)
            :this()
        {
            Name = premade.Name;
            GameName = premade.GameName;
        }


        #region to rework
        public void Update(List<CaracteristicViewModel> Caracs)
        {
            foreach (var item in Caracs)
            {
                if (BaseAttributes.Any(b => b.Name.ToLower() == item.Name.ToLower()))
                {
                    BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == item.Name.ToLower()).Setvalue(item.Score);
                }
                else if (Skills.Any(s => s.Name.ToLower() == item.Name.ToLower()))
                {
                    Skills.FirstOrDefault(s => s.Name.ToLower() == item.Name.ToLower()).Setvalue(item.Score);
                }
                else if (Stats.Any(s => s.Name.ToLower() == item.Name.ToLower()))
                {
                    Stats.FirstOrDefault(s => s.Name.ToLower() == item.Name.ToLower()).Setvalue(item.Score);
                }
                else if (SpendablePoints.Any(s => s.Name.ToLower() == item.Name.ToLower()))
                {
                    SpendablePoints.FirstOrDefault(s => s.Name.ToLower() == item.Name.ToLower()).Setvalue(item.Score);
                }
            }
        }


        public void AdaptSkills(Character charac)
        {
            int str = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "strength").CurrentValue;
            int per = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "perception").CurrentValue;
            int end = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "endurance").CurrentValue;
            int cha = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "charism").CurrentValue;
            int inte = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "intelligence").CurrentValue;
            int agi = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "agility").CurrentValue;
            int lck = charac.BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == "luck").CurrentValue;

            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "small guns").CurrentValue = 5 + agi * 4;
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "big guns").CurrentValue = 0 + (agi * 2);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "energy weapons").CurrentValue = 0 + (agi * 2);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "unarmed").CurrentValue = 30 + 2 * (agi + str);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "melee weapons").CurrentValue = 20 + 2 * (agi + str);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "throwing").CurrentValue = 0 + 4 * agi;
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "first aid").CurrentValue = 0 + 2 * (per + end);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "doctor").CurrentValue = 5 + (per + inte);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "sneak").CurrentValue = 5 + (3 * agi);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "lockpick").CurrentValue = 10 + (per + agi);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "steal").CurrentValue = 0 + (3 * agi);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "traps").CurrentValue = 10 + (per + agi);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "science").CurrentValue = 0 + 4 * inte;
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "repair").CurrentValue = 0 + 3 * inte;
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "pilot").CurrentValue = 0 + 2 * (agi + per);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "speech").CurrentValue = 0 + 5 * cha;
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "barter").CurrentValue = 0 + 4 * cha;
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "gambling").CurrentValue = 0 + 5 * lck;
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "outdoorsman").CurrentValue = 0 + 2 * (end + inte);
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "radiation resistance").CurrentValue = 0;
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "poison resistance").CurrentValue = 0;
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "damage resistance").CurrentValue = 0;
            charac.Skills.FirstOrDefault(s => s.Name.ToLower() == "electric resistance").CurrentValue = 0;

        }

        #endregion
    }
}
