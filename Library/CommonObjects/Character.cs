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

        #region to rework
        public void Update(List<CaracteristicViewModel> Caracs)
        {
            foreach (var item in Caracs)
            {
                if (BaseAttributes.Any(b => b.Name.ToLower() == item.Name.ToLower()))
                {
                    var current = BaseAttributes.FirstOrDefault(b => b.Name.ToLower() == item.Name.ToLower());
                    current.Setvalue(item.Score);
                }
                else if (Skills.Any(s => s.Name.ToLower() == item.Name.ToLower()))
                {
                    var current = Skills.FirstOrDefault(s => s.Name.ToLower() == item.Name.ToLower());
                    current.Setvalue(item.Score);
                }
                else if (Stats.Any(s => s.Name.ToLower() == item.Name.ToLower()))
                {
                    var current = Stats.FirstOrDefault(s => s.Name.ToLower() == item.Name.ToLower());
                    current.Setvalue(item.Score);
                }
                else if (SpendablePoints.Any(s => s.Name.ToLower() == item.Name.ToLower()))
                {
                    var current = SpendablePoints.FirstOrDefault(s => s.Name.ToLower() == item.Name.ToLower());
                    current.Setvalue(item.Score);
                }
            }
        }
        #endregion
    }
}
